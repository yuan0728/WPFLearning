using Autofac;
using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.AutofacWPF
{
    public class ViewModelLocator
    {
        IContainer container;
        public ViewModelLocator()
        {
            // 注册
            ContainerBuilder builder = new ContainerBuilder();

            // 加入拦截器
            // 加入包：Autofac.Extras.DynamicProxy;
            builder.RegisterType<LogInterceptor>();
            builder.RegisterType<MonitorInterceptor>();

            // InterceptedBy：拦截器类
            // EnableClassInterceptors：基于类的拦截器
            // MainVeiwModel中的方法必须是虚方法 virtual
            //builder.RegisterType<MainViewModel>()
            //       .InterceptedBy(typeof(LogInterceptor))
            //       .InterceptedBy(typeof(MonitorInterceptor))
            //       .EnableClassInterceptors();
            // EnableInterfaceInterceptors：基于接口的拦截器
            builder.RegisterType<MainViewModel>()
                   .InterceptedBy(typeof(LogInterceptor))
                   .InterceptedBy(typeof(MonitorInterceptor))
                   .EnableClassInterceptors();

            container = builder.Build();



        }

        public MainViewModel MainViewModel { get => container.Resolve<MainViewModel>(); }
        //public IMainViewModel MainViewModel { get => nige1container.Resolve<IMainViewModel>(); }
    }
}
