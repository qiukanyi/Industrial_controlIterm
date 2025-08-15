using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SerialServer
{
    internal class NettyHelper
    {
        //连接状态发生改变的事件
        public static event Action<bool> OnConnectChanged;

        //连接状态
        private static bool isConnected = false;

        //当连接状态发生改变时，自动触发事件
        public static bool IsConnected
        {
            get => isConnected;
            set
            {
                if(isConnected != value)
                {
                    isConnected = value;
                    OnConnectChanged?.Invoke(isConnected);
                }
            }
        }
        //多线程池
        private static MultithreadEventLoopGroup group;

        //通信管道
        private static IChannel channel;

        /// <summary>
        /// 连接
        /// </summary>
        /// <param name="ip">串口服务器IP地址</param>
        /// <param name="port">串口服务器端口</param>
        /// <param name="handler">环境对象</param>
        /// <returns></returns>
        public static Task Start(string ip, int port,Action<EnvironmentData> handler)
        {
            //bootstrap 是一个 Bootstrap 类的实例，它用于客户端应用程序的启动配置
            var bootstrap = new Bootstrap();
            //group 是一个 MultithreadEventLoopGroup 类的实例,用于创建多个线程来处理事件
            group = new MultithreadEventLoopGroup();
            //配置 Bootstrap
            bootstrap.Group(group)
                //指定通道类型，这里是以TCP方式运行
                .Channel<TcpSocketChannel>()
                //设置 TCP 参数，这里用了TCP_NODELAY选项，禁用Nagle算法，确保数据立即发送。
                .Option(ChannelOption.TcpNodelay, true)
                //给通道添加自定义的处理器
                .Handler(new ActionChannelInitializer<ISocketChannel>(channel =>
                {
                    IChannelPipeline pipeline = channel.Pipeline;
                    pipeline.AddLast(new ModbusEncoder());
                    pipeline.AddLast(new ModbusRtuDecoder());
                    pipeline.AddLast(new EnvironmentDataHandler(handler));
                }));

            //进行网络连接
            return bootstrap.ConnectAsync(new IPEndPoint(IPAddress.Parse(ip), port)).ContinueWith(t =>
            {
                channel = t.Result;
                IsConnected = !t.IsFaulted;
            });
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <returns></returns>
        public static Task Stop()
        {
            return channel?.CloseAsync().ContinueWith(t =>
            {
                group?.ShutdownGracefullyAsync
                (TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(3));
                IsConnected = false;
            });
        }

    }

    internal class EnvironmentDataHandler : SimpleChannelInboundHandler<EnvironmentData>
    {
        readonly Action<EnvironmentData> _onDataReceived;

        public EnvironmentDataHandler(Action<EnvironmentData> onDataReceived)
        {
            _onDataReceived = onDataReceived;
        }

        protected override void ChannelRead0(IChannelHandlerContext ctx, EnvironmentData msg)
        {
            _onDataReceived?.Invoke(msg);
        }
    }

}
