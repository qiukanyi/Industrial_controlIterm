namespace Alarmsystem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new AntdUI.Panel();
            this.readioBtn = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.slider1 = new AntdUI.Slider();
            this.LoopModPanel2 = new AntdUI.In.FlowLayoutPanel();
            this.label2 = new AntdUI.Label();
            this.button5 = new AntdUI.Button();
            this.playBtn = new AntdUI.Button();
            this.volimeLb = new AntdUI.Label();
            this.label1 = new AntdUI.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.slaveTb = new AntdUI.InputNumber();
            this.button4 = new AntdUI.Button();
            this.button3 = new AntdUI.Button();
            this.button2 = new AntdUI.Button();
            this.baudRateCb = new AntdUI.Select();
            this.button1 = new AntdUI.Button();
            this.stopBitCb = new AntdUI.Select();
            this.parityCb = new AntdUI.Select();
            this.dataBitCB = new AntdUI.Select();
            this.portNameCb = new AntdUI.Select();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.readioBtn);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(635, 462);
            this.panel1.TabIndex = 0;
            this.panel1.Text = "panel1";
            // 
            // readioBtn
            // 
            this.readioBtn.AutoSize = true;
            this.readioBtn.Location = new System.Drawing.Point(45, 429);
            this.readioBtn.Margin = new System.Windows.Forms.Padding(2);
            this.readioBtn.Name = "readioBtn";
            this.readioBtn.Size = new System.Drawing.Size(14, 13);
            this.readioBtn.TabIndex = 0;
            this.readioBtn.TabStop = true;
            this.readioBtn.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.slider1);
            this.groupBox3.Controls.Add(this.LoopModPanel2);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.playBtn);
            this.groupBox3.Controls.Add(this.volimeLb);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(2, 170);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(634, 238);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "警报器状态：";
            // 
            // slider1
            // 
            this.slider1.Dots = new int[] {
        20};
            this.slider1.Location = new System.Drawing.Point(99, 27);
            this.slider1.Margin = new System.Windows.Forms.Padding(2);
            this.slider1.MaxValue = 30;
            this.slider1.Name = "slider1";
            this.slider1.Size = new System.Drawing.Size(293, 18);
            this.slider1.TabIndex = 8;
            this.slider1.Text = "slider1";
            this.slider1.Value = 20;
            this.slider1.ValueChanged += new AntdUI.IntEventHandler(this.slider1_ValueChanged);
            // 
            // LoopModPanel2
            // 
            this.LoopModPanel2.Location = new System.Drawing.Point(79, 96);
            this.LoopModPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.LoopModPanel2.Name = "LoopModPanel2";
            this.LoopModPanel2.Size = new System.Drawing.Size(488, 137);
            this.LoopModPanel2.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 105);
            this.label2.Margin = new System.Windows.Forms.Padding(2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 31);
            this.label2.TabIndex = 5;
            this.label2.Text = "播放模式：";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("宋体", 35F);
            this.button5.ImageHoverSvg = "";
            this.button5.ImageSvg = resources.GetString("button5.ImageSvg");
            this.button5.Location = new System.Drawing.Point(603, 19);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(27, 30);
            this.button5.TabIndex = 4;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // playBtn
            // 
            this.playBtn.Font = new System.Drawing.Font("幼圆", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.playBtn.Image = global::Alarmsystem.Properties.Resources.播放;
            this.playBtn.ImageHover = global::Alarmsystem.Properties.Resources.播放__1_;
            this.playBtn.ImageHoverSvg = resources.GetString("playBtn.ImageHoverSvg");
            this.playBtn.ImageSvg = resources.GetString("playBtn.ImageSvg");
            this.playBtn.Location = new System.Drawing.Point(530, 13);
            this.playBtn.Margin = new System.Windows.Forms.Padding(2);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(69, 43);
            this.playBtn.TabIndex = 3;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // volimeLb
            // 
            this.volimeLb.Location = new System.Drawing.Point(396, 27);
            this.volimeLb.Margin = new System.Windows.Forms.Padding(2);
            this.volimeLb.Name = "volimeLb";
            this.volimeLb.Size = new System.Drawing.Size(45, 18);
            this.volimeLb.TabIndex = 2;
            this.volimeLb.Text = "0";
            this.volimeLb.Click += new System.EventHandler(this.volimeLb_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(22, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "音量：";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.stopBitCb);
            this.groupBox1.Controls.Add(this.parityCb);
            this.groupBox1.Controls.Add(this.dataBitCB);
            this.groupBox1.Controls.Add(this.portNameCb);
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(634, 162);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "485工具参数：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.slaveTb);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.baudRateCb);
            this.groupBox2.Location = new System.Drawing.Point(4, 76);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(626, 71);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "参数设置：";
            // 
            // slaveTb
            // 
            this.slaveTb.Location = new System.Drawing.Point(168, 19);
            this.slaveTb.Margin = new System.Windows.Forms.Padding(2);
            this.slaveTb.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.slaveTb.Name = "slaveTb";
            this.slaveTb.PrefixText = "设备地址：";
            this.slaveTb.Size = new System.Drawing.Size(118, 33);
            this.slaveTb.TabIndex = 2;
            this.slaveTb.Text = "0";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(479, 18);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(82, 34);
            this.button4.TabIndex = 1;
            this.button4.Text = "读取参数";
            this.button4.Type = AntdUI.TTypeMini.Primary;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(392, 19);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(82, 34);
            this.button3.TabIndex = 1;
            this.button3.Text = "恢复出厂设置";
            this.button3.Type = AntdUI.TTypeMini.Error;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(305, 19);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 34);
            this.button2.TabIndex = 1;
            this.button2.Text = "重置";
            this.button2.Type = AntdUI.TTypeMini.Primary;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // baudRateCb
            // 
            this.baudRateCb.Location = new System.Drawing.Point(26, 19);
            this.baudRateCb.Margin = new System.Windows.Forms.Padding(2);
            this.baudRateCb.Name = "baudRateCb";
            this.baudRateCb.PrefixText = "波特率：";
            this.baudRateCb.Size = new System.Drawing.Size(118, 34);
            this.baudRateCb.TabIndex = 0;
            this.baudRateCb.Text = "9600";
            this.baudRateCb.SelectedIndexChanged += new AntdUI.IntEventHandler(this.baudRateCb_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(541, 19);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "连接";
            this.button1.Type = AntdUI.TTypeMini.Primary;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // stopBitCb
            // 
            this.stopBitCb.Location = new System.Drawing.Point(418, 19);
            this.stopBitCb.Margin = new System.Windows.Forms.Padding(2);
            this.stopBitCb.Name = "stopBitCb";
            this.stopBitCb.PrefixText = "停止位：";
            this.stopBitCb.Size = new System.Drawing.Size(118, 34);
            this.stopBitCb.TabIndex = 0;
            // 
            // parityCb
            // 
            this.parityCb.Location = new System.Drawing.Point(284, 19);
            this.parityCb.Margin = new System.Windows.Forms.Padding(2);
            this.parityCb.Name = "parityCb";
            this.parityCb.PrefixText = "校验位：";
            this.parityCb.Size = new System.Drawing.Size(118, 34);
            this.parityCb.TabIndex = 0;
            // 
            // dataBitCB
            // 
            this.dataBitCB.Location = new System.Drawing.Point(146, 19);
            this.dataBitCB.Margin = new System.Windows.Forms.Padding(2);
            this.dataBitCB.Name = "dataBitCB";
            this.dataBitCB.PrefixText = "数据位：";
            this.dataBitCB.Size = new System.Drawing.Size(118, 34);
            this.dataBitCB.TabIndex = 0;
            this.dataBitCB.Text = "8";
            // 
            // portNameCb
            // 
            this.portNameCb.Location = new System.Drawing.Point(4, 19);
            this.portNameCb.Margin = new System.Windows.Forms.Padding(2);
            this.portNameCb.Name = "portNameCb";
            this.portNameCb.PrefixText = "端口号：";
            this.portNameCb.Size = new System.Drawing.Size(118, 34);
            this.portNameCb.TabIndex = 0;
            this.portNameCb.Text = "COM1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 462);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private AntdUI.Select baudRateCb;
        private AntdUI.Select portNameCb;
        private AntdUI.Select dataBitCB;
        private AntdUI.Button button1;
        private AntdUI.Select stopBitCb;
        private AntdUI.Select parityCb;
        private AntdUI.InputNumber slaveTb;
        private System.Windows.Forms.GroupBox groupBox2;
        private AntdUI.Button button2;
        private System.Windows.Forms.GroupBox groupBox3;
        private AntdUI.Label label1;
        private AntdUI.Label volimeLb;
        private AntdUI.Button button3;
        private AntdUI.Button button4;
        private AntdUI.Button playBtn;
        private AntdUI.Button button5;
        private AntdUI.Label label2;
        private System.Windows.Forms.RadioButton readioBtn;
        private AntdUI.In.FlowLayoutPanel LoopModPanel2;
        private System.IO.Ports.SerialPort serialPort1;
        private AntdUI.Slider slider1;
    }
}

