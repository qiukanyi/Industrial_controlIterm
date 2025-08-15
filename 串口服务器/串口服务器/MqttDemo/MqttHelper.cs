using HmExtension.Commons.Extensions;
using MQTTnet;
using MQTTnet.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MqttDemo
{
    internal class MqttHelper
    {
        #region 连接
        private static IMqttClient _client;

        public static event Action<EnvironmentData> OnDataReceived;

        public static event Action<MqttClientOptions> OnConnecting;

        public static event Action<MqttClientConnectResult> OnConnected;


        public static Task<string> Connect(string host, int port, string username, string password, string clientId = null)
        {
            _client = new MqttFactory().CreateMqttClient();
            var options = new MqttClientOptionsBuilder()
                .WithTcpServer(host, port)
                .WithCredentials(username, password)
                .WithClientId(clientId ?? Guid.NewGuid().ToString())
                .WithTlsOptions(new MqttClientTlsOptions()
                {
                    UseTls = false//关闭SSL加密
                }).Build();

            _client.ApplicationMessageReceivedAsync += e =>
            {
                //得到接收到的消息对象
                var msg = e.ApplicationMessage;
                //从消息对象中得到传递的数据
                var payload = msg.PayloadSegment;
                //将得到的数据转换为字符串
                var json = payload.ToArray().FromString(Encoding.Default);
                //由于字符串是json格式的，所以我们可以将其转换为对象
                OnDataReceived?.Invoke(json.FromJson<EnvironmentData>());
                return Task.CompletedTask;//告诉MQTT服务器，我已经接收到数据了
            };

            _client.ConnectingAsync += e =>
            {
                OnConnecting?.Invoke(e.ClientOptions);
                return Task.CompletedTask;
            };

            _client.ConnectedAsync += e =>
            {
                OnConnected?.Invoke(e.ConnectResult);
                return Task.CompletedTask;
            };

            return _client.ConnectAsync(options).ContinueWith(t => t.Result.AssignedClientIdentifier);
        }

        public static Task<MqttClientSubscribeResult> SubscribeAsync(string topic)
        {
            var options = new MqttClientSubscribeOptionsBuilder()
                .WithTopicFilter(topic)
                .Build();
            return _client.SubscribeAsync(options);

        }

        public static void Push(string topic,string data)
        {
            var msg = new MqttApplicationMessage();
            msg.Topic = topic;

            //var json = JsonConvert.SerializeObject(data);
            msg.PayloadSegment = new ArraySegment<byte>(data.ToBytes());//负载
            msg.QualityOfServiceLevel = MQTTnet.Protocol.MqttQualityOfServiceLevel.AtMostOnce;
            
            _client.PublishAsync(msg);
        }

        #endregion

        //断开连接
        public static Task Disconnect()
        {
            return _client.DisconnectAsync();
        }




    }
}
