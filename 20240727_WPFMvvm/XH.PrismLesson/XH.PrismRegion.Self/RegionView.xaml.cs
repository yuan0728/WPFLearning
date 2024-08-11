using Prism.Common;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XH.PrismRegion.Self
{
    /// <summary>
    /// RegionView.xaml 的交互逻辑
    /// </summary>
    public partial class RegionView : UserControl
    {
        public RegionView()
        {
            InitializeComponent();

            RegionContext.GetObservableContext(this).PropertyChanged += RegionView_PropertyChanged;
        }

        private void RegionView_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var context = ((ObservableObject<object>)sender).Value.ToString();
            DataContext = context;
        }
    }
}
