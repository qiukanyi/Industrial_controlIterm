using igss_DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace igss_view
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            InitWindow();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            InitDatabase();
            Application.Run(WindowManager .Show (nameof(FormLogin)));
        }

        private static void InitWindow()
        {
            WindowManager.RegisterWindow(nameof(FormLogin), () => new FormLogin());
            WindowManager.RegisterWindow(nameof(FromMain ), () => new FromMain ());
        }

        private static void InitDatabase()
        {
            var database = ConfigurationManager.AppSettings["data_base"];
            var path = Path.Combine(Environment.CurrentDirectory, "config", database);
            var directoryName = Path.GetDirectoryName(path);
            if (directoryName is not null && !Directory.Exists(directoryName))
            { 
                Directory .CreateDirectory(directoryName);
            }
            DalHelper .InitDatabase (path);
        }
    }
}
