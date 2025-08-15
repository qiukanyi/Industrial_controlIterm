namespace Detectorfrom
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
            this.panel1 = new AntdUI.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ucledNums1 = new HZH_Controls.Controls.UCLEDNums();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.inputNumber3 = new AntdUI.InputNumber();
            this.inputNumber2 = new AntdUI.InputNumber();
            this.inputNumber1 = new AntdUI.InputNumber();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 320);
            this.panel1.TabIndex = 0;
            this.panel1.Text = "panel1";
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ucledNums1);
            this.groupBox2.Location = new System.Drawing.Point(281, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(519, 312);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数码管显示";
            // 
            // ucledNums1
            // 
            this.ucledNums1.LineWidth = 10;
            this.ucledNums1.Location = new System.Drawing.Point(72, 119);
            this.ucledNums1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ucledNums1.Name = "ucledNums1";
            this.ucledNums1.Size = new System.Drawing.Size(334, 72);
            this.ucledNums1.TabIndex = 1;
            this.ucledNums1.Value = "-0.00000";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inputNumber3);
            this.groupBox1.Controls.Add(this.inputNumber2);
            this.groupBox1.Controls.Add(this.inputNumber1);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 315);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "属性数值：";
            // 
            // inputNumber3
            // 
            this.inputNumber3.Location = new System.Drawing.Point(0, 200);
            this.inputNumber3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inputNumber3.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.inputNumber3.Name = "inputNumber3";
            this.inputNumber3.PrefixText = "光照：";
            this.inputNumber3.Size = new System.Drawing.Size(272, 56);
            this.inputNumber3.SuffixText = "%RH";
            this.inputNumber3.TabIndex = 2;
            this.inputNumber3.Text = "0";
            // 
            // inputNumber2
            // 
            this.inputNumber2.DecimalPlaces = 1;
            this.inputNumber2.Location = new System.Drawing.Point(-3, 122);
            this.inputNumber2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inputNumber2.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.inputNumber2.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            -2147483648});
            this.inputNumber2.Name = "inputNumber2";
            this.inputNumber2.PrefixText = "摄氏度：";
            this.inputNumber2.Size = new System.Drawing.Size(275, 56);
            this.inputNumber2.SuffixText = "%RH";
            this.inputNumber2.TabIndex = 3;
            this.inputNumber2.Text = "0.0";
            // 
            // inputNumber1
            // 
            this.inputNumber1.DecimalPlaces = 1;
            this.inputNumber1.Location = new System.Drawing.Point(-3, 51);
            this.inputNumber1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inputNumber1.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.inputNumber1.Name = "inputNumber1";
            this.inputNumber1.PrefixText = "湿度：";
            this.inputNumber1.Size = new System.Drawing.Size(275, 56);
            this.inputNumber1.SuffixText = "%RH";
            this.inputNumber1.TabIndex = 1;
            this.inputNumber1.Text = "0.0";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM6";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 320);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private AntdUI.InputNumber inputNumber3;
        private AntdUI.InputNumber inputNumber2;
        private AntdUI.InputNumber inputNumber1;
        private System.Windows.Forms.Timer timer1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox groupBox2;
        private HZH_Controls.Controls.UCLEDNums ucledNums1;
        private System.Windows.Forms.Timer timer2;
    }
}

