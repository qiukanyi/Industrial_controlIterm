namespace mqttDemo
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
            this.button1 = new AntdUI.Button();
            this.portTb = new AntdUI.InputNumber();
            this.PasswordTb = new AntdUI.Input();
            this.userNameTb = new AntdUI.Input();
            this.houstTb = new AntdUI.Input();
            this.pullTb = new AntdUI.Input();
            this.pushTb = new AntdUI.Input();
            this.button2 = new AntdUI.Button();
            this.input3 = new AntdUI.Input();
            this.button3 = new AntdUI.Button();
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
            this.panel1.Controls.Add(this.PasswordTb);
            this.panel1.Controls.Add(this.userNameTb);
            this.panel1.Controls.Add(this.pushTb);
            this.panel1.Controls.Add(this.pullTb);
            this.panel1.Controls.Add(this.input3);
            this.panel1.Controls.Add(this.houstTb);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 528);
            this.panel1.TabIndex = 0;
            this.panel1.Text = "panel1";
            // 
            // table1
            // 
            this.table1.BackColor = System.Drawing.Color.Transparent;
            this.table1.EmptyHeader = true;
            this.table1.EmptyText = "暂无设备在线";
            this.table1.Location = new System.Drawing.Point(11, 145);
            this.table1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.table1.Name = "table1";
            this.table1.Size = new System.Drawing.Size(608, 321);
            this.table1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(546, 18);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 38);
            this.button1.TabIndex = 2;
            this.button1.Text = "连接";
            this.button1.Type = AntdUI.TTypeMini.Primary;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // portTb
            // 
            this.portTb.Location = new System.Drawing.Point(214, 18);
            this.portTb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.portTb.Size = new System.Drawing.Size(96, 38);
            this.portTb.TabIndex = 1;
            this.portTb.Text = "1883";
            this.portTb.Value = new decimal(new int[] {
            1883,
            0,
            0,
            0});
            // 
            // PasswordTb
            // 
            this.PasswordTb.Location = new System.Drawing.Point(431, 18);
            this.PasswordTb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PasswordTb.Name = "PasswordTb";
            this.PasswordTb.PlaceholderText = "请输入密码";
            this.PasswordTb.PrefixText = "密码：";
            this.PasswordTb.Size = new System.Drawing.Size(109, 38);
            this.PasswordTb.TabIndex = 0;
            this.PasswordTb.Text = "123";
            this.PasswordTb.UseSystemPasswordChar = true;
            this.PasswordTb.TextChanged += new System.EventHandler(this.PasswordTb_TextChanged);
            // 
            // userNameTb
            // 
            this.userNameTb.Location = new System.Drawing.Point(316, 18);
            this.userNameTb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.userNameTb.Name = "userNameTb";
            this.userNameTb.PrefixText = "用户名：";
            this.userNameTb.Size = new System.Drawing.Size(109, 38);
            this.userNameTb.TabIndex = 0;
            this.userNameTb.Text = "admin";
            // 
            // houstTb
            // 
            this.houstTb.Location = new System.Drawing.Point(9, 18);
            this.houstTb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.houstTb.Name = "houstTb";
            this.houstTb.PrefixText = "MQTT主机：";
            this.houstTb.Size = new System.Drawing.Size(200, 38);
            this.houstTb.TabIndex = 0;
            this.houstTb.Text = "47.119.162.143";
            // 
            // pullTb
            // 
            this.pullTb.Location = new System.Drawing.Point(9, 76);
            this.pullTb.Margin = new System.Windows.Forms.Padding(2);
            this.pullTb.Name = "pullTb";
            this.pullTb.PrefixText = "订阅主题：";
            this.pullTb.Size = new System.Drawing.Size(263, 38);
            this.pullTb.TabIndex = 0;
            this.pullTb.Text = "/2405/push";
            // 
            // pushTb
            // 
            this.pushTb.Location = new System.Drawing.Point(276, 76);
            this.pushTb.Margin = new System.Windows.Forms.Padding(2);
            this.pushTb.Name = "pushTb";
            this.pushTb.PrefixText = "推送主题：";
            this.pushTb.Size = new System.Drawing.Size(264, 38);
            this.pushTb.TabIndex = 0;
            this.pushTb.Text = "/2405/pull";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(547, 76);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 38);
            this.button2.TabIndex = 2;
            this.button2.Text = "订阅";
            this.button2.Type = AntdUI.TTypeMini.Primary;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // input3
            // 
            this.input3.Location = new System.Drawing.Point(2, 470);
            this.input3.Margin = new System.Windows.Forms.Padding(2);
            this.input3.Name = "input3";
            this.input3.PrefixText = "消息：";
            this.input3.Size = new System.Drawing.Size(538, 38);
            this.input3.TabIndex = 0;
            this.input3.TextChanged += new System.EventHandler(this.input3_TextChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(543, 470);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(72, 38);
            this.button3.TabIndex = 2;
            this.button3.Text = "发送";
            this.button3.Type = AntdUI.TTypeMini.Primary;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 528);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.Panel panel1;
        private AntdUI.Input houstTb;
        private AntdUI.InputNumber portTb;
        private AntdUI.Button button1;
        private AntdUI.Input PasswordTb;
        private AntdUI.Input userNameTb;
        private AntdUI.Table table1;
        private AntdUI.Input pushTb;
        private AntdUI.Input pullTb;
        private AntdUI.Button button2;
        private AntdUI.Input input3;
        private AntdUI.Button button3;
    }
}

