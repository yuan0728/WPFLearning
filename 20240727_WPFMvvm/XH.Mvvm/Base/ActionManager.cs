
namespace XH.Mvvm.Base
{
    public class ActionManager
    {
        static Dictionary<string, Delegate> types = new Dictionary<string, Delegate>();
        // 收购窗口
        public static void Register<T>(Action<T> action, string key)
        {
            
            if (!types.ContainsKey(key))
                types.Add(key, action);
        }  
        
        public static void Register<T>(Func<T> action, string key)
        {
            if (!types.ContainsKey(key))
                types.Add(key, action);
        }

        public static void Invoke<T>(string key, T arg)
        {
            if (types.ContainsKey(key))
                ((Action<T>)types[key]).Invoke(arg);
        }

        public static T InvokeWithResult<T>(string key)
        {
            if (types.ContainsKey(key))
               return (types[key] as Func<T>).Invoke();

            return default(T);
        }

    }
}
