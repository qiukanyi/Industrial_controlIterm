using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using igss_DAL.Properties;
using Helper;
using System.Data.SQLite;
using System.Collections;
using System.Globalization;

namespace igss_DAL
{
    public  class DalHelper
    {
        public  static    DBHelper DBHelper;
       
        public static void InitDatabase(string  dataBase)
        {
            var builder = new SQLiteConnectionStringBuilder();
            builder.DataSource = dataBase;
            
            DBHelper = new DBHelper(() =>
            {
               
                return new SQLiteConnection(builder.ConnectionString);
            });
            //读取配置文件中的建表sql语句
            var rs = sqls.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture , true, true);
             if (rs == null)
            {
                return;

            };
            //执行建表SQL语句，从而完成数据库的初始化
            foreach (DictionaryEntry o in rs)
            {
                DBHelper.ExecuteNonQuery($"{o.Value}");
            }
        }


    }
}
