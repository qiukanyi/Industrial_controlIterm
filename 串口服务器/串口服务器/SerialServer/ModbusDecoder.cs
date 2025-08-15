using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using HmExtension.Commons.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialServer
{
    /// <summary>
    /// RTU解码器
    /// </summary>
    internal class ModbusRtuDecoder : ByteToMessageDecoder
    {
        protected override void Decode(IChannelHandlerContext context, IByteBuffer input, List<object> output)
        {
            /*
             * Modbus读保持寄存器后，响应的数据结构
             * 从站地址（1 byte），功能码(1)，数据长度(1)，数据(n)，CRC校验(2)
             */

            //要检查数据是否完整，最少需要3个字节
            if(input.ReadableBytes < 3)
            {
                return;
            }
            //得到第3个字节，即数据长度
            int length = input.GetByte(2);
            //5 => 从站地址+功能码+数据长度+CRC校验
            if(input.ReadableBytes < length + 5)
            {
                return;
            }
            //读取数据
            input.SkipBytes(3);
            byte[] data = new byte[length];
            input.ReadBytes(data);
            input.SkipBytes(2);//跳过CRC校验

            //解析数据
            output.Add(new EnvironmentData
            {
                Humidity = data.Take(2).Reverse().ToUShort() / 10D,
                Temperature = data.Skip(2).Take(2).Reverse().ToUShort() / 10D,
                Light = data.Skip(4).Take(2).Reverse().ToUShort()
            });
        }

    }

    
    /// <summary>
    /// TCP解码器
    /// </summary>
    internal class ModbusTcpDecoder : ByteToMessageDecoder
    {
        protected override void Decode(IChannelHandlerContext context, IByteBuffer input, List<object> output)
        {
            /*
              * Modbus TCP进行传输
              * 00 00  | 00 00 | 00 09    | 02 03 06 02 5A 01 12 00 21
              * 事务ID | 协议  | 数据长度 | 数据
             */
            if (input.ReadableBytes < 6) return;
            var length = input.GetUnsignedShort(4);
            if (input.ReadableBytes < length + 6) return;

            //读取数据
            byte[] data = new byte[length - 3];
            input.SkipBytes(9);
            input.ReadBytes(data);

            //解析数据
            output.Add(new EnvironmentData
            {
                Humidity = data.Take(2).Reverse().ToUShort() / 10D,
                Temperature = data.Skip(2).Take(2).Reverse().ToUShort() / 10D,
                Light = data.Skip(4).Take(2).Reverse().ToUShort()
            });
        }

    }





}
