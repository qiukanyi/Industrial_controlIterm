using HmExtension.Commons.Extensions;
using igss_DAL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace igss_DAL
{
    public  class UserInfoDal
    {
        public List<UserInfo> ResultHandler(DataTable dt)
        {
            List<UserInfo> list = new List<UserInfo>();
            foreach (DataRow row  in dt.Rows)
            {
                list.Add(new UserInfo
                {

                    Id = (int)row .Field <long  >("id"),
                    NickName = row.Field<string>("nick_name"),
                    UserName = row.Field<string>("username"),
                    Password = row.Field<string>("password"),
                    Slat = row.Field<string>("salt"),
                    //Id = (int)row["Id"],
                    //NickName = row["NickName"].ToString(),
                    //UserName = row["UserName"].ToString(),
                    //Password = row["Password"].ToString(),
                    //Slat = row["Slat"].ToString(),
                });
              

            }

            return list;
        }

        public UserInfo Login(string username, string password)
        {
            var list = DalHelper.DBHelper.ExecuteQuery(
                "select * from user_info where username = @username", ResultHandler, // 这里传递一个委托
                new SQLiteParameter("@username", username));
            if (list.Count == 1)
            { 
            
                var user = list[0];
                password=(password +user .Slat ).ToMd5();
                if (user.Password == password)
                {

                    user.Password = "";
                    return user;
                }

              
            }
            return null;
        }

    }
}
