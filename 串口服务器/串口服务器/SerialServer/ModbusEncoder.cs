using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialServer
{
    /// <summary>
    /// 编码器
    /// </summary>
    internal class ModbusEncoder:MessageToByteEncoder<EnvironmentData>
    {
        protected override void Encode(IChannelHandlerContext context, EnvironmentData message, IByteBuffer output)
        {
            throw new NotImplementedException();
        }
    }
}
