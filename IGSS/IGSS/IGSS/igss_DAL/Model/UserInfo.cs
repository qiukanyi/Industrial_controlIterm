using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace igss_DAL.Model
{
    public  class UserInfo
    {
        public int Id { get; set; }

        public string NickName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Slat { get; set; }

        //密码加密：
        //进行不可逆 的签名
        //加盐

    }
}
