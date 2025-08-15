using AntdUI;
using igss_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace igss_view
{
    public partial class FormLogin : Window  
    {

        private UserInfoDal bll = new();

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //提示：是否退出
         var dr=   MessageBox.Show("是否退出程序？", "温馨提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var userInfo = bll.Login(userNameTb.Text, passWordTb.Text);
            if (userInfo == null)
            {

                MessageBox.Show("用户名或密码错误");
            }
            else
            {
                //WindowManager.Toggle (nameof(FromMain),nameof(FormLogin ) );
                this.Toggle(nameof(FromMain));
            }
        }
    }
}
