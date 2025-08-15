using DotNetty.Codecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetty.Transport.Channels;
using DotNetty.Buffers;

namespace ChartCommon
{
    /// <summary>
    /// 编码器
    /// </summary>
    public class CommandEncoder : MessageToByteEncoder<Command>
    {


        protected override void Encode(IChannelHandlerContext context, Command message, IByteBuffer output)
        {
            int bytesLength = 9 + (string .IsNullOrEmpty (message .Content ) ?0:Encoding.UTF8.GetBytes(message.Content) .Length);
            output.WriteInt(bytesLength);//消息长度
            output.WriteByte((byte)message.Type);
            output.WriteInt(message.RreceiverId );
            output.WriteInt(message.SenderId);
            if (!string.IsNullOrEmpty(message.Content))
            {
                output.WriteString(message.Content, Encoding.UTF8);
            }

        }
    }
}
