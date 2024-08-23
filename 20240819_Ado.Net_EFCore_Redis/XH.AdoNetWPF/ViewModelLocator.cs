using Autofac;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.AdoNetWPF.ViewModels;
using XH.DbModels.Contexts;
using XH.Interfaces;
using XH.Services;

namespace XH.AdoNetWPF
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
