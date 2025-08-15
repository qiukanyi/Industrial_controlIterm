using ChartCommon;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using DotNetty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChartClient
{
    public  class ClientHelper:SimpleChannelInboundHandler<Command>
    {

        #region 事件
        //事件
        /// <summary>
        /// 连接状态改变事件
        /// </summary>
        public   static    event Action<bool> OnChangeConnected;

        /// <summary>
        /// 当Id发生变化时
        /// </summary>
        public static event Action<int> OnChangeId;
        #endregion

        static ClientHelper()
        {
            RegistHander(CommandType.Set_ID, (cmd) =>
            {
                Id = cmd.SenderId;
            });
        }
     

        #region  属性
        //属性
        private  static  bool _connected=false;
        /// <summary>
        /// 是否已连接
        /// </summary>
        public  static  bool IsConnected
        {
            get => _connected;
           private  set
            {
                _connected = value;
                OnChangeConnected?.Invoke(value);
            }

        }
        private  static  IChannel Channel { get;  set; }

        private  static   MultithreadEventLoopGroup Group { get;  set; }

        private static    readonly   Dictionary<CommandType, List<Action<Command>>> ComandHanders  = new();

        private  static  int _id;

        public  static  int Id {
            get => _id;
            private set 
            {
            
                _id = value;
                OnChangeId?.Invoke(value);
            }
        }
        #endregion


        #region  方法
        ///
        /// <summary>
        /// 注册命令处理器
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="handler"></param>
        public static void RegistHander(CommandType type, Action<Command> hander)
        {
            if (!ComandHanders.ContainsKey(type))
            {
                ComandHanders.Add(type, new List<Action<Command>>());
            }
           ComandHanders[type].Add(hander);
        }





        /// <summary>
        /// 异步连接到服务器
        /// </summary>
        /// <param name="serverIP"></param>
        /// <param name="severPort"></param>
        /// <returns></returns>
        public static Task<bool > ConnetAsync(string serverIP, int severPort)
        { 
            Bootstrap bootstrap = new Bootstrap();
            Group = new MultithreadEventLoopGroup();

            bootstrap 
                .Group(Group)
                .Channel<TcpSocketChannel>()
                .Option(ChannelOption.TcpNodelay, true)
                .Handler(new ActionChannelInitializer<IChannel>(channel =>
                 {
                     var pipeline = channel.Pipeline;
                     pipeline.AddLast(new CommandEncoder ());
                     pipeline.AddLast(new CommandDecoder ());
                     pipeline.AddLast(new ClientHelper  ());
                 }));
            return bootstrap.ConnectAsync(new IPEndPoint(IPAddress.Parse(serverIP), severPort)).ContinueWith(t =>
            {
                if (!t.IsFaulted)
                {
                    Channel = t.Result;
                }
                //修改连接状态
                IsConnected = !t.IsFaulted;
                return IsConnected;
            });
            
        }
        /// <summary>
        /// 断开连接
        /// </summary>
        /// <returns></returns>
        public static Task Discoonect()
        {
            return Channel?.CloseAsync().ContinueWith(t =>
            {
                Group.ShutdownGracefullyAsync(TimeSpan.FromSeconds (2),TimeSpan.FromSeconds(3)).Wait (5000);
                IsConnected = false;
            });
        }
        /// <summary>
        /// 发送命令
        /// </summary>
        /// <param name="type"></param>
        /// <param name="receiverId"></param>
        /// <param name="content"></param>
        public static void SendCommand(CommandType type, int receiverId, string content)
        {
            SendCommand(new  Command()
            {
                Type = type,
                RreceiverId = receiverId,
                Content = content,
                SenderId = Id
            });
            Channel?.WriteAndFlushAsync(content);

        }



        public static void SendCommand(Command Command)
        { 
        Channel?.WriteAndFlushAsync(Command);
        
        }

        protected override void ChannelRead0(IChannelHandlerContext ctx, Command msg)
        {
            if (ComandHanders.TryGetValue(msg.Type, out List<Action<Command>> handlers))
            {
                foreach (var handler in handlers)
                {
                    try
                    {
                        handler(msg);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ex.Message}:{ex.StackTrace}");
                    }
                }
            }
        }


        #endregion





    }
}
