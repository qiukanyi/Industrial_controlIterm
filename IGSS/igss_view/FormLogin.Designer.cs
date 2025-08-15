namespace igss_view
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.label1 = new AntdUI.Label();
            this.userNameTb = new AntdUI.Input();
            this.passWordTb = new AntdUI.Input();
            this.button1 = new AntdUI.Button();
            this.button2 = new AntdUI.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Badge = "v1.0.0";
            this.label1.Font = new System.Drawing.Font("宋体", 44F);
            this.label1.Location = new System.Drawing.Point(-12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(800, 176);
            this.label1.TabIndex = 0;
            this.label1.Text = "xxx空压机监控系统";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // userNameTb
            // 
            this.userNameTb.Font = new System.Drawing.Font("宋体", 24F);
            this.userNameTb.Location = new System.Drawing.Point(80, 201);
            this.userNameTb.Name = "userNameTb";
            this.userNameTb.PlaceholderText = "请输入用户名";
            this.userNameTb.PrefixSvg = resources.GetString("userNameTb.PrefixSvg");
            this.userNameTb.Round = true;
            this.userNameTb.Size = new System.Drawing.Size(650, 80);
            this.userNameTb.TabIndex = 1;
            // 
            // passWordTb
            // 
            this.passWordTb.Font = new System.Drawing.Font("宋体", 24F);
            this.passWordTb.Location = new System.Drawing.Point(80, 301);
            this.passWordTb.Name = "passWordTb";
            this.passWordTb.PlaceholderText = "请输入密码";
            this.passWordTb.PrefixSvg = resources.GetString("passWordTb.PrefixSvg");
            this.passWordTb.Round = true;
            this.passWordTb.Size = new System.Drawing.Size(650, 80);
            this.passWordTb.TabIndex = 2;
            this.passWordTb.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(101, 406);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(245, 58);
            this.button1.TabIndex = 4;
            this.button1.Text = "退出";
            this.button1.Type = AntdUI.TTypeMini.Error;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(452, 406);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(268, 58);
            this.button2.TabIndex = 3;
            this.button2.Text = "登录";
            this.button2.Type = AntdUI.TTypeMini.Primary;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormLogin
            // 
            this.AcceptButton = this.button2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(800, 491);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.passWordTb);
            this.Controls.Add(this.userNameTb);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLogin";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.Label label1;
        private AntdUI.Input userNameTb;
        private AntdUI.Input passWordTb;
        private AntdUI.Button button1;
        private AntdUI.Button button2;
    }
}