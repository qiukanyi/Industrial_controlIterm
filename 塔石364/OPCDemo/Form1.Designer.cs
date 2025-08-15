namespace OPCDemo
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
            this.IPTb = new AntdUI.Input();
            this.button1 = new AntdUI.Button();
            this.serverCb = new AntdUI.Select();
            this.button2 = new AntdUI.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tree1 = new AntdUI.Tree();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nodeNameCb = new AntdUI.Input();
            this.nodePathCb = new AntdUI.Input();
            this.button3 = new AntdUI.Button();
            this.nodeValueDb = new AntdUI.Input();
            this.qualityTb = new AntdUI.Input();
            this.updateTimeCb = new AntdUI.Input();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // IPTb
            // 
            this.IPTb.Location = new System.Drawing.Point(12, 12);
            this.IPTb.Name = "IPTb";
            this.IPTb.PrefixText = "IP:";
            this.IPTb.Size = new System.Drawing.Size(193, 58);
            this.IPTb.TabIndex = 0;
            this.IPTb.Text = "127.0.0.1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(211, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 57);
            this.button1.TabIndex = 1;
            this.button1.Text = "查询服务";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // serverCb
            // 
            this.serverCb.Enabled = false;
            this.serverCb.Location = new System.Drawing.Point(359, 13);
            this.serverCb.Name = "serverCb";
            this.serverCb.PrefixText = "服务：";
            this.serverCb.Size = new System.Drawing.Size(315, 57);
            this.serverCb.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(680, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(275, 57);
            this.button2.TabIndex = 1;
            this.button2.Text = "连接";
            this.button2.Type = AntdUI.TTypeMini.Primary;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tree1);
            this.groupBox1.Location = new System.Drawing.Point(27, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(632, 361);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "节点列表：";
            // 
            // tree1
            // 
            this.tree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree1.Location = new System.Drawing.Point(3, 21);
            this.tree1.Name = "tree1";
            this.tree1.Size = new System.Drawing.Size(626, 337);
            this.tree1.TabIndex = 0;
            this.tree1.Text = "tree1";
            this.tree1.SelectChanged += new AntdUI.Tree.SelectEventHandler(this.tree1_SelectChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.updateTimeCb);
            this.groupBox2.Controls.Add(this.qualityTb);
            this.groupBox2.Controls.Add(this.nodeValueDb);
            this.groupBox2.Controls.Add(this.nodePathCb);
            this.groupBox2.Controls.Add(this.nodeNameCb);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Location = new System.Drawing.Point(680, 77);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 361);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "节点信息：";
            // 
            // nodeNameCb
            // 
            this.nodeNameCb.Location = new System.Drawing.Point(7, 25);
            this.nodeNameCb.Name = "nodeNameCb";
            this.nodeNameCb.PrefixText = "节点名称：";
            this.nodeNameCb.ReadOnly = true;
            this.nodeNameCb.Size = new System.Drawing.Size(262, 43);
            this.nodeNameCb.TabIndex = 0;
            // 
            // nodePathCb
            // 
            this.nodePathCb.Location = new System.Drawing.Point(7, 83);
            this.nodePathCb.Name = "nodePathCb";
            this.nodePathCb.PrefixText = "节点路径：";
            this.nodePathCb.ReadOnly = true;
            this.nodePathCb.Size = new System.Drawing.Size(262, 43);
            this.nodePathCb.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(0, 305);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(275, 50);
            this.button3.TabIndex = 1;
            this.button3.Text = "读取";
            this.button3.Type = AntdUI.TTypeMini.Primary;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // nodeValueDb
            // 
            this.nodeValueDb.Location = new System.Drawing.Point(5, 132);
            this.nodeValueDb.Name = "nodeValueDb";
            this.nodeValueDb.PrefixText = "节点数据：";
            this.nodeValueDb.ReadOnly = true;
            this.nodeValueDb.Size = new System.Drawing.Size(262, 43);
            this.nodeValueDb.TabIndex = 0;
            this.nodeValueDb.TextChanged += new System.EventHandler(this.input1_TextChanged);
            // 
            // qualityTb
            // 
            this.qualityTb.Location = new System.Drawing.Point(7, 181);
            this.qualityTb.Name = "qualityTb";
            this.qualityTb.PrefixText = "通信质量：";
            this.qualityTb.ReadOnly = true;
            this.qualityTb.Size = new System.Drawing.Size(262, 43);
            this.qualityTb.TabIndex = 0;
            this.qualityTb.TextChanged += new System.EventHandler(this.input1_TextChanged);
            // 
            // updateTimeCb
            // 
            this.updateTimeCb.Location = new System.Drawing.Point(7, 230);
            this.updateTimeCb.Name = "updateTimeCb";
            this.updateTimeCb.PrefixText = "更新时间：";
            this.updateTimeCb.ReadOnly = true;
            this.updateTimeCb.Size = new System.Drawing.Size(262, 43);
            this.updateTimeCb.TabIndex = 0;
            this.updateTimeCb.TextChanged += new System.EventHandler(this.input1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 471);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.serverCb);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.IPTb);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.Input IPTb;
        private AntdUI.Button button1;
        private AntdUI.Select serverCb;
        private AntdUI.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private AntdUI.Tree tree1;
        private System.Windows.Forms.GroupBox groupBox2;
        private AntdUI.Input nodePathCb;
        private AntdUI.Input nodeNameCb;
        private AntdUI.Input nodeValueDb;
        private AntdUI.Button button3;
        private AntdUI.Input updateTimeCb;
        private AntdUI.Input qualityTb;
    }
}

