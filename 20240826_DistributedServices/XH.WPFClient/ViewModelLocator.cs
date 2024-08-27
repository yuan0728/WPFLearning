using Autofac;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.WPFClient.ViewModels;
using XH.WPFDbModels.Contexts;
using XH.WPFInterfaces;
using XH.WPFServices;

namespace XH.WPFClient
{
    public class ViewModelLocator
    {
        IContainer container;
        public ViewModelLocator()
        {
            // 注册
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<MainWindowViewModel>();
            builder.RegisterType<XiaoHaiStudyDbContext>().As<DbContext>();
            builder.RegisterType<ScoreInfoService>().As<IScoreInfoService>();

            container = builder.Build();

        }

        public MainWindowViewModel MainWindowViewModel { get => container.Resolve<MainWindowViewModel>(); }
        //public IMainViewModel MainViewModel { get => nige1container.Resolve<IMainViewModel>(); }
    }
}
