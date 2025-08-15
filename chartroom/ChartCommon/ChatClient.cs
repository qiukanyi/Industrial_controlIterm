using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using DotNetty.Transport.Channels;


namespace ChartCommon
{

    /// <summary>
    /// 客户端对象
    /// </summary>
    public  class ChatClient
    {
        //
        public int Id { get; }=Guid .NewGuid ().GetHashCode ();
        public string NickName { get;  set; }
        public string IpAddress=>((IPEndPoint )Channel .RemoteAddress ).Address.MapToIPv4 (). ToString ();
        public int port => ((IPEndPoint)Channel.RemoteAddress).Port ;
        public event Action OnDisconnected;
        public readonly DotNetty.Transport.Channels.IChannel Channel;
        public ChatClient(DotNetty.Transport.Channels.IChannel channel)
        {
            Channel = channel;
        }
        public void SendMessage(CommandType type, int receverId, string content)
        {
            Command command = new()
            {
                Type = type,
                RreceiverId = receverId,
                Content = content,
                SenderId = Id
            };
            Channel .WriteAndFlushAsync(command);
        }
        public void SendMessage(Command command)
        {
            Channel.WriteAndFlushAsync(command);

        }

        /// <summary>
        /// 分发断开连接事件
        /// </summary>
        public void DipatcherDisconnect()
        {
            OnDisconnected?.Invoke();   
        }
    }
}
