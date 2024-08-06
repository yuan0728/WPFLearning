using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.MvvmLightLesson.Base;
using XH.MvvmLightLesson.BLL;
using XH.MvvmLightLesson.DataAccess;
using XH.MvvmLightLesson.Views;

namespace XH.MvvmLightLesson.ViewModels
{
    public class ViewModelCenter
    {
        SimpleIoc _simpleIoc = SimpleIoc.Default;

        // 自定义IOC容器
        XiaohaiIoc _xiaohaiIoc = XiaohaiIoc.Default;
        public ViewModelCenter()
        {
            // 注册一个Ioc实例
            //_simpleIoc.Register<IDataAccess, MySqlDA>();
            //_simpleIoc.Register<MainViewModel>();
            //_simpleIoc.Register<SubViewModel>();
            _xiaohaiIoc.RegisterSingle<IDataAccess, SqlServerDA>("SqlServerDA");
            _xiaohaiIoc.RegisterSingle<IDataAccess, MySqlDA>();
            _xiaohaiIoc.RegisterSingle<ILoginBLL, LoginBLL>();
            _xiaohaiIoc.RegisterSingle<MainViewModel>();

            // 创建多个实例 untiy  --  key
            // SimpleIoc：不可以重复创建实例
            //_simpleIoc.Register<IDataAccess,SqlServerDA>();

            //var model = MainWin;
            //MainWin.Value = "ABC";
            //var model1 = MainWin;

            // 另一个 页面编辑后 关闭后 需要进行对应VM的销毁
        }

        // GetInstance：获取一个实例
        //public MainViewModel MainWin { get => _simpleIoc.GetInstance<MainViewModel>(); }
        //public SubViewModel SubWin { get => _simpleIoc.GetInstance<SubViewModel>(); }
        public MainViewModel MainWin { get => _xiaohaiIoc.Resolve<MainViewModel>(); }
        public SubViewModel SubWin { get => _xiaohaiIoc.Resolve<SubViewModel>(); }
    }
}
