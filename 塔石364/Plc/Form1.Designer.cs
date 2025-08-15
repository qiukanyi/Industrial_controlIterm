namespace Plc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.input1 = new AntdUI.Input();
            this.inputNumber1 = new AntdUI.InputNumber();
            this.inputNumber2 = new AntdUI.InputNumber();
            this.inputNumber3 = new AntdUI.InputNumber();
            this.button1 = new AntdUI.Button();
            this.input3 = new AntdUI.Input();
            this.button2 = new AntdUI.Button();
            this.button3 = new AntdUI.Button();
            this.select1 = new AntdUI.Select();
            this.select2 = new AntdUI.Select();
            this.inputNumber4 = new AntdUI.InputNumber();
            this.inputNumber5 = new AntdUI.InputNumber();
            this.inputNumber6 = new AntdUI.InputNumber();
            this.inputNumber7 = new AntdUI.InputNumber();
            this.SuspendLayout();
            // 
            // input1
            // 
            this.input1.Font = new System.Drawing.Font("宋体", 24F);
            this.input1.Location = new System.Drawing.Point(12, 24);
            this.input1.Name = "input1";
            this.input1.PrefixSvg = resources.GetString("input1.PrefixSvg");
            this.input1.Size = new System.Drawing.Size(344, 53);
            this.input1.TabIndex = 0;
            this.input1.Text = "192.168.1.100";
            // 
            // inputNumber1
            // 
            this.inputNumber1.Font = new System.Drawing.Font("宋体", 24F);
            this.inputNumber1.Location = new System.Drawing.Point(362, 24);
            this.inputNumber1.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.inputNumber1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.inputNumber1.Name = "inputNumber1";
            this.inputNumber1.PrefixSvg = resources.GetString("inputNumber1.PrefixSvg");
            this.inputNumber1.Size = new System.Drawing.Size(226, 53);
            this.inputNumber1.TabIndex = 1;
            this.inputNumber1.Text = "102";
            this.inputNumber1.Value = new decimal(new int[] {
            102,
            0,
            0,
            0});
            // 
            // inputNumber2
            // 
            this.inputNumber2.Font = new System.Drawing.Font("宋体", 24F);
            this.inputNumber2.Location = new System.Drawing.Point(612, 24);
            this.inputNumber2.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.inputNumber2.Name = "inputNumber2";
            this.inputNumber2.PrefixSvg = resources.GetString("inputNumber2.PrefixSvg");
            this.inputNumber2.Size = new System.Drawing.Size(151, 53);
            this.inputNumber2.TabIndex = 1;
            this.inputNumber2.Text = "0";
            // 
            // inputNumber3
            // 
            this.inputNumber3.Font = new System.Drawing.Font("宋体", 24F);
            this.inputNumber3.Location = new System.Drawing.Point(791, 24);
            this.inputNumber3.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.inputNumber3.Name = "inputNumber3";
            this.inputNumber3.PrefixSvg = resources.GetString("inputNumber3.PrefixSvg");
            this.inputNumber3.Size = new System.Drawing.Size(137, 53);
            this.inputNumber3.TabIndex = 1;
            this.inputNumber3.Text = "1";
            this.inputNumber3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(934, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 52);
            this.button1.TabIndex = 2;
            this.button1.Text = "连接";
            this.button1.Type = AntdUI.TTypeMini.Primary;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // input3
            // 
            this.input3.Font = new System.Drawing.Font("宋体", 24F);
            this.input3.Location = new System.Drawing.Point(303, 225);
            this.input3.Name = "input3";
            this.input3.PlaceholderText = "请输入变量名";
            this.input3.PrefixSvg = resources.GetString("input3.PrefixSvg");
            this.input3.Size = new System.Drawing.Size(303, 59);
            this.input3.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(934, 131);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(188, 53);
            this.button2.TabIndex = 2;
            this.button2.Text = "读取";
            this.button2.Type = AntdUI.TTypeMini.Primary;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(627, 225);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(238, 59);
            this.button3.TabIndex = 2;
            this.button3.Text = "设置";
            this.button3.Type = AntdUI.TTypeMini.Primary;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // select1
            // 
            this.select1.Font = new System.Drawing.Font("宋体", 24F);
            this.select1.Location = new System.Drawing.Point(12, 225);
            this.select1.Name = "select1";
            this.select1.PrefixSvg = resources.GetString("select1.PrefixSvg");
            this.select1.Size = new System.Drawing.Size(285, 59);
            this.select1.TabIndex = 3;
            this.select1.SelectedIndexChanged += new AntdUI.IntEventHandler(this.select1_SelectedIndexChanged);
            // 
            // select2
            // 
            this.select2.Font = new System.Drawing.Font("宋体", 24F);
            this.select2.Location = new System.Drawing.Point(12, 125);
            this.select2.Name = "select2";
            this.select2.PrefixSvg = resources.GetString("select2.PrefixSvg");
            this.select2.Size = new System.Drawing.Size(285, 59);
            this.select2.TabIndex = 3;
            this.select2.SelectedIndexChanged += new AntdUI.IntEventHandler(this.select1_SelectedIndexChanged);
            // 
            // inputNumber4
            // 
            this.inputNumber4.Font = new System.Drawing.Font("宋体", 24F);
            this.inputNumber4.Location = new System.Drawing.Point(303, 125);
            this.inputNumber4.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.inputNumber4.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.inputNumber4.Name = "inputNumber4";
            this.inputNumber4.PrefixSvg = resources.GetString("inputNumber4.PrefixSvg");
            this.inputNumber4.Size = new System.Drawing.Size(138, 53);
            this.inputNumber4.TabIndex = 1;
            this.inputNumber4.Text = "1";
            this.inputNumber4.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // inputNumber5
            // 
            this.inputNumber5.Font = new System.Drawing.Font("宋体", 24F);
            this.inputNumber5.Location = new System.Drawing.Point(452, 125);
            this.inputNumber5.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.inputNumber5.Name = "inputNumber5";
            this.inputNumber5.PrefixSvg = resources.GetString("inputNumber5.PrefixSvg");
            this.inputNumber5.Size = new System.Drawing.Size(138, 53);
            this.inputNumber5.TabIndex = 1;
            this.inputNumber5.Text = "0";
            // 
            // inputNumber6
            // 
            this.inputNumber6.Font = new System.Drawing.Font("宋体", 24F);
            this.inputNumber6.Location = new System.Drawing.Point(601, 125);
            this.inputNumber6.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.inputNumber6.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.inputNumber6.Name = "inputNumber6";
            this.inputNumber6.PrefixSvg = resources.GetString("inputNumber6.PrefixSvg");
            this.inputNumber6.Size = new System.Drawing.Size(138, 53);
            this.inputNumber6.TabIndex = 1;
            this.inputNumber6.Text = "1";
            this.inputNumber6.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // inputNumber7
            // 
            this.inputNumber7.Font = new System.Drawing.Font("宋体", 24F);
            this.inputNumber7.Location = new System.Drawing.Point(750, 125);
            this.inputNumber7.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.inputNumber7.Name = "inputNumber7";
            this.inputNumber7.PrefixSvg = resources.GetString("inputNumber7.PrefixSvg");
            this.inputNumber7.Size = new System.Drawing.Size(138, 53);
            this.inputNumber7.TabIndex = 1;
            this.inputNumber7.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1134, 504);
            this.Controls.Add(this.select2);
            this.Controls.Add(this.select1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.inputNumber3);
            this.Controls.Add(this.inputNumber2);
            this.Controls.Add(this.inputNumber7);
            this.Controls.Add(this.inputNumber6);
            this.Controls.Add(this.inputNumber5);
            this.Controls.Add(this.inputNumber4);
            this.Controls.Add(this.inputNumber1);
            this.Controls.Add(this.input3);
            this.Controls.Add(this.input1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.Input input1;
        private AntdUI.InputNumber inputNumber1;
        private AntdUI.InputNumber inputNumber2;
        private AntdUI.InputNumber inputNumber3;
        private AntdUI.Button button1;
        private AntdUI.Input input3;
        private AntdUI.Button button2;
        private AntdUI.Button button3;
        private AntdUI.Select select1;
        private AntdUI.Select select2;
        private AntdUI.InputNumber inputNumber4;
        private AntdUI.InputNumber inputNumber5;
        private AntdUI.InputNumber inputNumber6;
        private AntdUI.InputNumber inputNumber7;
    }
}

