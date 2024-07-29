using System.Configuration;
using System.Data;
using System.Windows;
using XH.Mvvm.Base;
using XH.Mvvm.Views;

namespace XH.Mvvm
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //WindowProvider.Register<SubWindow>("AAA");
        }
    }

}
