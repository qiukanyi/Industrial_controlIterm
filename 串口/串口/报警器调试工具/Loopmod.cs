using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 报警器调试工具;

/// <summary>
/// 循环模式 
/// </summary>
    public enum Loopmode 
    {
    /// <summary>全盘循环（00）：按顺序播放全部曲目</summary>
    全盘循环 = 0,
    /// <summary>单曲循环（01）：一直播放当前曲目</summary>
    单曲循环 = 1,
    /// <summary>单曲停止（02）</summary>
    单曲停止 = 2,
    /// <summary>全盘随机（03）</summary>
    全盘随机 = 3,
    /// <summary>目录循环（04）</summary>
    目录循环 = 4,
    /// <summary>目录随机</summary>
    目录随机 = 5,
    /// <summary>目录顺序播放</summary>
    目录顺序播放 = 6,
    /// <summary>顺序播放</summary>
     顺序播放 = 7 
}

