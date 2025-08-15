namespace MqttDemo
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
            this.panel1 = new AntdUI.Panel();
            this.table1 = new AntdUI.Table();
            this.button3 = new AntdUI.Button();
            this.button2 = new AntdUI.Button();
            this.button1 = new AntdUI.Button();
            this.portTb = new AntdUI.InputNumber();
            this.passwordTb = new AntdUI.Input();
            this.usernameTb = new AntdUI.Input();
            this.pushTb = new AntdUI.Input();
            this.pullTb = new AntdUI.Input();
            this.input3 = new AntdUI.Input();
            this.hostTb = new AntdUI.Input();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.table1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.portTb);
            this.panel1.Controls.Add(this.passwordTb);
            this.panel1.Controls.Add(this.usernameTb);
            this.panel1.Controls.Add(this.pushTb);
            this.panel1.Controls.Add(this.pullTb);
            this.panel1.Controls.Add(this.input3);
            this.panel1.Controls.Add(this.hostTb);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(839, 450);
            this.panel1.TabIndex = 0;
            this.panel1.Text = "panel1";
            // 
            // table1
            // 
            this.table1.BackColor = System.Drawing.Color.White;
            this.table1.EmptyHeader = true;
            this.table1.EmptyText = "暂无设备在线";
            this.table1.Location = new System.Drawing.Point(12, 133);
            this.table1.Name = "table1";
            this.table1.Size = new System.Drawing.Size(815, 257);
            this.table1.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(712, 396);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 48);
            this.button3.TabIndex = 2;
            this.button3.Text = "发送";
            this.button3.Type = AntdUI.TTypeMini.Primary;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(712, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 48);
            this.button2.TabIndex = 2;
            this.button2.Text = "订阅";
            this.button2.Type = AntdUI.TTypeMini.Primary;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(712, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 48);
            this.button1.TabIndex = 2;
            this.button1.Text = "连接";
            this.button1.Type = AntdUI.TTypeMini.Primary;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // portTb
            // 
            this.portTb.Location = new System.Drawing.Point(262, 12);
            this.portTb.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.portTb.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.portTb.Name = "portTb";
            this.portTb.PrefixText = "端口：";
            this.portTb.Size = new System.Drawing.Size(147, 51);
            this.portTb.TabIndex = 1;
            this.portTb.Text = "1883";
            this.portTb.Value = new decimal(new int[] {
            1883,
            0,
            0,
            0});
            // 
            // passwordTb
            // 
            this.passwordTb.Location = new System.Drawing.Point(577, 12);
            this.passwordTb.Name = "passwordTb";
            this.passwordTb.PlaceholderText = "请输入密码";
            this.passwordTb.PrefixText = "密码：";
            this.passwordTb.Size = new System.Drawing.Size(129, 51);
            this.passwordTb.TabIndex = 0;
            this.passwordTb.Text = "123";
            this.passwordTb.UseSystemPasswordChar = true;
            // 
            // usernameTb
            // 
            this.usernameTb.Location = new System.Drawing.Point(415, 12);
            this.usernameTb.Name = "usernameTb";
            this.usernameTb.PrefixText = "用户名：";
            this.usernameTb.Size = new System.Drawing.Size(156, 51);
            this.usernameTb.TabIndex = 0;
            this.usernameTb.Text = "admin";
            // 
            // pushTb
            // 
            this.pushTb.Location = new System.Drawing.Point(373, 69);
            this.pushTb.Name = "pushTb";
            this.pushTb.PrefixText = "推送主题：";
            this.pushTb.Size = new System.Drawing.Size(333, 51);
            this.pushTb.TabIndex = 0;
            this.pushTb.Text = "/2405/pull";
            // 
            // pullTb
            // 
            this.pullTb.Location = new System.Drawing.Point(12, 69);
            this.pullTb.Name = "pullTb";
            this.pullTb.PrefixText = "订阅主题：";
            this.pullTb.Size = new System.Drawing.Size(355, 51);
            this.pullTb.TabIndex = 0;
            this.pullTb.Text = "/2405/push";
            // 
            // input3
            // 
            this.input3.Location = new System.Drawing.Point(13, 396);
            this.input3.Name = "input3";
            this.input3.PrefixText = "消息：";
            this.input3.Size = new System.Drawing.Size(694, 51);
            this.input3.TabIndex = 0;
            // 
            // hostTb
            // 
            this.hostTb.Location = new System.Drawing.Point(12, 12);
            this.hostTb.Name = "hostTb";
            this.hostTb.PrefixText = "MQTT主机：";
            this.hostTb.Size = new System.Drawing.Size(244, 51);
            this.hostTb.TabIndex = 0;
            this.hostTb.Text = "47.119.162.143";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 450);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.Panel panel1;
        private AntdUI.Input hostTb;
        private AntdUI.InputNumber portTb;
        private AntdUI.Input usernameTb;
        private AntdUI.Input passwordTb;
        private AntdUI.Button button1;
        private AntdUI.Table table1;
        private AntdUI.Button button2;
        private AntdUI.Input pushTb;
        private AntdUI.Input pullTb;
        private AntdUI.Input input3;
        private AntdUI.Button button3;
    }
}

