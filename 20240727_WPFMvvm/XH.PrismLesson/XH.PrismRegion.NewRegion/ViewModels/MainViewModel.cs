using Prism.Commands;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.PrismRegion.NewRegion.ViewModels
{
    public class MainViewModel
    {
        public DelegateCommand ShowDialogCommand { get; set; }
        public MainViewModel(IDialogService dialogService)
        {
            ShowDialogCommand = new DelegateCommand(() =>
            {
                dialogService.ShowDialog("DialogView");
            });
        }
    }
}
