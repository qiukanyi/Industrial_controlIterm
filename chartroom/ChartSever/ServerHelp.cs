using ChartCommon;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartSever
{
    public   class ServerHelp
    {

        public  static List <ChatClient >Clients => ServerHandler.Client.Values.ToList();
        public  static  Task <IChannel> Start( int  port)
        {
            ServerBootstrap bootstarp = new ServerBootstrap();
            bootstarp.Group(new MultithreadEventLoopGroup())
                    .Channel<TcpServerSocketChannel>()//以tcp方式进行通信
                    .ChildHandler(new ActionChannelInitializer<ISocketChannel>(channel =>
                    {
                        IChannelPipeline pipeline = channel.Pipeline;//获取管道
                        //管道作用：处理数据流
                        pipeline.AddLast(new CommandDecoder());//添加自定义的处理器
                        pipeline.AddLast(new CommandEncoder());//添加自定义的处理器
                        pipeline.AddLast(new ServerHandler());//业务器
                    }));
            //绑定端口
            return bootstarp.BindAsync(port);
     
           
        }
        /// <summary>
        /// 广播消息
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="filter"></param>
        public static void Broadcast(Command cmd,Func <ChatClient ,bool >filter)

        {
          var clients =  ServerHandler.Client.Values.Where(filter).ToList();
            foreach (var client in clients)
            {           
            client .SendMessage (cmd);
            }
        }
        /// <summary>
        /// 发送消息给指定的客户端
        /// </summary>
        /// <param name="clienId"></param>
        /// <param name="cmd"></param>
        public static void SendMessage(int clienId, Command cmd)
        {
          var client=Clients .FirstOrDefault (client => client.Id == clienId);
            if (client!= null)
            {
                client.SendMessage(cmd);
            }
        
        }

    }
}
