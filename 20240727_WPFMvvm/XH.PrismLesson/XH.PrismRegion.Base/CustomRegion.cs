using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace XH.PrismRegion.Base
{
    // 自定义Region
    public class CustomRegion : RegionAdapterBase<UniformGrid>
    {
        public CustomRegion(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {

        }

        protected override void Adapt(IRegion region, UniformGrid regionTarget)
        {
            region.Views.CollectionChanged += (o, e) =>
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    foreach (UIElement view in region.Views)
                    {
                        regionTarget.Children.Add(view);
                    }
                }
                else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
                {
                    foreach (UIElement view in region.Views)
                    {
                        regionTarget.Children.Remove(view);
                    }
                }
            };
        }

        protected override IRegion CreateRegion()
        {
            // 返回激活的Region区域
            return new AllActiveRegion();
        }
    }
}
