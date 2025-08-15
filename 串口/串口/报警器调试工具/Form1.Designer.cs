namespace 报警器调试工具
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BaudRatecb = new AntdUI.Select();
            this.slavetb = new AntdUI.InputNumber();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.stopBitcb = new AntdUI.Select();
            this.paritycb = new AntdUI.Select();
            this.dataBitcb = new AntdUI.Select();
            this.portNamecb = new AntdUI.Select();
            this.panel1 = new System.Windows.Forms.Panel();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new AntdUI.Label();
            this.label1 = new AntdUI.Label();
            this.volumesli = new AntdUI.Slider();
            this.stopbtn = new AntdUI.Button();
            this.Playbtn = new AntdUI.Button();
            this.label3 = new AntdUI.Label();
            this.loopModelPanel = new AntdUI.FlowPanel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.stopBitcb);
            this.groupBox1.Controls.Add(this.paritycb);
            this.groupBox1.Controls.Add(this.dataBitcb);
            this.groupBox1.Controls.Add(this.portNamecb);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(563, 120);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "485通讯参数";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BaudRatecb);
            this.groupBox2.Controls.Add(this.slavetb);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Location = new System.Drawing.Point(4, 59);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(334, 55);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "参数设置";
            // 
            // BaudRatecb
            // 
            this.BaudRatecb.Location = new System.Drawing.Point(4, 19);
            this.BaudRatecb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BaudRatecb.Name = "BaudRatecb";
            this.BaudRatecb.PrefixText = "波特率：";
            this.BaudRatecb.Size = new System.Drawing.Size(122, 33);
            this.BaudRatecb.TabIndex = 0;
            this.BaudRatecb.Text = "9600";
            // 
            // slavetb
            // 
            this.slavetb.Location = new System.Drawing.Point(130, 20);
            this.slavetb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.slavetb.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.slavetb.Name = "slavetb";
            this.slavetb.PrefixText = "设备地址：";
            this.slavetb.Size = new System.Drawing.Size(123, 33);
            this.slavetb.TabIndex = 2;
            this.slavetb.Text = "0";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(264, 18);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 33);
            this.button2.TabIndex = 2;
            this.button2.Text = "设置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(350, 77);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button3.Size = new System.Drawing.Size(103, 33);
            this.button3.TabIndex = 2;
            this.button3.Text = "恢复出厂设置";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(464, 77);
            this.button4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(87, 33);
            this.button4.TabIndex = 2;
            this.button4.Text = "读取参数";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(485, 12);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "连接";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // stopBitcb
            // 
            this.stopBitcb.Location = new System.Drawing.Point(370, 12);
            this.stopBitcb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.stopBitcb.Name = "stopBitcb";
            this.stopBitcb.PrefixText = "停止位：";
            this.stopBitcb.Size = new System.Drawing.Size(103, 33);
            this.stopBitcb.TabIndex = 0;
            // 
            // paritycb
            // 
            this.paritycb.Location = new System.Drawing.Point(247, 12);
            this.paritycb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.paritycb.Name = "paritycb";
            this.paritycb.PrefixText = "校验位：";
            this.paritycb.Size = new System.Drawing.Size(112, 33);
            this.paritycb.TabIndex = 0;
            // 
            // dataBitcb
            // 
            this.dataBitcb.Location = new System.Drawing.Point(123, 12);
            this.dataBitcb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataBitcb.Name = "dataBitcb";
            this.dataBitcb.PrefixText = "数据位：";
            this.dataBitcb.Size = new System.Drawing.Size(119, 33);
            this.dataBitcb.TabIndex = 0;
            this.dataBitcb.Text = "8";
            // 
            // portNamecb
            // 
            this.portNamecb.Location = new System.Drawing.Point(-2, 12);
            this.portNamecb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.portNamecb.Name = "portNamecb";
            this.portNamecb.PrefixText = "端口号：";
            this.portNamecb.Size = new System.Drawing.Size(118, 33);
            this.portNamecb.TabIndex = 0;
            this.portNamecb.Text = "COM1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(9, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(563, 120);
            this.panel1.TabIndex = 1;
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM3";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Location = new System.Drawing.Point(7, 134);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(563, 164);
            this.panel2.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.loopModelPanel);
            this.groupBox3.Controls.Add(this.stopbtn);
            this.groupBox3.Controls.Add(this.Playbtn);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.volumesli);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(563, 164);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "警报器状态";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(220, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "0";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "音量";
            // 
            // volumesli
            // 
            this.volumesli.Dots = new int[] {
        20};
            this.volumesli.Location = new System.Drawing.Point(44, 19);
            this.volumesli.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.volumesli.MaxValue = 30;
            this.volumesli.Name = "volumesli";
            this.volumesli.Size = new System.Drawing.Size(171, 25);
            this.volumesli.TabIndex = 0;
            this.volumesli.Text = "slider1";
            this.volumesli.ValueChanged += new AntdUI.IntEventHandler(this.volumesli_ValueChanged);
            // 
            // stopbtn
            // 
            this.stopbtn.Font = new System.Drawing.Font("宋体", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stopbtn.Image = global::报警器调试工具.Properties.Resources._5;
            this.stopbtn.Location = new System.Drawing.Point(265, 19);
            this.stopbtn.Name = "stopbtn";
            this.stopbtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.stopbtn.Size = new System.Drawing.Size(61, 54);
            this.stopbtn.TabIndex = 2;
            this.stopbtn.Click += new System.EventHandler(this.stopbtn_Click);
            // 
            // Playbtn
            // 
            this.Playbtn.Font = new System.Drawing.Font("宋体", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Playbtn.Image = global::报警器调试工具.Properties.Resources._1;
            this.Playbtn.Location = new System.Drawing.Point(343, 19);
            this.Playbtn.Name = "Playbtn";
            this.Playbtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Playbtn.Size = new System.Drawing.Size(55, 54);
            this.Playbtn.TabIndex = 2;
            this.Playbtn.Click += new System.EventHandler(this.Playbtn_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(5, 77);
            this.label3.Margin = new System.Windows.Forms.Padding(2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 27);
            this.label3.TabIndex = 1;
            this.label3.Text = "播放模式";
            // 
            // loopModelPanel
            // 
            this.loopModelPanel.Location = new System.Drawing.Point(69, 80);
            this.loopModelPanel.Name = "loopModelPanel";
            this.loopModelPanel.Size = new System.Drawing.Size(486, 79);
            this.loopModelPanel.TabIndex = 3;
            this.loopModelPanel.Text = "flowPanel1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 304);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "警报器测试";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private AntdUI.Select portNamecb;
        private System.Windows.Forms.Panel panel1;
        private AntdUI.Select dataBitcb;
        private AntdUI.Select BaudRatecb;
        private System.Windows.Forms.Button button1;
        private AntdUI.Select stopBitcb;
        private AntdUI.Select paritycb;
        private System.IO.Ports.SerialPort serialPort1;
        private AntdUI.InputNumber slavetb;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private AntdUI.Label label2;
        private AntdUI.Label label1;
        private AntdUI.Slider volumesli;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private AntdUI.Button Playbtn;
        private AntdUI.Button stopbtn;
        private AntdUI.Label label3;
        private AntdUI.FlowPanel loopModelPanel;
    }
}

