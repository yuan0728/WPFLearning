using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.AutofacWPF
{
    public class LogInterceptor : IInterceptor
    {
        // invocation：将要拦截的方法
        public void Intercept(IInvocation invocation)
        {
            var args = invocation.Arguments;
            if (!invocation.Method.IsDefined(typeof(LogAttribute), false))
            {
                invocation.Proceed();
                return;
            }

            // 执行日志保留记录
            Console.WriteLine("---在方法执行前记录日志---");
            // 执行拦截的方法逻辑
            invocation.Proceed();
            Console.WriteLine("---在方法执行后记录日志---");

        }
    }
}
