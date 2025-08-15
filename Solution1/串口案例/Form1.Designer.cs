namespace 串口案例
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.byteRb = new System.Windows.Forms.RadioButton();
            this.hexRb = new System.Windows.Forms.RadioButton();
            this.stringRb = new System.Windows.Forms.RadioButton();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.stopBitesCb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ParityCb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateBitesCb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.baudRateCb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.portNameCb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.historyTb = new System.Windows.Forms.TextBox();
            this.sendMsgTb = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 441);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(313, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "打开串口";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.byteRb);
            this.groupBox1.Controls.Add(this.hexRb);
            this.groupBox1.Controls.Add(this.stringRb);
            this.groupBox1.Location = new System.Drawing.Point(17, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(320, 105);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据显示格式";
            // 
            // byteRb
            // 
            this.byteRb.AutoSize = true;
            this.byteRb.Location = new System.Drawing.Point(197, 52);
            this.byteRb.Margin = new System.Windows.Forms.Padding(4);
            this.byteRb.Name = "byteRb";
            this.byteRb.Size = new System.Drawing.Size(58, 19);
            this.byteRb.TabIndex = 0;
            this.byteRb.TabStop = true;
            this.byteRb.Text = "字节";
            this.byteRb.UseVisualStyleBackColor = true;
            this.byteRb.CheckedChanged += new System.EventHandler(this.byteRb_CheckedChanged);
            // 
            // hexRb
            // 
            this.hexRb.AutoSize = true;
            this.hexRb.Location = new System.Drawing.Point(111, 52);
            this.hexRb.Margin = new System.Windows.Forms.Padding(4);
            this.hexRb.Name = "hexRb";
            this.hexRb.Size = new System.Drawing.Size(74, 19);
            this.hexRb.TabIndex = 0;
            this.hexRb.TabStop = true;
            this.hexRb.Text = "16进制";
            this.hexRb.UseVisualStyleBackColor = true;
            this.hexRb.CheckedChanged += new System.EventHandler(this.hexRb_CheckedChanged);
            // 
            // stringRb
            // 
            this.stringRb.AutoSize = true;
            this.stringRb.Location = new System.Drawing.Point(24, 52);
            this.stringRb.Margin = new System.Windows.Forms.Padding(4);
            this.stringRb.Name = "stringRb";
            this.stringRb.Size = new System.Drawing.Size(73, 19);
            this.stringRb.TabIndex = 0;
            this.stringRb.TabStop = true;
            this.stringRb.Text = "字符串";
            this.stringRb.UseVisualStyleBackColor = true;
            this.stringRb.CheckedChanged += new System.EventHandler(this.stringRb_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.stopBitesCb);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.ParityCb);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dateBitesCb);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.baudRateCb);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.portNameCb);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(17, 142);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(320, 498);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "连接参数";
            // 
            // stopBitesCb
            // 
            this.stopBitesCb.FormattingEnabled = true;
            this.stopBitesCb.Location = new System.Drawing.Point(73, 394);
            this.stopBitesCb.Margin = new System.Windows.Forms.Padding(4);
            this.stopBitesCb.Name = "stopBitesCb";
            this.stopBitesCb.Size = new System.Drawing.Size(204, 23);
            this.stopBitesCb.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 395);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "停止位：";
            // 
            // ParityCb
            // 
            this.ParityCb.FormattingEnabled = true;
            this.ParityCb.Location = new System.Drawing.Point(73, 302);
            this.ParityCb.Margin = new System.Windows.Forms.Padding(4);
            this.ParityCb.Name = "ParityCb";
            this.ParityCb.Size = new System.Drawing.Size(204, 23);
            this.ParityCb.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 305);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "校验位:";
            // 
            // dateBitesCb
            // 
            this.dateBitesCb.FormattingEnabled = true;
            this.dateBitesCb.Items.AddRange(new object[] {
            "8",
            "7",
            "6",
            "5"});
            this.dateBitesCb.Location = new System.Drawing.Point(73, 211);
            this.dateBitesCb.Margin = new System.Windows.Forms.Padding(4);
            this.dateBitesCb.Name = "dateBitesCb";
            this.dateBitesCb.Size = new System.Drawing.Size(204, 23);
            this.dateBitesCb.TabIndex = 1;
            this.dateBitesCb.Text = "8";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 215);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "数据位:";
            // 
            // baudRateCb
            // 
            this.baudRateCb.FormattingEnabled = true;
            this.baudRateCb.Location = new System.Drawing.Point(73, 120);
            this.baudRateCb.Margin = new System.Windows.Forms.Padding(4);
            this.baudRateCb.Name = "baudRateCb";
            this.baudRateCb.Size = new System.Drawing.Size(204, 23);
            this.baudRateCb.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 125);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "波特率：";
            // 
            // portNameCb
            // 
            this.portNameCb.FormattingEnabled = true;
            this.portNameCb.Location = new System.Drawing.Point(73, 29);
            this.portNameCb.Margin = new System.Windows.Forms.Padding(4);
            this.portNameCb.Name = "portNameCb";
            this.portNameCb.Size = new System.Drawing.Size(204, 23);
            this.portNameCb.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "端口：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.historyTb);
            this.groupBox3.Location = new System.Drawing.Point(345, 26);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(645, 346);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "消息记录";
            // 
            // historyTb
            // 
            this.historyTb.BackColor = System.Drawing.Color.Black;
            this.historyTb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historyTb.ForeColor = System.Drawing.Color.Lime;
            this.historyTb.Location = new System.Drawing.Point(4, 22);
            this.historyTb.Margin = new System.Windows.Forms.Padding(4);
            this.historyTb.Multiline = true;
            this.historyTb.Name = "historyTb";
            this.historyTb.Size = new System.Drawing.Size(637, 320);
            this.historyTb.TabIndex = 0;
            this.historyTb.TextChanged += new System.EventHandler(this.historyTb_TextChanged);
            // 
            // sendMsgTb
            // 
            this.sendMsgTb.Location = new System.Drawing.Point(349, 496);
            this.sendMsgTb.Margin = new System.Windows.Forms.Padding(4);
            this.sendMsgTb.Multiline = true;
            this.sendMsgTb.Name = "sendMsgTb";
            this.sendMsgTb.Size = new System.Drawing.Size(453, 133);
            this.sendMsgTb.TabIndex = 4;
            this.sendMsgTb.TextChanged += new System.EventHandler(this.sendMsgTb_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(825, 496);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 134);
            this.button2.TabIndex = 0;
            this.button2.Text = "发送消息";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1007, 645);
            this.Controls.Add(this.sendMsgTb);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "串口助手";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton stringRb;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox stopBitesCb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ParityCb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox dateBitesCb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox baudRateCb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox portNameCb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton byteRb;
        private System.Windows.Forms.RadioButton hexRb;
        private System.Windows.Forms.TextBox sendMsgTb;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox historyTb;
        private System.Windows.Forms.Button button2;
    }
}

