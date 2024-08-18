using Autofac;
using Autofac.Features.Indexed;
using System.Threading.Channels;

namespace XH.AutofacIoc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            // 容器的初始化
            ContainerBuilder builder = new ContainerBuilder();
            // 注册需要解析的对象类型  -- 默认不是单例模式
            //builder.RegisterType<Person>();
            // 单例模式注册：
            // ExternallyOwned：告诉这个容器永远不会释放这个容器
            //builder.RegisterInstance<Person>(new Person()).ExternallyOwned();

            // 最基本的 基于接口进行注册
            //builder.RegisterType<Man>().As<IPerson>();
            // 相同的接口类型，后面的注册会覆盖前面的
            // PreserveExistingDefaults：当前注册为非默认值
            //builder.RegisterType<Woman>().As<IPerson>().PreserveExistingDefaults();
            //builder.RegisterType<Woman>().As<IPerson>();

            // 单接口多实现
            //builder.RegisterType<Man>().Named<IPerson>("Man");
            //builder.RegisterType<Woman>().Named<IPerson>("Woman");
            // 或者以下代码也是可以的 不过Named的参数是string ，Keyed的参数是object
            //builder.RegisterType<Man>().Keyed<IPerson>(PersonType.Man);
            //builder.RegisterType<Woman>().Keyed<IPerson>(PersonType.Woman);

            // 构造函数选择与传值 
            // UsingConstructor：使用构造函数的类型是什么
            //builder.RegisterType<Man>().As<IPerson>().UsingConstructor(typeof(string));

            // 注册对象在IOC容器中的生命周期
            builder.RegisterType<Man>().As<IPerson>()
                   .OnRegistered(e => Console.WriteLine("在注册的时候调用！"))
                   .OnPreparing(e => Console.WriteLine("在准备创建的时候调用！"))
                   .OnActivating(e => Console.WriteLine("在创建之前调用！"))
                   .OnActivated(e => Console.WriteLine("在创建之后调用！"))
                   .OnRelease(e => Console.WriteLine("在释放占用的资源之前调用！"));

            IContainer container = builder.Build();

            //Person person = new Person();   
            // 修改为以下代码 
            //Person person = container.Resolve<Person>();
            // 通过接口来 接收实例
            //IPerson person = container.Resolve<IPerson>();  
            // 单接口多实现 接收实例
            //IPerson person = container.ResolveNamed<IPerson>("Man");
            //IPerson person = container.ResolveKeyed<IPerson>(PersonType.Man);
            //person.SayHello();

            // 可以获取到所有的PersonType, IPerson的实例 ，然后同过字典的方式调用方法
            //var ps = container.Resolve<IIndex<PersonType, IPerson>>();
            //ps[PersonType.Man].SayHello();
            //ps[PersonType.Woman].SayHello();

            // 通过NamedParameter 进行传值 通过key value
            //IPerson person = container.Resolve<IPerson>(new NamedParameter("arg", "1111"));        

            using (IPerson person = container.Resolve<IPerson>())
            {
                
            }
            
        }
    }

    public enum PersonType
    {
        Man, Woman
    }

}
