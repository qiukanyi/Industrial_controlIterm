using ChartCommon;
using DotNetty.Transport.Channels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HmExtension.Standard.Extensions;
namespace ChartSever
{
    /// <summary>
    /// 处理器
    /// </summary>
    public class ServerHandler : SimpleChannelInboundHandler<Command>
    {
        public static event Action<ChatClient> OnClientConnected;
        public static event Action<ChatClient> OnClientDisConnected;

        public static readonly Dictionary<IChannel, ChatClient> Client = new();

        public static void RegisterHandler(CommandType type, Action<ChatClient, Command> handler)
        {
            if (!CommandHandlers.ContainsKey(type))
            {
                CommandHandlers.Add(type, new List<Action<ChatClient, Command>>());
            }
            CommandHandlers[type].Add(handler);

        }
        //命名处理器
        public static readonly Dictionary<CommandType, List<Action<ChatClient, Command>>> CommandHandlers = new();
        protected override void ChannelRead0(IChannelHandlerContext ctx, Command msg)
        {
            if (Client.TryGetValue(ctx.Channel, out ChatClient client))
            {
                if (CommandHandlers.TryGetValue(msg.Type, out List<Action<ChatClient, Command>> handlers))
                {
                    foreach (var handler in handlers)
                    {
                        handler(client, msg);
                    }
                }
            }
            msg.FormatPatten("Typ:{Type}Rec:{RreceiverId}Sen:{SenderId}Con:{Content}").Println("接收到的数据");
        }

    
        //客户端连接
        public override void ChannelActive(IChannelHandlerContext context)
        {
            ChatClient client = new ChatClient(context.Channel);
            Client .Add(context.Channel, client);
            OnClientConnected?.Invoke(client);
            //?
            client.SendMessage(CommandType.Set_ID, 0, null);
        }
        //客户端断开连接
        public override void ChannelInactive(IChannelHandlerContext context)
        {
          if(Client .TryGetValue (context.Channel,out ChatClient client))
          {
              Client.Remove(context.Channel);
              OnClientDisConnected?.Invoke(client);
              client.DipatcherDisconnect ();
          }
        }
    }
}
