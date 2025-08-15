namespace Sensor
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
            this.inputNumber1 = new AntdUI.InputNumber();
            this.inputNumber2 = new AntdUI.InputNumber();
            this.inputNumber3 = new AntdUI.InputNumber();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // inputNumber1
            // 
            this.inputNumber1.DecimalPlaces = 1;
            this.inputNumber1.Location = new System.Drawing.Point(25, 27);
            this.inputNumber1.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.inputNumber1.Name = "inputNumber1";
            this.inputNumber1.PrefixText = "湿度：";
            this.inputNumber1.Size = new System.Drawing.Size(300, 53);
            this.inputNumber1.SuffixText = "%RH";
            this.inputNumber1.TabIndex = 0;
            this.inputNumber1.Text = "0.0";
            // 
            // inputNumber2
            // 
            this.inputNumber2.DecimalPlaces = 1;
            this.inputNumber2.Location = new System.Drawing.Point(25, 113);
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
            this.inputNumber2.PrefixText = "温度：";
            this.inputNumber2.Size = new System.Drawing.Size(300, 53);
            this.inputNumber2.SuffixText = "℃";
            this.inputNumber2.TabIndex = 0;
            this.inputNumber2.Text = "0.0";
            // 
            // inputNumber3
            // 
            this.inputNumber3.Location = new System.Drawing.Point(25, 202);
            this.inputNumber3.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.inputNumber3.Name = "inputNumber3";
            this.inputNumber3.PrefixText = "光照：";
            this.inputNumber3.Size = new System.Drawing.Size(300, 53);
            this.inputNumber3.SuffixText = "Lux";
            this.inputNumber3.TabIndex = 0;
            this.inputNumber3.Text = "0";
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM5";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 293);
            this.Controls.Add(this.inputNumber3);
            this.Controls.Add(this.inputNumber2);
            this.Controls.Add(this.inputNumber1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.InputNumber inputNumber1;
        private AntdUI.InputNumber inputNumber2;
        private AntdUI.InputNumber inputNumber3;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
    }
}

