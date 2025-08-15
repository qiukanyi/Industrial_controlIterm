namespace ChartClient
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ipTb = new AntdUI.Input();
            this.portTb = new AntdUI.InputNumber();
            this.nickNameTb = new AntdUI.Input();
            this.button1 = new AntdUI.Button();
            this.panel1 = new AntdUI.Panel();
            this.broadcastCb = new AntdUI.Checkbox();
            this.button2 = new AntdUI.Button();
            this.MessageTb = new AntdUI.Input();
            this.historyList = new AntdUI.Chat.ChatList();
            this.msgList1 = new AntdUI.Chat.MsgList();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ipTb
            // 
            this.ipTb.Location = new System.Drawing.Point(25, 22);
            this.ipTb.Name = "ipTb";
            this.ipTb.PlaceholderText = "";
            this.ipTb.PrefixText = "服务器ip:";
            this.ipTb.Size = new System.Drawing.Size(198, 53);
            this.ipTb.TabIndex = 0;
            this.ipTb.Text = "127.0.0.1";
            // 
            // portTb
            // 
            this.portTb.Location = new System.Drawing.Point(239, 22);
            this.portTb.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.portTb.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.portTb.Name = "portTb";
            this.portTb.PrefixText = "端口：";
            this.portTb.Size = new System.Drawing.Size(200, 53);
            this.portTb.TabIndex = 1;
            this.portTb.Text = "8000";
            this.portTb.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            // 
            // nickNameTb
            // 
            this.nickNameTb.Location = new System.Drawing.Point(455, 22);
            this.nickNameTb.Name = "nickNameTb";
            this.nickNameTb.PrefixText = "昵称：";
            this.nickNameTb.Size = new System.Drawing.Size(166, 53);
            this.nickNameTb.TabIndex = 2;
            this.nickNameTb.Text = "张三";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(636, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 53);
            this.button1.TabIndex = 3;
            this.button1.Text = "连接";
            this.button1.Type = AntdUI.TTypeMini.Primary;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.broadcastCb);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.MessageTb);
            this.panel1.Controls.Add(this.historyList);
            this.panel1.Controls.Add(this.msgList1);
            this.panel1.Controls.Add(this.portTb);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.ipTb);
            this.panel1.Controls.Add(this.nickNameTb);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(783, 683);
            this.panel1.TabIndex = 4;
            this.panel1.Text = "panel1";
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // broadcastCb
            // 
            this.broadcastCb.Checked = true;
            this.broadcastCb.Location = new System.Drawing.Point(583, 639);
            this.broadcastCb.Name = "broadcastCb";
            this.broadcastCb.Size = new System.Drawing.Size(63, 38);
            this.broadcastCb.TabIndex = 8;
            this.broadcastCb.Text = "群发";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(652, 633);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 47);
            this.button2.TabIndex = 7;
            this.button2.Text = "发送";
            this.button2.Type = AntdUI.TTypeMini.Primary;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MessageTb
            // 
            this.MessageTb.Location = new System.Drawing.Point(328, 480);
            this.MessageTb.Multiline = true;
            this.MessageTb.Name = "MessageTb";
            this.MessageTb.PlaceholderText = "请输入消息：";
            this.MessageTb.PrefixText = "";
            this.MessageTb.Size = new System.Drawing.Size(440, 147);
            this.MessageTb.TabIndex = 6;
            // 
            // historyList
            // 
            this.historyList.Location = new System.Drawing.Point(328, 82);
            this.historyList.Name = "historyList";
            this.historyList.Size = new System.Drawing.Size(440, 378);
            this.historyList.TabIndex = 5;
            this.historyList.Text = "chatList1";
            // 
            // msgList1
            // 
            this.msgList1.Location = new System.Drawing.Point(12, 81);
            this.msgList1.Name = "msgList1";
            this.msgList1.Size = new System.Drawing.Size(298, 590);
            this.msgList1.TabIndex = 4;
            this.msgList1.Text = "msgList1";
            // 
            // Form1
            // 
            this.AcceptButton = this.button2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 683);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.Input ipTb;
        private AntdUI.InputNumber portTb;
        private AntdUI.Input nickNameTb;
        private AntdUI.Button button1;
        private AntdUI.Panel panel1;
        private AntdUI.Chat.MsgList msgList1;
        private AntdUI.Button button2;
        private AntdUI.Input MessageTb;
        private AntdUI.Chat.ChatList historyList;
        private AntdUI.Checkbox broadcastCb;
    }
}

