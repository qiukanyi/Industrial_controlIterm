namespace SerialServer
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
            this.ipTB = new AntdUI.Input();
            this.button1 = new AntdUI.Button();
            this.temperatureTB = new AntdUI.InputNumber();
            this.humidityTB = new AntdUI.InputNumber();
            this.lightTB = new AntdUI.InputNumber();
            this.panel1 = new AntdUI.Panel();
            this.portTB = new AntdUI.InputNumber();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ipTB
            // 
            this.ipTB.Location = new System.Drawing.Point(12, 12);
            this.ipTB.Name = "ipTB";
            this.ipTB.PrefixSvg = "";
            this.ipTB.PrefixText = "串口服务器：";
            this.ipTB.Size = new System.Drawing.Size(293, 51);
            this.ipTB.TabIndex = 0;
            this.ipTB.Text = "192.168.0.60";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(177, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 45);
            this.button1.TabIndex = 2;
            this.button1.Text = "连接";
            this.button1.Type = AntdUI.TTypeMini.Primary;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // temperatureTB
            // 
            this.temperatureTB.Location = new System.Drawing.Point(12, 262);
            this.temperatureTB.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.temperatureTB.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            -2147483648});
            this.temperatureTB.Name = "temperatureTB";
            this.temperatureTB.PrefixText = "温度：";
            this.temperatureTB.Size = new System.Drawing.Size(205, 51);
            this.temperatureTB.SuffixText = "℃";
            this.temperatureTB.TabIndex = 3;
            this.temperatureTB.Text = "0";
            // 
            // humidityTB
            // 
            this.humidityTB.Location = new System.Drawing.Point(12, 205);
            this.humidityTB.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.humidityTB.Name = "humidityTB";
            this.humidityTB.PrefixText = "湿度：";
            this.humidityTB.Size = new System.Drawing.Size(205, 51);
            this.humidityTB.SuffixText = "%RH";
            this.humidityTB.TabIndex = 3;
            this.humidityTB.Text = "0";
            // 
            // lightTB
            // 
            this.lightTB.Location = new System.Drawing.Point(12, 319);
            this.lightTB.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.lightTB.Name = "lightTB";
            this.lightTB.PrefixText = "光照：";
            this.lightTB.Size = new System.Drawing.Size(205, 51);
            this.lightTB.SuffixText = "Lux";
            this.lightTB.TabIndex = 3;
            this.lightTB.Text = "0";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.portTB);
            this.panel1.Controls.Add(this.ipTB);
            this.panel1.Controls.Add(this.lightTB);
            this.panel1.Controls.Add(this.humidityTB);
            this.panel1.Controls.Add(this.temperatureTB);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(317, 381);
            this.panel1.TabIndex = 4;
            this.panel1.Text = "panel1";
            // 
            // portTB
            // 
            this.portTB.Location = new System.Drawing.Point(12, 69);
            this.portTB.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.portTB.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.portTB.Name = "portTB";
            this.portTB.PrefixText = "串口服务器端口：";
            this.portTB.Size = new System.Drawing.Size(293, 51);
            this.portTB.TabIndex = 4;
            this.portTB.Text = "10125";
            this.portTB.Value = new decimal(new int[] {
            10125,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 381);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.Input ipTB;
        private AntdUI.Button button1;
        private AntdUI.InputNumber temperatureTB;
        private AntdUI.InputNumber humidityTB;
        private AntdUI.InputNumber lightTB;
        private AntdUI.Panel panel1;
        private AntdUI.InputNumber portTB;
    }
}

