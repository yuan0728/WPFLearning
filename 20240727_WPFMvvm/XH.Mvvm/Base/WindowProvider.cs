using System.Windows;

namespace XH.Mvvm.Base
{
    public class WindowProvider
    {
        static Dictionary<string, WindowInfo> types = new Dictionary<string, WindowInfo>();
        // 收购窗口
        // 允许自定义名字 key，不自定义就是窗体名
        public static void Register<T>(string key = "",Window owner = null)
        {
            if (string.IsNullOrEmpty(key))
                key = typeof(T).Name;

            if (!types.ContainsKey(key))
                types.Add(key, new WindowInfo { WinType = typeof(T),OwnerType = owner });
        }

        // 出售
        public static bool ShowDialog(string key,object dataContext)
        {
            Type type = null;
            if (types.ContainsKey(key))
            {
                type = types[key].WinType;
            }
            if (type != null)
            {
                // 同过反射创建新的对象
                Window win = (Window)Activator.CreateInstance(type);

                // 设置窗口所有者 当任务栏打开大窗口的时候，小窗口带出
                win.Owner = types[key].OwnerType;
                win.DataContext = dataContext;
                bool state = (bool)win.ShowDialog();
                return state;
            }
            else
                throw new Exception("没有找到对应的弹窗对象");
        }
    }

    class WindowInfo
    {
        public Type WinType { get; set; }
        public Window OwnerType { get; set; }
    }
}
