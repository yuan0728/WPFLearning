using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.AutofacWPF
{
    public class MonitorInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            if (!invocation.Method.IsDefined(typeof(MonitorAttribute), false))
            {
                invocation.Proceed();
                return;
            }
            Stopwatch sw = new Stopwatch();
            sw.Start();
            invocation.Proceed();
            sw.Stop();
            Console.WriteLine("MonitorInterceptor 本次方法共耗时：" + sw.ElapsedMilliseconds);
        }
    }
}
