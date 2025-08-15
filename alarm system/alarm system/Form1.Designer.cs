namespace alarm_system
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ucThermometer1 = new HZH_Controls.Controls.UCThermometer();
            this.ucComboxGrid1 = new HZH_Controls.Controls.UCComboxGrid();
            this.ucMeter2 = new HZH_Controls.Controls.UCMeter();
            this.ucMeter1 = new HZH_Controls.Controls.UCMeter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.inputNumber3 = new AntdUI.InputNumber();
            this.inputNumber1 = new AntdUI.InputNumber();
            this.inputNumber2 = new AntdUI.InputNumber();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ucThermometer1);
            this.panel1.Controls.Add(this.ucComboxGrid1);
            this.panel1.Controls.Add(this.ucMeter2);
            this.panel1.Controls.Add(this.ucMeter1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 0;
            // 
            // ucThermometer1
            // 
            this.ucThermometer1.GlassTubeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.ucThermometer1.LeftTemperatureUnit = HZH_Controls.Controls.TemperatureUnit.C;
            this.ucThermometer1.Location = new System.Drawing.Point(697, 13);
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
            this.ucThermometer1.Size = new System.Drawing.Size(70, 413);
            this.ucThermometer1.SplitCount = 1;
            this.ucThermometer1.TabIndex = 3;
            this.ucThermometer1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // ucComboxGrid1
            // 
            this.ucComboxGrid1.BackColor = System.Drawing.Color.Transparent;
            this.ucComboxGrid1.BackColorExt = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ucComboxGrid1.BoxStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.ucComboxGrid1.ConerRadius = 5;
            this.ucComboxGrid1.DropPanelHeight = -1;
            this.ucComboxGrid1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ucComboxGrid1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ucComboxGrid1.GridColumns = null;
            this.ucComboxGrid1.GridDataSource = null;
            this.ucComboxGrid1.GridRowType = typeof(HZH_Controls.Controls.UCDataGridViewRow);
            this.ucComboxGrid1.IsRadius = true;
            this.ucComboxGrid1.IsShowRect = true;
            this.ucComboxGrid1.ItemWidth = 70;
            this.ucComboxGrid1.Location = new System.Drawing.Point(0, 0);
            this.ucComboxGrid1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucComboxGrid1.Name = "ucComboxGrid1";
            this.ucComboxGrid1.Padding = new System.Windows.Forms.Padding(2);
            this.ucComboxGrid1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ucComboxGrid1.RectWidth = 1;
            this.ucComboxGrid1.SelectedIndex = -1;
            this.ucComboxGrid1.SelectedValue = "";
            this.ucComboxGrid1.SelectItemColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ucComboxGrid1.SelectSource = null;
            this.ucComboxGrid1.Size = new System.Drawing.Size(173, 32);
            this.ucComboxGrid1.Source = null;
            this.ucComboxGrid1.TabIndex = 2;
            this.ucComboxGrid1.TextField = null;
            this.ucComboxGrid1.TextValue = null;
            this.ucComboxGrid1.TriangleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            // 
            // ucMeter2
            // 
            this.ucMeter2.BoundaryLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter2.ExternalRoundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter2.FixedText = "Lux";
            this.ucMeter2.InsideRoundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter2.Location = new System.Drawing.Point(341, 141);
            this.ucMeter2.MaxValue = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.ucMeter2.MeterDegrees = 260;
            this.ucMeter2.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucMeter2.Name = "ucMeter2";
            this.ucMeter2.PointerColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter2.ScaleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter2.ScaleValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter2.Size = new System.Drawing.Size(350, 306);
            this.ucMeter2.SplitCount = 10;
            this.ucMeter2.TabIndex = 1;
            this.ucMeter2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter2.TextFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucMeter2.TextLocation = HZH_Controls.Controls.MeterTextLocation.Top;
            this.ucMeter2.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucMeter2.Load += new System.EventHandler(this.ucMeter1_Load);
            // 
            // ucMeter1
            // 
            this.ucMeter1.BoundaryLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter1.ExternalRoundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter1.FixedText = "%RH";
            this.ucMeter1.InsideRoundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter1.Location = new System.Drawing.Point(0, 170);
            this.ucMeter1.MaxValue = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.ucMeter1.MeterDegrees = 180;
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
            this.ucMeter1.TabIndex = 1;
            this.ucMeter1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMeter1.TextFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucMeter1.TextLocation = HZH_Controls.Controls.MeterTextLocation.Top;
            this.ucMeter1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucMeter1.Load += new System.EventHandler(this.ucMeter1_Load);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inputNumber3);
            this.groupBox1.Controls.Add(this.inputNumber1);
            this.groupBox1.Controls.Add(this.inputNumber2);
            this.groupBox1.Location = new System.Drawing.Point(4, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(662, 124);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据显示：";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // inputNumber3
            // 
            this.inputNumber3.Location = new System.Drawing.Point(461, 36);
            this.inputNumber3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inputNumber3.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.inputNumber3.Name = "inputNumber3";
            this.inputNumber3.PrefixText = "光照：";
            this.inputNumber3.Size = new System.Drawing.Size(183, 56);
            this.inputNumber3.SuffixText = "%RH";
            this.inputNumber3.TabIndex = 5;
            this.inputNumber3.Text = "0";
            // 
            // inputNumber1
            // 
            this.inputNumber1.DecimalPlaces = 1;
            this.inputNumber1.Location = new System.Drawing.Point(8, 36);
            this.inputNumber1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inputNumber1.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.inputNumber1.Name = "inputNumber1";
            this.inputNumber1.PrefixText = "湿度：";
            this.inputNumber1.Size = new System.Drawing.Size(186, 56);
            this.inputNumber1.SuffixText = "%RH";
            this.inputNumber1.TabIndex = 4;
            this.inputNumber1.Text = "0";
            // 
            // inputNumber2
            // 
            this.inputNumber2.DecimalPlaces = 1;
            this.inputNumber2.Location = new System.Drawing.Point(236, 36);
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
            this.inputNumber2.Size = new System.Drawing.Size(186, 56);
            this.inputNumber2.SuffixText = "%RH";
            this.inputNumber2.TabIndex = 6;
            this.inputNumber2.Text = "0.0";
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM9";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2800;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 3000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private AntdUI.InputNumber inputNumber3;
        private AntdUI.InputNumber inputNumber1;
        private AntdUI.InputNumber inputNumber2;
        private System.IO.Ports.SerialPort serialPort1;
        private HZH_Controls.Controls.UCMeter ucMeter1;
        private HZH_Controls.Controls.UCMeter ucMeter2;
        private HZH_Controls.Controls.UCThermometer ucThermometer1;
        private HZH_Controls.Controls.UCComboxGrid ucComboxGrid1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}

