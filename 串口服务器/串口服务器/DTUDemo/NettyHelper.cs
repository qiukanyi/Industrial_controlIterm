using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using IChannel = DotNetty.Transport.Channels.IChannel;

namespace DTUDemo
{
    internal class NettyHelper:SimpleChannelInboundHandler<EnvironmentData>
    {
        //用于处理器的消息转发
        public static event Action<EnvironmentData> OnDataReceived;

        private static Dictionary<string,EnvironmentData> data = new Dictionary<string,EnvironmentData>();


        #region 监听客户端连接或断开
        /// <summary>
        /// 告知系统有客户端连接
        /// </summary>
        public static event Action<IChannel> OnChannelConnected;
        /// <summary>
        /// 告知系统有客户端断开
        /// </summary>
        public static event Action<IChannel> OnChannelDisconnected; 
        #endregion


        //管道
        private static IChannel _channel;

        //两个线程池
        private static MultithreadEventLoopGroup _group,_workd;


        #region 监视并返回服务器运行状态
        /// <summary>
        /// 监视并返回服务器运行状态的事件
        /// </summary>
        public static event Action<bool> OnServerStatusChanged;

        //运行状态
        private static bool _isRunning = false;

        public static bool IsRunning
        {
            get => _isRunning;
            set
            {
                if (_isRunning != value)
                {
                    _isRunning = value;
                    OnServerStatusChanged?.Invoke(value);
                }
            }
        } 
        #endregion


        public static Task Static(int port)
        {
            ServerBootstrap bootstrap = new ServerBootstrap();
            bootstrap.Group(_group = new MultithreadEventLoopGroup(), _workd = new MultithreadEventLoopGroup())
                .Channel<TcpServerSocketChannel>()
                .ChildHandler(new ActionChannelInitializer<IChannel>(channel =>
                {
                    IChannelPipeline pipeline = channel.Pipeline;
                    pipeline.AddLast(new ModbusTcpDecode("2405"));
                    pipeline.AddLast(new NettyHelper());
                }));
            return bootstrap.BindAsync(port).ContinueWith(t =>
            {
                _channel = t.Result;
                IsRunning = true;
            });
        }

        public static Task Stop()
        {
            return _channel?.CloseAsync().ContinueWith(t =>
            {
                Task.WhenAll(_group?.ShutdownGracefullyAsync(TimeSpan.FromSeconds(2),TimeSpan.FromSeconds(3)),
                _workd?.ShutdownGracefullyAsync(TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(3))).Wait();
                IsRunning = false;

            });
        }

        protected override void ChannelRead0(IChannelHandlerContext ctx, EnvironmentData msg)
        {
            //做一个转发
            OnDataReceived?.Invoke(msg);
        }

        #region 重写监听客户端连接和断开的方法
        public override void ChannelActive(IChannelHandlerContext context)
        {
            OnChannelConnected?.Invoke(context.Channel);
        }

        public override void ChannelInactive(IChannelHandlerContext context)
        {
            OnChannelDisconnected?.Invoke(context.Channel);
        }

        #endregion



    }
}
