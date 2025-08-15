using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace igss_view
{

    /// <summary>
    /// 窗口管理类
    /// </summary>
    public static   class WindowManager
    {

        private static Dictionary<string, Func<Form>> _windowFactories = new Dictionary<string, Func<Form>>();

        private static Dictionary<string, Form> _windows = new Dictionary<string, Form>();

        private static Dictionary<string, Dictionary<string, Func<object, object>>> _parameterListers = new();
        /// <summary>
        /// 注册窗口到窗口管理器，窗口管理器会根据窗口名称来创建窗口
        /// </summary>
        public static void RegisterWindow(string name, Func<Form> formFactory)
        {
            _windowFactories[name] = formFactory;
        }
        /// <summary>
        /// 设置窗口是否可见
        /// </summary>
        /// <param name="name"></param>
        /// <param name="visible"></param>
        public static Form  SetVisible(string name, bool visible)
        {
            if (!_windows.TryGetValue(name, out var form))
            {
                form = _windows[name] = _windowFactories[name]();//连续赋值
                form.Closed += (sender, args) =>
                {
                    _windows.Remove(name);
                    if (!_windows.Values.Any (form => form.Visible))
                    {
                        Application.Exit();
                    }
                };
            }
            form.Visible = visible;
            form.TopMost = true;//窗口置顶操作
            form.TopMost = false;//取消置顶
            return form;
        }


        /// <summary>
        /// 切换操作
        /// </summary>
        /// <param name="showName"></param>
        /// <param name="hideName"></param>
        public static void Toggle(string showName, string hideName)
        {
            Hide(hideName);
            Show (showName);       
        }

        public static void Toggle(this Form form ,string showName)
        {
            form.Hide();
            Show(showName);
        }





        /// <summary>
        /// 显示窗口
        /// </summary>
        /// <param name="name"></param>
        public static Form  Show(string name)
        {
           return  SetVisible(name, true);
        }

        /// <summary>
        /// 隐藏窗口
        /// </summary>
        /// <param name="name"></param>
        public static Form  Hide(string name)
        {
          return   SetVisible(name, false);
        }
        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="name"></param>
        public static void Close(string name)
        {
            if (_windows.TryGetValue(name, out var form))
            {
                form.Close();
            }
        }
        /// <summary>
        /// 监听窗口参数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parameterName"></param>
        /// <param name="handler"></param>
        public static void ListenerParameter(string name, string parameterName, Func<object, object> handler)
        {
            if (!_parameterListers.TryGetValue(name, out var parameters))
            {
                parameters = _parameterListers[name] = new();
                parameters[parameterName] = handler;
            }
        }

        /// <summary>
        /// 设置窗口参数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parameterName"></param>
        /// <param name="value"></param>
        public static object SetParameter(string name, string parameterName, object value)
        {
            if (_parameterListers.TryGetValue(name, out var parameters))
            {
                if (parameters.TryGetValue(parameterName, out var handler))
                {
                    return handler(value);
                }
            }

            throw new Exception($"{name}窗口不存在{parameterName}参数");
        }
    }
}
    


