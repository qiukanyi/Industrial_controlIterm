namespace 支付宝
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
            this.tabs1 = new AntdUI.Tabs();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new AntdUI.Button();
            this.input4 = new AntdUI.Input();
            this.input3 = new AntdUI.Input();
            this.input2 = new AntdUI.Input();
            this.input1 = new AntdUI.Input();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.inputNumber1 = new AntdUI.InputNumber();
            this.button3 = new AntdUI.Button();
            this.button2 = new AntdUI.Button();
            this.input8 = new AntdUI.Input();
            this.input6 = new AntdUI.Input();
            this.input5 = new AntdUI.Input();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.panel1.SuspendLayout();
            this.tabs1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabs1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 0;
            this.panel1.Text = "panel1";
            // 
            // tabs1
            // 
            this.tabs1.Controls.Add(this.tabPage1);
            this.tabs1.Controls.Add(this.tabPage2);
            this.tabs1.Location = new System.Drawing.Point(0, 0);
            this.tabs1.Name = "tabs1";
            this.tabs1.SelectedIndex = 0;
            this.tabs1.Size = new System.Drawing.Size(800, 450);
            this.tabs1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.input4);
            this.tabPage1.Controls.Add(this.input3);
            this.tabPage1.Controls.Add(this.input2);
            this.tabPage1.Controls.Add(this.input1);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 416);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "初始化";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(242, 325);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(362, 64);
            this.button1.TabIndex = 1;
            this.button1.Text = "初始化";
            this.button1.Type = AntdUI.TTypeMini.Primary;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // input4
            // 
            this.input4.Location = new System.Drawing.Point(65, 223);
            this.input4.Name = "input4";
            this.input4.PlaceholderText = "请输入支付宝公钥";
            this.input4.PrefixText = "支付宝公钥：";
            this.input4.Size = new System.Drawing.Size(629, 58);
            this.input4.TabIndex = 0;
            this.input4.Text = resources.GetString("input4.Text");
            // 
            // input3
            // 
            this.input3.Location = new System.Drawing.Point(65, 159);
            this.input3.Name = "input3";
            this.input3.PlaceholderText = "请输入应用私钥：";
            this.input3.PrefixText = "应用私钥：";
            this.input3.Size = new System.Drawing.Size(629, 58);
            this.input3.TabIndex = 0;
            this.input3.Text = resources.GetString("input3.Text");
            // 
            // input2
            // 
            this.input2.Location = new System.Drawing.Point(65, 95);
            this.input2.Name = "input2";
            this.input2.PlaceholderText = "请输入AppID";
            this.input2.PrefixText = "AppID:";
            this.input2.Size = new System.Drawing.Size(629, 58);
            this.input2.TabIndex = 0;
            this.input2.Text = "9021000138664344";
            this.input2.TextChanged += new System.EventHandler(this.input2_TextChanged);
            // 
            // input1
            // 
            this.input1.Location = new System.Drawing.Point(65, 31);
            this.input1.Name = "input1";
            this.input1.PlaceholderText = "请输入网关地址";
            this.input1.PrefixText = "网关地址:";
            this.input1.Size = new System.Drawing.Size(629, 58);
            this.input1.TabIndex = 0;
            this.input1.Text = "https://openapi-sandbox.dl.alipaydev.com/gateway.do\t";
            this.input1.Click += new System.EventHandler(this.input1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.inputNumber1);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.input8);
            this.tabPage2.Controls.Add(this.input6);
            this.tabPage2.Controls.Add(this.input5);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 416);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "扫码支付";
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // inputNumber1
            // 
            this.inputNumber1.DecimalPlaces = 2;
            this.inputNumber1.Location = new System.Drawing.Point(61, 156);
            this.inputNumber1.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.inputNumber1.MaxLength = 10000;
            this.inputNumber1.Name = "inputNumber1";
            this.inputNumber1.PlaceholderText = "请输入金额";
            this.inputNumber1.PrefixText = "金额：";
            this.inputNumber1.Size = new System.Drawing.Size(633, 49);
            this.inputNumber1.TabIndex = 2;
            this.inputNumber1.Text = "0.00";
            this.inputNumber1.ThousandsSeparator = true;
            this.inputNumber1.ValueChanged += new AntdUI.DecimalEventHandler(this.inputNumber1_ValueChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(182, 332);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(401, 50);
            this.button3.TabIndex = 1;
            this.button3.Text = "支付";
            this.button3.Type = AntdUI.TTypeMini.Primary;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(700, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 50);
            this.button2.TabIndex = 1;
            this.button2.Text = "随机生成";
            this.button2.Type = AntdUI.TTypeMini.Primary;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // input8
            // 
            this.input8.Location = new System.Drawing.Point(61, 221);
            this.input8.Name = "input8";
            this.input8.PlaceholderText = "请输入付款码";
            this.input8.PrefixText = "付款码：";
            this.input8.Size = new System.Drawing.Size(633, 50);
            this.input8.TabIndex = 0;
            // 
            // input6
            // 
            this.input6.Location = new System.Drawing.Point(61, 89);
            this.input6.Name = "input6";
            this.input6.PlaceholderText = "请输入订单标题";
            this.input6.PrefixText = "订单标题：";
            this.input6.Size = new System.Drawing.Size(633, 50);
            this.input6.TabIndex = 0;
            // 
            // input5
            // 
            this.input5.Location = new System.Drawing.Point(61, 23);
            this.input5.Name = "input5";
            this.input5.PlaceholderText = "请输入订单号或点击随机生成";
            this.input5.PrefixText = "订单号：";
            this.input5.Size = new System.Drawing.Size(633, 50);
            this.input5.TabIndex = 0;
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM5";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
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
            this.tabs1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.Panel panel1;
        private AntdUI.Tabs tabs1;
        private System.Windows.Forms.TabPage tabPage1;
        private AntdUI.Input input1;
        private System.Windows.Forms.TabPage tabPage2;
        private AntdUI.Input input4;
        private AntdUI.Input input3;
        private AntdUI.Input input2;
        private AntdUI.Button button1;
        private AntdUI.Input input8;
        private AntdUI.Input input6;
        private AntdUI.Input input5;
        private AntdUI.Button button2;
        private AntdUI.InputNumber inputNumber1;
        private AntdUI.Button button3;
        private System.IO.Ports.SerialPort serialPort1;
    }
}

