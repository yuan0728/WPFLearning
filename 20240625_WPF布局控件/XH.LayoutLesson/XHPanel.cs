using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace XH.LayoutLesson
{
    /// <summary>
    /// 瀑布布局
    /// </summary>
    public class XHPanel : Panel
    {
        // 如果是普通属性 则需要手动刷新才是影响布局
        // 空隙
        //public double ColumnSpace { get; set; } = 0;
        //public double RowSpace { get; set; } = 0;

        private double _rowSpace = 0;

        public double RowSpace
        {
            get { return _rowSpace; }
            set
            {
                _rowSpace = value;
                this.InvalidateVisual();
            }
        }

        private double _columnSpace = 0;

        public double ColumnSpace
        {
            get { return _columnSpace; }
            set
            {
                _columnSpace = value;
                // 重新布局
                this.InvalidateVisual();
            }
        }


        // 测量
        protected override Size MeasureOverride(Size availableSize)
        {
            double total_y = 0; // 累计高度
            // availableSize 整个区域
            // 遍历所有的子项
            double per_width = (availableSize.Width - ColumnSpace * 2) / 3;
            foreach (UIElement item in this.InternalChildren)
            {
                //item.Measure(new Size(per_width, double.MaxValue));
                item.Measure(new Size(per_width, availableSize.Height));
                total_y += item.DesiredSize.Height;
            }
            return new Size(availableSize.Width, total_y);
        }
        // 排列
        protected override Size ArrangeOverride(Size finalSize)
        {
            double offset_y = 0, offset_x = 0;
            double per_width = (finalSize.Width - ColumnSpace * 2) / 3;
            double maxHeight = 0;
            List<Test> testList = new List<Test>();
            for (int i = 0; i < this.InternalChildren.Count; i++)
            {
                UIElement item = this.InternalChildren[i];
                if (i == 0)
                {
                    item.Arrange(new Rect(offset_x, (offset_y + RowSpace), per_width, item.DesiredSize.Height));
                    //maxHeight = Math.Max(maxHeight, item.DesiredSize.Height);
                    testList.Add(new Test { ValueX = 0, TotalColumn = item.DesiredSize.Height });
                }
                else if (i == 1)
                {
                    item.Arrange(new Rect(per_width, (offset_y + RowSpace), per_width, item.DesiredSize.Height));
                    //maxHeight = Math.Max(maxHeight, item.DesiredSize.Height);
                    testList.Add(new Test { ValueX = per_width, TotalColumn = item.DesiredSize.Height });
                }
                else if (i == 2)
                {
                    item.Arrange(new Rect(per_width * 2, (offset_y + RowSpace), per_width, item.DesiredSize.Height));
                    //maxHeight = Math.Max(maxHeight, item.DesiredSize.Height);
                    testList.Add(new Test { ValueX = per_width * 2, TotalColumn = item.DesiredSize.Height });
                }
                else
                {
                    double minC = 10000;
                    foreach (var m in testList)
                    {
                        minC = Math.Min(minC, m.TotalColumn);
                    }
                    Test test = new Test() { TotalColumn = minC};
                    testList.ForEach(f =>
                    {
                        if(test.TotalColumn == f.TotalColumn)
                        {
                            test.ValueX = f.ValueX;
                        }
                    });
                    item.Arrange(new Rect(test.ValueX, test.TotalColumn, per_width, item.DesiredSize.Height));
                    //maxHeight = Math.Max(maxHeight, item.DesiredSize.Height);
                    //testList.Add(new Test { ValueX = per_width * 2, TotalColumn = (offset_y + RowSpace) });
                    testList.ForEach( f => { 
                        if(f.ValueX == test.ValueX)
                        {
                            f.TotalColumn += item.DesiredSize.Height;
                        }
                    });
                }
                //item.Arrange(new Rect(offset_x, (offset_y + RowSpace), per_width, item.DesiredSize.Height));
                //maxHeight = Math.Max(maxHeight, item.DesiredSize.Height);

                //if (i % 3 == 0)
                //{
                //    offset_y += (maxHeight + _rowSpace);
                //    offset_x = 0;
                //    maxHeight = 0;
                //}
                //else
                //    offset_x += (per_width + _columnSpace);

            }
            return base.ArrangeOverride(finalSize);
        }
    }
    class Test
    {
        public double ValueX { get; set; } // X坐标
        public double TotalColumn { get; set; } // 列总高度
    }
}
