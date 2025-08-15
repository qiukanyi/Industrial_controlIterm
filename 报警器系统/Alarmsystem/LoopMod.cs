using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alarmsystem
{/// <summary>
/// 循环模式枚举
/// </summary>
    public  enum  LoopMod
    {
        //全盘循环(00)：按顺序播放全盘曲目, 播放完后循环播放
        全盘循环 = 0,
        //单曲循环(01)：一直循环播放当前曲目
        单曲循环 = 1,
        //单曲停止(02)：播放完当前曲目一次停止
        单曲停止 = 2,
        //全盘随机(03)：随机播放盘符内曲目
        全盘随机 = 3,
        //目录循环(04)：按顺序播放当前文件夹内曲目, 播放完后循环播放，目录不包含子目录。 
        目录循环 = 4,
        //目录随机(05)：在当前目录内随机播放，目录不包含子目录
        目录随机 = 5,
        //目录顺序播放(06)：按顺序播放当前文件夹内曲目, 播放完后停止，目录不包含子目录
        目录顺序播放 = 6,
        //顺序播放(07)：按顺序播放全盘曲目, 播放完后停止
        顺序播放 = 7,

    }
}
