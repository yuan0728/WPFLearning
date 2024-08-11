using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.PrismRegion.Navigation.ViewModels.Pages
{
    public class ViewBViewModel : INavigationAware
    {
        public string Title { get; set; } = "View B";
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            string arg = navigationContext.Parameters.GetValue<string>("A");
        }
    }
}
