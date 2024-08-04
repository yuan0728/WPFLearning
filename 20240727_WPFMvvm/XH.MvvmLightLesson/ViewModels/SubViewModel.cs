using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using XH.MvvmLightLesson.DataAccess;
using XH.MvvmLightLesson.Models;

namespace XH.MvvmLightLesson.ViewModels
{
    public class SubViewModel : ViewModelBase //ObservableObject
    {
        public SubViewModel(IDataAccess da)
        {
            
        }
    }
}
