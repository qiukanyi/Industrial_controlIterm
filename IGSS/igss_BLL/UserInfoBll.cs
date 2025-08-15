using igss_DAL;
using igss_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace igss_BLL
{
    public  class UserInfoBll
    {
        private UserInfoDal  dal = new UserInfoDal();
        public UserInfo Login(string username, string password)
        {                  
            return dal.Login(username, password);
       
        }


    }
}
