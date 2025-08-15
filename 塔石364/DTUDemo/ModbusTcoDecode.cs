using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using HmExtension.Commons.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTUDemo
{
    public class ModbusTcpDecode : ByteToMessageDecoder

    {
        public static Dictionary<IChannel, string> devices = new();


        private readonly byte[] deviceId;

        private readonly Encoding encoding;
        public ModbusTcpDecode(string deviceId,Encoding encoding=default )
        {
            this. deviceId = deviceId.ToBytes(encoding);
            this .encoding=encoding;
        }
        protected override void Decode(IChannelHandlerContext context, IByteBuffer input, List<object> output)
        {
/*
            if (input.ReadableBytes >= deviceId.Length)
            { 
            byte[]buff = new byte[deviceId.Length];
            input.GetBytes(0,buff);
            if (buff.SequenceEqual(deviceId))
            {
                    input.SkipBytes(buff.Length);
                    devices[context.Channel] = buff.FromString(encoding);
                    return;
            }
*/

            byte[] buff =new byte[input .ReadableBytes];
            input.GetBytes(0,buff);
            buff.ToHexString("").Println();

            if (input.ReadableBytes < 6+deviceId .Length )
            {
                return;

            }
            var length = input.GetUnsignedShort(4 + deviceId.Length);
            if (input.ReadableBytes < length + 6+deviceId.Length)
            { 
            return ;
            }
           
            //读设备id
            byte[] data = new byte[deviceId.Length];

        
            input .ReadBytes(data);

            string Deviceid = data.FromString(encoding);
            //02 03 06
            data =new byte[length-3];
            input.SkipBytes (9);
            input.ReadBytes(data);
          
                output.Add(new EnvironmentData()
                {
                Deviceid = Deviceid ,
                Humidity = data.Take(2).Reverse().ToUShort() / 10D,
                Temperature = data.Skip(2).Take(2).Reverse().ToUShort() / 10D,
                Light  = data.Skip(4).Take(2).Reverse().ToUShort(),

            });


        }
    }
}
