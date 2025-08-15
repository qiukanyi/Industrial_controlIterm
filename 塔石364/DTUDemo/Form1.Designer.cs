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
            this.table2 = new AntdUI.Table();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputNumber1
            // 
            this.inputNumber1.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::DTUDemo.Properties.Settings.Default, "SERVER_PORT", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.inputNumber1.Location = new System.Drawing.Point(13, 19);
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
            this.inputNumber1.Size = new System.Drawing.Size(212, 59);
            this.inputNumber1.TabIndex = 0;
            this.inputNumber1.Text = "18000";
            this.inputNumber1.Value = global::DTUDemo.Properties.Settings.Default.SERVER_PORT;
            this.inputNumber1.ValueChanged += new AntdUI.DecimalEventHandler(this.inputNumber1_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(252, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 59);
            this.button1.TabIndex = 1;
            this.button1.Text = "连接";
            this.button1.Type = AntdUI.TTypeMini.Primary;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.table2);
            this.panel1.Controls.Add(this.inputNumber1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(444, 574);
            this.panel1.TabIndex = 2;
            this.panel1.Text = "panel1";
            // 
            // table2
            // 
            this.table2.BackColor = System.Drawing.Color.White;
            this.table2.EmptyHeader = true;
            this.table2.EmptyText = "暂无客户端连接";
            this.table2.Location = new System.Drawing.Point(13, 114);
            this.table2.Name = "table2";
            this.table2.Size = new System.Drawing.Size(410, 374);
            this.table2.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 574);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.InputNumber inputNumber1;
        private AntdUI.Button button1;
        private AntdUI.Panel panel1;
        private AntdUI.Table table2;
    }
}

