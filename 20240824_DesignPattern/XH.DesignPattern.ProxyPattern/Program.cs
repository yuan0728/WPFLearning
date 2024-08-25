using System;

namespace XH.DesignPattern.ProxyPattern
{
    /// <summary>
    /// 通过ProxySubject完成对RealSubject的访问
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            {
                Console.WriteLine("**************");
                ISubject subject = new RealSubject();
                subject.GetSomething(); //查票
                subject.DoSomething();   //买票
            }

            //业务逻辑已经很复杂了，不想因为通用逻辑而不断的调整
            //代理出现之后，解决的是: 可以增加一些公共的业务逻辑；  而不用修改历史代码

            {
                Console.WriteLine("**************");
                ISubject subject = new ProxySubject();
                subject.DoSomething();
                subject.GetSomething();
            }
            {
                // 代理模式就是调用方法的时候进行加入其他业务的组合
                // 代理就是原来的的业务和现有的业务进行组合
            }
        }
    }
}
