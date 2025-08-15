using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
 

namespace DTUDemo
{
    /// <summary>
    /// 服务
    /// </summary>
    public class NetHelper : SimpleChannelInboundHandler<EnvironmentData>
    {
        public static event  Action<bool> OnServerStatusChanged;

        public static event Action<EnvironmentData> OnDataReceived;

        //有客户端进来
        public static event Action<IChannel> OnchannelConnected;
        //有客户端断开
        public static event Action <IChannel> OnchannelDisconnected;
        private static Dictionary<string, EnvironmentData> _data = new();


        private static IChannel _channel;

        private static MultithreadEventLoopGroup _group, _worked;


        private static bool _isRuning = false;


        public static bool IsRuning
        {
            get => _isRuning;
            set {
                if (_isRuning != value)
                {
                    _isRuning = value;
                    OnServerStatusChanged?.Invoke(value);
                }
            }
        }



        public static Task Start(int port)
        {
            ServerBootstrap bootstrap = new ServerBootstrap();
            bootstrap.Group(_group = new MultithreadEventLoopGroup(), _worked = new MultithreadEventLoopGroup())
                   .Channel<TcpServerSocketChannel>()
                   .ChildHandler(new ActionChannelInitializer<ISocketChannel>(channel =>
                   {
                       IChannelPipeline pipeline = channel.Pipeline;
                       pipeline.AddLast(new JesonDecode ());
                       pipeline.AddLast(new NetHelper());
                       //编码器
                       //解码器
                       //处理器


                   }));
            return bootstrap.BindAsync(port).ContinueWith(t =>
              {
                  _channel = t.Result;
                  IsRuning = true;
              });


        }
        public static Task Stop()
        {
            return _channel?.CloseAsync().ContinueWith(t =>
            {
                Task.WhenAll(_group.ShutdownGracefullyAsync(TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(3)),
                      _worked.ShutdownGracefullyAsync(TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(3)));
               
                       IsRuning = false;
            
            });
        }
    
        



        protected override void ChannelRead0(IChannelHandlerContext ctx, EnvironmentData msg)
        {
            OnDataReceived?.Invoke(msg);
        }

        public  override void ChannelActive(IChannelHandlerContext ctx)
        {
                OnchannelConnected?.Invoke(ctx.Channel);
        }

        public  override void ChannelInactive(IChannelHandlerContext ctx)
        {
            OnchannelDisconnected?.Invoke(ctx.Channel);
        }
    }
}
