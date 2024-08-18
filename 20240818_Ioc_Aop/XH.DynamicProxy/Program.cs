using System.Reflection.Emit;
using System.Reflection;

namespace XH.DynamicProxy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var user = CreateInstanceWithProxy<User>();

            user.Logout();
            Console.WriteLine();
            user.Login("aaaa");
            Console.WriteLine();
            var result = user.GetInfo("1111");
            Console.WriteLine(result);
        }

        // 动态代理的核心逻辑
        static T CreateInstanceWithProxy<T>()
        {
            // 创建动态程序集和模块
            AssemblyName assemblyName = new AssemblyName("DynamicAssembly");
            AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicModule");

            // 创建一个新的类，并让它继承自ParentClass
            TypeBuilder typeBuilder = moduleBuilder.DefineType(
                typeof(T).Name + "__DynamicClass__",
                TypeAttributes.Public,
                typeof(T));

            // 定义要重写的方法
            MethodInfo[] mis = typeof(T).GetMethods();
            foreach (MethodInfo mi in mis)
            {
                Type[] param_types = mi.GetParameters().Select(p => p.ParameterType).ToArray();
                MethodBuilder methodBuilder = typeBuilder.DefineMethod(
                    mi.Name,// "Logout",
                    MethodAttributes.Public | MethodAttributes.Virtual,
                    mi.ReturnType, //typeof(void),
                    param_types // Type.EmptyTypes
                );

                // 获取方法的IL生成器
                ILGenerator ilGenerator = methodBuilder.GetILGenerator();

                // 编写方法体指令
                ilGenerator.Emit(OpCodes.Ldstr, $"[{mi.Name}] 方法执行前--Hello from dynamic method!");
                ilGenerator.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }));


                ilGenerator.Emit(OpCodes.Ldarg_0);// 加载this指针
                if (param_types.Length > 0)
                {
                    ilGenerator.Emit(OpCodes.Ldarg_1);// 加载参数input
                }
                ilGenerator.Emit(OpCodes.Call, mi); // 调用基类的方法
                                                    //ilGenerator.EmitWriteLine("DynamicClass.MethodToOverride");

                ilGenerator.Emit(OpCodes.Ldstr, $"[{mi.Name}] 方法执行后--Hello from dynamic method!");
                ilGenerator.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }));


                ilGenerator.Emit(OpCodes.Ret);

            }
            // 创建类型
            Type dynamicType = typeBuilder.CreateTypeInfo().AsType();

            // 创建类的实例并调用重写的方法 创建代理类型
            T instance = (T)Activator.CreateInstance(dynamicType);

            return instance;
        }
    }

    public class User
    {
        public virtual void Logout()
        {
            Console.WriteLine("-- 执行了User对象中的Logout方法--");
        }
        public virtual void Login(string username)
        {
            Console.WriteLine($"-- 执行了User对象中的Login方法-- {username}");
        }
        public virtual string GetInfo(string userid)
        {
            Console.WriteLine($"-- 执行了User对象中的GetInfo方法-- {userid}");
            return "Administrator";
        }
    }

    //public interface IInterceptor
    //{
    //    void Process(Delegate propcess);
    //}
}