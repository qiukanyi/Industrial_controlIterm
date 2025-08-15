namespace NixieTube
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
            this.ucledNums1 = new HZH_Controls.Controls.UCLEDNums();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.inputNumber1 = new AntdUI.InputNumber();
            this.button1 = new System.Windows.Forms.Button();
            this.checkbox1 = new AntdUI.Checkbox();
            this.checkbox2 = new AntdUI.Checkbox();
            this.checkbox3 = new AntdUI.Checkbox();
            this.checkbox4 = new AntdUI.Checkbox();
            this.checkbox5 = new AntdUI.Checkbox();
            this.checkbox6 = new AntdUI.Checkbox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucledNums1
            // 
            this.ucledNums1.LineWidth = 10;
            this.ucledNums1.Location = new System.Drawing.Point(104, 92);
            this.ucledNums1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ucledNums1.Name = "ucledNums1";
            this.ucledNums1.Size = new System.Drawing.Size(498, 85);
            this.ucledNums1.TabIndex = 0;
            this.ucledNums1.Value = "-0.00000";
            this.ucledNums1.Load += new System.EventHandler(this.ucledNums1_Load);
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM5";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // inputNumber1
            // 
            this.inputNumber1.DecimalPlaces = 5;
            this.inputNumber1.Location = new System.Drawing.Point(121, 184);
            this.inputNumber1.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.inputNumber1.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.inputNumber1.Name = "inputNumber1";
            this.inputNumber1.Size = new System.Drawing.Size(212, 45);
            this.inputNumber1.TabIndex = 1;
            this.inputNumber1.Text = "0.00000";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(360, 184);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 45);
            this.button1.TabIndex = 2;
            this.button1.Text = "设置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkbox1
            // 
            this.checkbox1.Font = new System.Drawing.Font("宋体", 18F);
            this.checkbox1.Location = new System.Drawing.Point(43, 24);
            this.checkbox1.Name = "checkbox1";
            this.checkbox1.Size = new System.Drawing.Size(75, 23);
            this.checkbox1.TabIndex = 3;
            this.checkbox1.Tag = "5";
            this.checkbox1.Text = " ";
            this.checkbox1.CheckedChanged += new AntdUI.BoolEventHandler(this.checkbox1_CheckedChanged);
            // 
            // checkbox2
            // 
            this.checkbox2.Font = new System.Drawing.Font("宋体", 18F);
            this.checkbox2.Location = new System.Drawing.Point(110, 24);
            this.checkbox2.Name = "checkbox2";
            this.checkbox2.Size = new System.Drawing.Size(75, 23);
            this.checkbox2.TabIndex = 3;
            this.checkbox2.Tag = "4";
            this.checkbox2.Text = " ";
            this.checkbox2.CheckedChanged += new AntdUI.BoolEventHandler(this.checkbox1_CheckedChanged);
            // 
            // checkbox3
            // 
            this.checkbox3.Font = new System.Drawing.Font("宋体", 18F);
            this.checkbox3.Location = new System.Drawing.Point(170, 24);
            this.checkbox3.Name = "checkbox3";
            this.checkbox3.Size = new System.Drawing.Size(75, 23);
            this.checkbox3.TabIndex = 3;
            this.checkbox3.Tag = "3";
            this.checkbox3.Text = " ";
            this.checkbox3.CheckedChanged += new AntdUI.BoolEventHandler(this.checkbox1_CheckedChanged);
            // 
            // checkbox4
            // 
            this.checkbox4.Font = new System.Drawing.Font("宋体", 18F);
            this.checkbox4.Location = new System.Drawing.Point(231, 24);
            this.checkbox4.Name = "checkbox4";
            this.checkbox4.Size = new System.Drawing.Size(75, 23);
            this.checkbox4.TabIndex = 3;
            this.checkbox4.Tag = "2";
            this.checkbox4.Text = " ";
            this.checkbox4.CheckedChanged += new AntdUI.BoolEventHandler(this.checkbox1_CheckedChanged);
            // 
            // checkbox5
            // 
            this.checkbox5.Font = new System.Drawing.Font("宋体", 18F);
            this.checkbox5.Location = new System.Drawing.Point(293, 24);
            this.checkbox5.Name = "checkbox5";
            this.checkbox5.Size = new System.Drawing.Size(75, 23);
            this.checkbox5.TabIndex = 3;
            this.checkbox5.Tag = "1";
            this.checkbox5.Text = " ";
            this.checkbox5.CheckedChanged += new AntdUI.BoolEventHandler(this.checkbox1_CheckedChanged);
            // 
            // checkbox6
            // 
            this.checkbox6.Font = new System.Drawing.Font("宋体", 18F);
            this.checkbox6.Location = new System.Drawing.Point(363, 24);
            this.checkbox6.Name = "checkbox6";
            this.checkbox6.Size = new System.Drawing.Size(75, 23);
            this.checkbox6.TabIndex = 3;
            this.checkbox6.Tag = "0";
            this.checkbox6.Text = " ";
            this.checkbox6.CheckedChanged += new AntdUI.BoolEventHandler(this.checkbox1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkbox4);
            this.groupBox1.Controls.Add(this.checkbox6);
            this.groupBox1.Controls.Add(this.checkbox1);
            this.groupBox1.Controls.Add(this.checkbox5);
            this.groupBox1.Controls.Add(this.checkbox2);
            this.groupBox1.Controls.Add(this.checkbox3);
            this.groupBox1.Location = new System.Drawing.Point(71, 253);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 69);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "闪烁";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 408);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.inputNumber1);
            this.Controls.Add(this.ucledNums1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private HZH_Controls.Controls.UCLEDNums ucledNums1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private AntdUI.InputNumber inputNumber1;
        private System.Windows.Forms.Button button1;
        private AntdUI.Checkbox checkbox1;
        private AntdUI.Checkbox checkbox2;
        private AntdUI.Checkbox checkbox3;
        private AntdUI.Checkbox checkbox4;
        private AntdUI.Checkbox checkbox5;
        private AntdUI.Checkbox checkbox6;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

