namespace DTUDemo
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
            this.inputNumber1 = new AntdUI.InputNumber();
            this.button1 = new AntdUI.Button();
            this.panel1 = new AntdUI.Panel();
            this.table1 = new AntdUI.Table();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputNumber1
            // 
            this.inputNumber1.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::DTUDemo.Properties.Settings.Default, "SERVER_PORT", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.inputNumber1.Location = new System.Drawing.Point(25, 23);
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
            this.inputNumber1.PrefixText = "端口号：";
            this.inputNumber1.Size = new System.Drawing.Size(252, 55);
            this.inputNumber1.TabIndex = 0;
            this.inputNumber1.Text = "18000";
            this.inputNumber1.Value = global::DTUDemo.Properties.Settings.Default.SERVER_PORT;
            this.inputNumber1.ValueChanged += new AntdUI.DecimalEventHandler(this.inputNumber1_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(374, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(192, 55);
            this.button1.TabIndex = 1;
            this.button1.Text = "启动";
            this.button1.Type = AntdUI.TTypeMini.Primary;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.table1);
            this.panel1.Controls.Add(this.inputNumber1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(593, 558);
            this.panel1.TabIndex = 2;
            this.panel1.Text = "panel1";
            // 
            // table1
            // 
            this.table1.BackColor = System.Drawing.Color.White;
            this.table1.EmptyHeader = true;
            this.table1.EmptyText = "暂无客户端连接";
            this.table1.Location = new System.Drawing.Point(25, 119);
            this.table1.Name = "table1";
            this.table1.Size = new System.Drawing.Size(541, 427);
            this.table1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 558);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.InputNumber inputNumber1;
        private AntdUI.Button button1;
        private AntdUI.Panel panel1;
        private AntdUI.Table table1;
    }
}

