﻿using System.Configuration;
using System.Data;
using System.Windows;

namespace XH.PrismRegion.NewRegion
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
