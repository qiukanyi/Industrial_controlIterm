using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartCommon
{
    /// <summary>
    /// 解码器
    /// </summary>
    public class CommandDecoder:ByteToMessageDecoder 
    {
        protected override void Decode(IChannelHandlerContext context, IByteBuffer input, List<object> output)//这是重写了ByteToMessageDecoder 中的很多方法，我也不太清楚，只知道功能，用反编译康康？
        {

            //解决粘包  半包问题
            //解析数据长度和检查可读字节数：
            if (input.ReadableBytes < 4)//这段代码首先检查input中是否至少有4个字节可读，因为一般情况下，前4个字节表示数据的长度。如果可读字节数小于4，说明无法读取完整的数据长度信息，直接返回。
            {
                return;//？为什么有时候是4有时候是3：如何去判断呢：看通信协议中的可读字节数（固定字节）/看文档
            }
            //get
            //read
            int length = input.GetInt(0);//如果可读数组足够，则从第0个位置读取一个整数作为数据长度length
            //检查数据长度
            if (input.ReadableBytes < length + 4)//如果可读字节数小于数据长度加4，说明数据包还没接收完整，直接返回。
            { 
            return;
            }
            //读取数据
            input.SkipBytes(4);//跳过前4个字节，因为前4个字节这些字节是用来表示数据长度的，因为接下来需要读取真正的数据内容。
            byte type=input.ReadByte();//读取一个字节作为消息类型
            int  receiveId=input.ReadInt();//读取两个字节作为接收者id
            int senderId=input.ReadInt();//读取两个字节作为发送者id//？这些都是按顺序读取的，所以格式应该是自己固定的
            //根据前面读取的数据长度length，
            //减去长度字段本身所占的4个字节
            //以及后续的一个type字节和两个int字节（共9个字节），
            //得到实际数据内容的长度。//也就是发送的消息内容的长度。
            byte[] data=new byte[length - 9];
            input.ReadBytes(data);//读取内容
            //判断data数组的长度，如果为0，则content为null，
            //否则将data数组中的字节数据使用UTF-8编码转换成字符串。
            string content =data.Length ==0?null:Encoding.UTF8.GetString(data);//为什么要转？因为内容要字符串呐
            //根据从数据中解析出的type、receiveId、senderId和content
            //构造一个Command对象。//则就是我们command里面的属性
            Command command = new()
            { 
            Type=(CommandType)type,
            RreceiverId =receiveId,
            SenderId=senderId,
            Content=content
            };
            output.Add(command);// 将构造好的Command对象添加到output集合中，以便后续处理或者输出。//也就是上面的List<object> output

        }

        }
    }

