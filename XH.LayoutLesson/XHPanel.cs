using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace XH.LayoutLesson
{
    public class XHPanel : Panel
    {
        // 测量
        protected override Size MeasureOverride(Size availableSize)
        {
            // availableSize 整个区域
            // 遍历所有的子项
            foreach (UIElement item in this.InternalChildren)
            {
                item.Measure(availableSize);
            }
            return availableSize;
        }
        // 排列
        protected override Size ArrangeOverride(Size finalSize)
        {
            foreach(UIElement item in this.InternalChildren)
            {
                item.Arrange(new Rect(0, 0, finalSize.Width, finalSize.Height));
            }
            return base.ArrangeOverride(finalSize);
        }
    }
}
