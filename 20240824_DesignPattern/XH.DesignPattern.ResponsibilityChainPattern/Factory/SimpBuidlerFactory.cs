using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using XH.DesignPattern.ResponsibilityChainPattern.Builder;

namespace XH.DesignPattern.ResponsibilityChainPattern.Factory
{
    /// <summary>
    /// 这个工厂是为了来创建建造者的
    /// </summary>
    public class SimpBuidlerFactory
    {
        private static string dllName = "XH.DesignPattern.ResponsibilityChainPattern.dll";
        private static string typeName = "XH.DesignPattern.ResponsibilityChainPattern.Builder.AuditorWorkFlowsBuild";

        public static IBuilder CreateBuilderInstance()
        {
            //字符串：  写到配置文件中去；
            //          修改配置文件的信息，不用重新编译，可以直接生效 
            //return new AuditorWorkFlowsNewBuild(); 
            //反射
            Assembly assembly = Assembly.LoadFrom(dllName); // 获取DLL 
            Type type = assembly.GetType(typeName);// 获取DLL中的当前文件类型
            object oinstance = Activator.CreateInstance(type);// 创建对象
            return oinstance as IBuilder;
        }
    }
}
