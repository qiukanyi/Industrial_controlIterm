using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using HmExtension.Commons.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTUDemo
{
    /// <summary>
    /// 解码器
    /// </summary>
    internal class ModbusTcpDecode:ByteToMessageDecoder
    {
        //定义一个静态的字典，用于存储IChannel和设备ID字符串的映射
        public static Dictionary<IChannel, string> devices = new Dictionary<IChannel, string>();

        //用于存储设备ID的字节数组
        private readonly byte[] deciveId;

        /*
         * 这是一个用于字符编码转换的Encoding对象
         * 对象提供了将字符(字符串)转换为字节序列（编码）
         * 和将字节序列转换回字符（解码）的方法
        */
        private readonly Encoding encoding;

        //接受一个字符串deciveId和一个可选的Encoding对象encoding（默认为系统默认编码）
        public ModbusTcpDecode (string deciveId, Encoding encoding = default)
        {
            //将deciveId转换为字节数组，并存储在this.deciveId字段中
            this.deciveId = deciveId.ToBytes(encoding);
            this.encoding = encoding;
        }

        protected override void Decode(IChannelHandlerContext context, IByteBuffer input, List<object> output)
        {
            #region 废弃代码
            //匹配设备Id
            /*if(input.ReadableBytes >= this.deciveId.Length)
                {
                    byte[] buff = new byte[this.deciveId.Length];
                    input.GetBytes(0, buff);
                    if (buff.SequenceEqual(this.deciveId))
                    {
                        input.SkipBytes(buff.Length);
                        devices[context.Channel] = buff.FromString(encoding);
                        return;
                    }
                }*/
            #endregion

            byte[] buff = new byte[input.ReadableBytes];
            input.GetBytes(0, buff);
            buff.ToHexString("").Println();

            /*
              * Modbus TCP进行传输
              * 00 00  | 00 00 | 00 09    | 02 03 06 02 5A 01 12 00 21
              * 事务ID | 协议  | 数据长度 | 数据
             */
            if (input.ReadableBytes < 6 + deciveId.Length) return;
            var length = input.GetUnsignedShort(4 + deciveId.Length);
            if (input.ReadableBytes < length + 6 + deciveId.Length) return;

            //读设备ID
            byte[] data = new byte[deciveId.Length];
            input.ReadBytes(data);
            string DeciveId = data.FromString(encoding);

            data = new byte[length - 3];//02 03 06
            input.SkipBytes(9);
            input.ReadBytes(data);

            output.Add(new EnvironmentData()
            {
                DeviceId = DeciveId,
                Humidity = data.Take(2).Reverse().ToUShort() / 10D,
                Temperature = data.Skip(2).Take(2).Reverse().ToUShort() / 10D,
                Light = data.Skip(4).Take(2).Reverse().ToUShort()
            });

        }

    }
}
