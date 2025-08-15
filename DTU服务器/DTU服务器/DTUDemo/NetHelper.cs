using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
//using DotNetty.Transport.Channels;

namespace DTUDemo;  

    public  class NetHelper:SimpleChannelInboundHandler<EnvironmentData>
    {

    public static event Action<bool> OnServerStatesChanged;
    public static event Action<EnvironmentData> OnDataReceived;
    public static event Action<IChannel> OnChannelConnected;
    public static event Action<IChannel> OnChannelDisconnected;
    private static Dictionary<string, EnvironmentData> _data = new();
    public static IChannel _channel;
    public static MultithreadEventLoopGroup _group,_workd; 

    public static bool _isRunning=false;
    public static bool IsRunning {
     get => _isRunning;
        set 
        {
            if (_isRunning !=value)
            {
                _isRunning = value;
                OnServerStatesChanged?.Invoke(value);
            
            }
        }
    }

    
    public static Task Start(int port)
    {
        ServerBootstrap bootstrap = new ServerBootstrap();
        bootstrap.Group(_group = new MultithreadEventLoopGroup(), _workd = new MultithreadEventLoopGroup())
            .Channel<TcpServerSocketChannel>()
            .ChildHandler(new ActionChannelInitializer<IChannel>(channel => 
            {
                IChannelPipeline pipeline = channel.Pipeline;
                //1.编码器
                //2.解码器
                pipeline.AddLast(new ModbusTcpDecode("2405"));
                //3.处理器
                pipeline.AddLast(new NetHelper());

            }));
        return bootstrap.BindAsync(port).ContinueWith(t => 
        {
            _channel=t.Result;
            IsRunning = true;
        });
    }
    public static Task Stop()
    {
        return _channel?.CloseAsync().ContinueWith(t => 
        {
            Task.WhenAll(_group.ShutdownGracefullyAsync(TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(3)),
             _workd?.ShutdownGracefullyAsync(TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(3))).Wait();            
            IsRunning = false;
        });
    }

    protected override void ChannelRead0(IChannelHandlerContext ctx, EnvironmentData msg)
    {
        OnDataReceived?.Invoke(msg);
    }


    public override void ChannelActive(IChannelHandlerContext context)
    {
        OnChannelConnected?.Invoke(context.Channel);
    }
    public override void ChannelInactive(IChannelHandlerContext context)
    {
       OnChannelDisconnected?.Invoke(context.Channel);
    }

}

