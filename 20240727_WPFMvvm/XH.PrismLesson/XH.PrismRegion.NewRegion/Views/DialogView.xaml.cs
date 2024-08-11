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

namespace XH.PrismRegion.NewRegion.Views
{
    /// <summary>
    /// DialogView.xaml 的交互逻辑
    /// </summary>
    public partial class DialogView : UserControl
    {
        public DialogView(IRegionManager regionManager)
        {
            InitializeComponent();
            // region 有个扫描时机，在Shell中会扫描一次，其他的需要手动加入并重新更新
            // 把当前的所有 region 都放入到regionManager中，重新扫描
            RegionManager.SetRegionManager(this, regionManager);
            // 更新下regionManager集合
            RegionManager.UpdateRegions();

            this.Unloaded += (o, e) =>
            {
                var rm = RegionManager.GetRegionManager(this);
                //rm.Regions.Remove("DialogRegion");
                // 释放所有的Name 等同于上面
                rm.Regions.FirstOrDefault(x => rm.Regions.Remove(x.Name));
            };
        }
    }
}
