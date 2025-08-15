namespace 环境监测
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
            this.ucThermometer1 = new HZH_Controls.Controls.UCThermometer();
            this.ucMeter1 = new HZH_Controls.Controls.UCMeter();
            this.ucMeter2 = new HZH_Controls.Controls.UCMeter();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // inputNumber1
            // 
            this.inputNumber1.Location = new System.Drawing.Point(12, 3);
            this.inputNumber1.Name = "inputNumber1";
            this.inputNumber1.PrefixText = "湿度：";
            this.inputNumber1.Size = new System.Drawing.Size(179, 60);
            this.inputNumber1.SuffixText = "%RH";
            this.inputNumber1.TabIndex = 0;
            this.inputNumber1.Text = "0";
            // 
            // inputNumber2
            // 
            this.inputNumber2.Location = new System.Drawing.Point(206, 3);
            this.inputNumber2.Name = "inputNumber2";
            this.inputNumber2.PrefixText = "温度：";
            this.inputNumber2.Size = new System.Drawing.Size(179, 60);
            this.inputNumber2.SuffixText = "℃";
            this.inputNumber2.TabIndex = 0;
            this.inputNumber2.Text = "0";
            // 
            // inputNumber3
            // 
            this.inputNumber3.Location = new System.Drawing.Point(404, 3);
            this.inputNumber3.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.inputNumber3.Name = "inputNumber3";
            this.inputNumber3.PrefixText = "光照：";
            this.inputNumber3.Size = new System.Drawing.Size(179, 60);
            this.inputNumber3.SuffixText = "Lux";
            this.inputNumber3.TabIndex = 0;
            this.inputNumber3.Text = "0";
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM4";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2800;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ucThermometer1
            // 
            this.ucThermometer1.GlassTubeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.ucThermometer1.LeftTemperatureUnit = HZH_Controls.Controls.TemperatureUnit.C;
            this.ucThermometer1.Location = new System.Drawing.Point(706, 3);
            this.ucThermometer1.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ucThermometer1.MercuryColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucThermometer1.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucThermometer1.Name = "ucThermometer1";
            this.ucThermometer1.RightTemperatureUnit = HZH_Controls.Controls.TemperatureUnit.C;
            this.ucThermometer1.Size = new System.Drawing.Size(82, 404);
            this.ucThermometer1.SplitCount = 1;
            this.ucThermometer1.TabIndex = 1;
            this.ucThermometer1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // ucMeter1
            // 
            this.ucMeter1.BoundaryLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter1.ExternalRoundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter1.FixedText = "%RH";
            this.ucMeter1.InsideRoundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter1.Location = new System.Drawing.Point(-6, 137);
            this.ucMeter1.MaxValue = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.ucMeter1.MeterDegrees = 150;
            this.ucMeter1.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucMeter1.Name = "ucMeter1";
            this.ucMeter1.PointerColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter1.ScaleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter1.ScaleValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter1.Size = new System.Drawing.Size(350, 200);
            this.ucMeter1.SplitCount = 10;
            this.ucMeter1.TabIndex = 2;
            this.ucMeter1.Tag = "";
            this.ucMeter1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter1.TextFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucMeter1.TextLocation = HZH_Controls.Controls.MeterTextLocation.Top;
            this.ucMeter1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // ucMeter2
            // 
            this.ucMeter2.BoundaryLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter2.ExternalRoundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter2.FixedText = "Lux";
            this.ucMeter2.InsideRoundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter2.Location = new System.Drawing.Point(350, 146);
            this.ucMeter2.MaxValue = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.ucMeter2.MeterDegrees = 250;
            this.ucMeter2.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucMeter2.Name = "ucMeter2";
            this.ucMeter2.PointerColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter2.ScaleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter2.ScaleValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter2.Size = new System.Drawing.Size(350, 284);
            this.ucMeter2.SplitCount = 10;
            this.ucMeter2.TabIndex = 2;
            this.ucMeter2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter2.TextFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucMeter2.TextLocation = HZH_Controls.Controls.MeterTextLocation.Top;
            this.ucMeter2.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 3000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ucMeter2);
            this.Controls.Add(this.ucMeter1);
            this.Controls.Add(this.ucThermometer1);
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
        private HZH_Controls.Controls.UCThermometer ucThermometer1;
        private HZH_Controls.Controls.UCMeter ucMeter1;
        private HZH_Controls.Controls.UCMeter ucMeter2;
        private System.Windows.Forms.Timer timer2;
    }
}

