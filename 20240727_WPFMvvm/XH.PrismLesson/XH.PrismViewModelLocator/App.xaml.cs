using Prism.Mvvm;
using Prism.Unity;
using System.Configuration;
using System.Data;
using System.Windows;

namespace XH.PrismViewModelLocator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
           new StartUp().Run();
        }
    }

}
