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
    public class JesonDecode : ByteToMessageDecoder
    {
        protected override void Decode(IChannelHandlerContext context, IByteBuffer input, List<object> output)
        {
            //传jeson的话其实判断不了长度了，因为json的格式不好判断，只能通过结尾的}来判断
            //所以这里来多少接多少
            byte[]bytes = new byte[input.ReadableBytes];
            input = input.ReadBytes(bytes);
            var json = bytes.FromString(Encoding.Default);
            //转换成对象
            //Text,json
            //Nowtinsoft.Json//俩个模块都可以用//自己下载，或者虹猫的拓展包里面也有
            //如果用了虹猫拓展包就不用这个也可以var data=Newtonsoft.Json.JsonConvert.DeserializeObject<EnvironmentData>(json);
            output.Add(json.FromJson<EnvironmentData>());

        }
        //其实可以用udp但是数据传输顺序无法保障
        //如果设置设备不主动采集的话，那么就得自己主动发送数据了
        //具体是用tcp还是udp还是其他协看你有没有开启数据转换
        //很可能会问（补）


    }
}
