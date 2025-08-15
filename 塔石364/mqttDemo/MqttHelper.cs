using HmExtension.Commons.Extensions;
using MQTTnet;
using MQTTnet.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mqttDemo
{
    public class MqttHelper
    {
        private static IMqttClient _client;

        public static  event Action <EnvironmentData>OnDataReceived;//事件接收


        public static event Action<MqttClientOptions> OnConnecting;

        public static event Action<MqttClientConnectResult > OnConnected;




        //连接
        public static Task<string > Connect(string host, int port, string username, string password, string clientId = null )
        {
            _client = new MqttFactory().CreateMqttClient();//客户端的初始化，这行代码创建了一个新的 MQTT 客户端实例，使用了 MQTTnet 提供的 MqttFactory 类。

            //连接选项的设置
            var options = new MqttClientOptionsBuilder()
                .WithTcpServer(host, port)//指定MQTT代理的主机地址和端口
                .WithCredentials(username, password)//设置MQTT的用户名和密码
                .WithClientId(clientId ?? Guid.NewGuid().ToString())//设置客户端ID，如果没有设置，则使用Guid生成一个唯一的ID
                .WithTlsOptions(new MqttClientTlsOptions()//配置了TLS选项，这里明确关闭了SSL加密//TLS是建立在SSL协议之上的安全协议，它是一种加密传输层安全性协议，用于在两个通信应用程序之间提供保密性和数据完整性。
                {
                    UseTls = false,//关闭SSL加密
                }).Build();


            //事件处理程序：
            // 处理接收到的 MQTT 消息。
            // 它从消息中获取数据部分，
            // 将其转换为字符串（json），
            // 然后反序列化为 EnvironmentData 对象，
            // 并触发 OnDataReceived 事件。
            _client.ApplicationMessageReceivedAsync += e =>
            {
                //得到接受到的消息对象
                var msg = e.ApplicationMessage;
                //从消息对象中得到传递的数据
                var payload = msg.PayloadSegment;
                //将得到的数据转化为字符串
                var json = payload.ToArray().FromString(Encoding .Default );
                //由于字符串是json格式，所以可以直接反序列化为对象
                OnDataReceived.Invoke(json.FromJson<EnvironmentData>());
                return Task.CompletedTask;//告诉服务器我已经收到消息了，避免重复发送
            };

            _client.ConnectingAsync += e =>
            {
                //当客户端开始连接时触发
                OnConnecting?.Invoke(e.ClientOptions);
                return Task.CompletedTask;
            };

            _client.ConnectedAsync  += e =>
            {
                //当客户端成功连接时触发
                OnConnected?.Invoke(e.ConnectResult );
                return Task.CompletedTask;
            };
            //连接和返回结果：
            //_client.ConnectAsync(options) 异步连接到 MQTT 代理，使用之前配置好的选项。
            //.ContinueWith(t => t.Result.AssignedClientIdentifier) 返回一个任务，在连接完成后返回分配的客户端标识符（AssignedClientIdentifier）。
            return _client.ConnectAsync(options).ContinueWith(t => t.Result.AssignedClientIdentifier);//因为想看一下对象的结果到底是什么      
        }


        /// <summary>
        /// 订阅主题
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        //订阅
        //这是一个公共静态方法，用于异步订阅MQTT主题
        //topic是作为参数传入的订阅主题，即要订阅的消息主题
        //这段代码的作用是通过 MQTT 客户端 _client 异步订阅指定的主题，并返回一个任务，以便调用者可以等待订阅操作完成并处理订阅结果。
        public static Task <MqttClientSubscribeResult> SubscribleAsync(string topic)
        {
            //订阅选项的设置
            var options = new MqttClientSubscribeOptionsBuilder()//创建了一个MQTT订阅选项构建器
                .WithTopicFilter(topic)//指定了需要订阅的主题，将参数 topic 设置为订阅选项的主题过滤器。
                .Build();
            //执行订阅
            //_client.SubscribeAsync(options) 是 MQTT 客户端对象 _client 调用的异步方法，用于实际执行订阅操作。
            // options 是之前配置好的订阅选项，包括要订阅的主题
            //法返回一个 Task<MqttClientSubscribeResult> 对象，表示订阅操作的异步任务。MqttClientSubscribeResult 包含有关订阅结果的信息，例如订阅的主题和分配的 QoS（服务质量）等级。
            return _client.SubscribeAsync(options);
        }







        //总结
        //这两个方法结合起来，可以实现向 MQTT 主题发布消息，
        //并且在需要时能够方便地断开与 MQTT 代理的连接。
        //推送方法允许您发送消息，而断开方法允许您在需要时关闭连接，
        //这在管理 MQTT 连接和消息传递时非常有用。
        /// <summary>
        /// 推送数据
        /// </summary>
        /// <param name="topic">要发布消息的 MQTT 主题。</param>
        /// <param name="data">要发布的消息内容，作为字符串传入。</param>
        /// 功能： 这个方法用于向指定的 MQTT 主题发布消息。
        //推送
        public static void Push(string topic,string  data)
        {
            var msg = new MqttApplicationMessage();//创建了一个新的 MqttApplicationMessage 实例 msg
            msg.Topic = topic;//设置 msg 的 Topic 属性为传入的 topic。


            // EnvironmentData data = new EnvironmentData();
            /*   var json= JsonConvert.SerializeObject(data);//序列化,将data转换为json字符串
               //json.toBytes()=>将json字符串转换为字节数组
               msg.PayloadSegment = new ArraySegment<byte>(json.ToBytes());//负载
               //有拓展包的话，   msg.PayloadSegment = new ArraySegment<byte>(data,tojson.ToBytes());就可以了*/


            //将 data 转换为字节数组，并通过 ArraySegment<byte> 赋值给 msg 的 PayloadSegment 属性。
            msg.PayloadSegment = new ArraySegment<byte>(data.ToBytes());
            msg.QualityOfServiceLevel =MQTTnet .Protocol.MqttQualityOfServiceLevel.AtMostOnce;//qs等级//设置消息的服务质量等级（QoS）为 AtMostOnce，即最多一次传递。
            _client.PublishAsync(msg );//使用 _client.PublishAsync(msg) 发布这条消息到 MQTT 代理。

        }
        /// <summary>
        ///  这个方法用于断开与 MQTT 代理的连接。
        /// </summary>
        /// <returns></returns>
        public static Task Disconnect()
        {
            // 调用 _client.DisconnectAsync() 方法，它是 MQTT 客户端对象 _client 的异步断开连接操作。
            //返回一个 Task 对象，表示异步操作的任务，使得调用者可以等待连接断开完成。
            return _client.DisconnectAsync();
        }
        
    }
}

