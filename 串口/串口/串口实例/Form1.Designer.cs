namespace 串口实例
{
    partial class 串口助手
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
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbbytes = new System.Windows.Forms.RadioButton();
            this.rbHex = new System.Windows.Forms.RadioButton();
            this.rbString = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comDatabits = new System.Windows.Forms.ComboBox();
            this.comStopbits = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comBaudRate = new System.Windows.Forms.ComboBox();
            this.comParity = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comPortName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txthistory = new System.Windows.Forms.TextBox();
            this.txtSendMessage = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbbytes);
            this.groupBox1.Controls.Add(this.rbHex);
            this.groupBox1.Controls.Add(this.rbString);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 58);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据显示格式";
            // 
            // rbbytes
            // 
            this.rbbytes.AutoSize = true;
            this.rbbytes.Location = new System.Drawing.Point(172, 30);
            this.rbbytes.Name = "rbbytes";
            this.rbbytes.Size = new System.Drawing.Size(58, 19);
            this.rbbytes.TabIndex = 0;
            this.rbbytes.TabStop = true;
            this.rbbytes.Text = "字节";
            this.rbbytes.UseVisualStyleBackColor = true;
            this.rbbytes.CheckedChanged += new System.EventHandler(this.rbbytes_CheckedChanged);
            // 
            // rbHex
            // 
            this.rbHex.AutoSize = true;
            this.rbHex.Location = new System.Drawing.Point(95, 30);
            this.rbHex.Name = "rbHex";
            this.rbHex.Size = new System.Drawing.Size(74, 19);
            this.rbHex.TabIndex = 0;
            this.rbHex.TabStop = true;
            this.rbHex.Text = "16进制";
            this.rbHex.UseVisualStyleBackColor = true;
            this.rbHex.CheckedChanged += new System.EventHandler(this.rbHex_CheckedChanged);
            // 
            // rbString
            // 
            this.rbString.AutoSize = true;
            this.rbString.Location = new System.Drawing.Point(8, 30);
            this.rbString.Name = "rbString";
            this.rbString.Size = new System.Drawing.Size(73, 19);
            this.rbString.TabIndex = 0;
            this.rbString.TabStop = true;
            this.rbString.Text = "字符串";
            this.rbString.UseVisualStyleBackColor = true;
            this.rbString.CheckedChanged += new System.EventHandler(this.rbString_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.comDatabits);
            this.groupBox2.Controls.Add(this.comStopbits);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.comBaudRate);
            this.groupBox2.Controls.Add(this.comParity);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.comPortName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(18, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(273, 362);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "连接参数";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 13F);
            this.button1.Location = new System.Drawing.Point(35, 305);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 40);
            this.button1.TabIndex = 2;
            this.button1.Text = "打开串口";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comDatabits
            // 
            this.comDatabits.Font = new System.Drawing.Font("宋体", 13F);
            this.comDatabits.FormattingEnabled = true;
            this.comDatabits.Items.AddRange(new object[] {
            "8",
            "7",
            "6",
            "5",
            "4"});
            this.comDatabits.Location = new System.Drawing.Point(89, 143);
            this.comDatabits.Name = "comDatabits";
            this.comDatabits.Size = new System.Drawing.Size(178, 30);
            this.comDatabits.TabIndex = 2;
            this.comDatabits.Text = "8";
            // 
            // comStopbits
            // 
            this.comStopbits.Font = new System.Drawing.Font("宋体", 13F);
            this.comStopbits.FormattingEnabled = true;
            this.comStopbits.Location = new System.Drawing.Point(89, 249);
            this.comStopbits.Name = "comStopbits";
            this.comStopbits.Size = new System.Drawing.Size(178, 30);
            this.comStopbits.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 13F);
            this.label3.Location = new System.Drawing.Point(6, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "数据位：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 13F);
            this.label5.Location = new System.Drawing.Point(6, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 22);
            this.label5.TabIndex = 2;
            this.label5.Text = "停止位：";
            // 
            // comBaudRate
            // 
            this.comBaudRate.Font = new System.Drawing.Font("宋体", 13F);
            this.comBaudRate.FormattingEnabled = true;
            this.comBaudRate.Location = new System.Drawing.Point(89, 90);
            this.comBaudRate.Name = "comBaudRate";
            this.comBaudRate.Size = new System.Drawing.Size(178, 30);
            this.comBaudRate.TabIndex = 2;
            // 
            // comParity
            // 
            this.comParity.Font = new System.Drawing.Font("宋体", 13F);
            this.comParity.FormattingEnabled = true;
            this.comParity.Location = new System.Drawing.Point(89, 196);
            this.comParity.Name = "comParity";
            this.comParity.Size = new System.Drawing.Size(178, 30);
            this.comParity.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 13F);
            this.label2.Location = new System.Drawing.Point(6, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "波特率：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 13F);
            this.label4.Location = new System.Drawing.Point(6, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 22);
            this.label4.TabIndex = 2;
            this.label4.Text = "校验位：";
            // 
            // comPortName
            // 
            this.comPortName.Font = new System.Drawing.Font("宋体", 13F);
            this.comPortName.FormattingEnabled = true;
            this.comPortName.Location = new System.Drawing.Point(89, 37);
            this.comPortName.Name = "comPortName";
            this.comPortName.Size = new System.Drawing.Size(178, 30);
            this.comPortName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 13F);
            this.label1.Location = new System.Drawing.Point(6, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "端口：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txthistory);
            this.groupBox3.Location = new System.Drawing.Point(297, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(500, 256);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "消息记录";
            // 
            // txthistory
            // 
            this.txthistory.BackColor = System.Drawing.Color.Black;
            this.txthistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txthistory.ForeColor = System.Drawing.Color.LawnGreen;
            this.txthistory.Location = new System.Drawing.Point(3, 21);
            this.txthistory.Multiline = true;
            this.txthistory.Name = "txthistory";
            this.txthistory.Size = new System.Drawing.Size(494, 232);
            this.txthistory.TabIndex = 0;
            // 
            // txtSendMessage
            // 
            this.txtSendMessage.Location = new System.Drawing.Point(310, 278);
            this.txtSendMessage.Multiline = true;
            this.txtSendMessage.Name = "txtSendMessage";
            this.txtSendMessage.Size = new System.Drawing.Size(347, 143);
            this.txtSendMessage.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(663, 323);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 31);
            this.button2.TabIndex = 5;
            this.button2.Text = "发送消息";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // 串口助手
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtSendMessage);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "串口助手";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
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

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comDatabits;
        private System.Windows.Forms.ComboBox comStopbits;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comBaudRate;
        private System.Windows.Forms.ComboBox comParity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comPortName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txthistory;
        private System.Windows.Forms.TextBox txtSendMessage;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton rbString;
        private System.Windows.Forms.RadioButton rbbytes;
        private System.Windows.Forms.RadioButton rbHex;
    }
}

