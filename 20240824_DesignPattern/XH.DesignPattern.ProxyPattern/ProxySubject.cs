using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.DesignPattern.ProxyPattern
{
    /// <summary>
    /// 代理--包一层
    /// 提供了日志  异常功能，避免对real的修改---
    /// 把real的业务逻辑和通用逻辑分离
    /// 
    /// 单例代理---Real只实例化一次--static--内存唯一且只初始化一次
    /// 缓存代理---数据重用以提升效率--
    /// 延迟--鉴权--事务--监控。。。
    /// 包治百病
    /// 
    /// AOP面向切面编程，大部分都是基于代理实现的
    /// </summary>
    public class ProxySubject : ISubject
    {
        /// <summary>
        /// RealSubject只实例化一次，单例代理
        /// </summary>
        private static ISubject _iSubject = new RealSubject();

        /// <summary>
        /// 缓存代理--提升性能
        /// 查询票
        /// </summary>
        /// <returns></returns>
        public bool GetSomething()
        {
            //bool bResult = _iSubject.GetSomething(); 
            //return bResult;
            
            string key = $"{nameof(ProxySubject)}_{nameof(GetSomething)}";
            bool bResult = false;
            if (CustomCache.Exist(key))
            {
                bResult = CustomCache.Get<bool>(key);
            }
            else
            {
                bResult = _iSubject.GetSomething();
                CustomCache.Add(key, bResult);
            }

            return bResult;
            ////return _iSubject.GetSomething();
        }


        /// <summary>
        /// 日志--异常处理--只要通过Proxy来调用 就能获得这两个功能
        /// 买票
        /// </summary>
        public void DoSomething()
        {
            try
            {
                Console.WriteLine("This is DoSomething Before");
                _iSubject.DoSomething();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }


    }
}
