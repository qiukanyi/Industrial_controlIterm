using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartCommon
{
    public  class Command
    {
        /// <summary>
        /// 命令类型
        /// </summary>
        public CommandType Type { get;set ; }

        /// <summary>
        /// 接收者ID
        /// </summary>
        public int RreceiverId { get; set; }
        /// <summary>
        /// 发送者ID
        /// </summary>
        public int SenderId { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
    }
    public enum CommandType 
    {
       Set_Nick_Name,
       Set_ID,
       Set_On_Line,
       Set_Off_Line,
       Send_Message,
       Receiver_Message,
    }



    //昵称
    //私聊，群聊，系统消息
    //文字，   （//图片，文件，音频）
}
