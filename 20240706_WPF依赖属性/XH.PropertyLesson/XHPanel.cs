using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace XH.PropertyLesson
{
    /// <summary>
    /// 瀑布布局
    /// </summary>
    public class XHPanel : Panel
    {

        //propa + tab
        // 依赖附加属性
        // 基本过程：声明、注册、包装
        // 依赖附加属性必须在依赖对象，附加属性不一定，关注的是被附加的对象是否是依赖对象
        // 方法封装
        public static int GetIndex(DependencyObject obj)
        {
            return (int)obj.GetValue(IndexProperty);
        }

        public static void SetIndex(DependencyObject obj, int value)
        {
            obj.SetValue(IndexProperty, value);
        }

        // 声明与注册
        public static readonly DependencyProperty IndexProperty =
            DependencyProperty.RegisterAttached("Index", typeof(int), typeof(XHPanel), new PropertyMetadata(-1));




        #region 

        //private double _rowSpace = 0;

        //public double RowSpace
        //{
        //    get { return _rowSpace; }
        //    set
        //    {
        //        _rowSpace = value;
        //        this.InvalidateVisual();
        //    }
        //}

        //private double _columnSpace = 0;

        //public double ColumnSpace
        //{
        //    get { return _columnSpace; }
        //    set
        //    {
        //        _columnSpace = value;
        //        // 重新布局
        //        this.InvalidateVisual();
        //    }
        //}

        #endregion

        public int Test
        {
            get { return (int)GetValue(TestProperty); }
            set { SetValue(TestProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TestProperty =
            DependencyProperty.Register("Test", typeof(int), typeof(XHPanel),
                new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.Inherits));




        public double RowSpace
        {
            get { return (double)GetValue(RowSpaceProperty); }
            set { SetValue(RowSpaceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RowSpace.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RowSpaceProperty =
            DependencyProperty.Register(
                "RowSpace",
                typeof(double),
                typeof(XHPanel),
                new PropertyMetadata(0.0, new PropertyChangedCallback(OnRowSpaceChanged)));

        private static void OnRowSpaceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as XHPanel).InvalidateVisual();
        }

        public double ColumnSpace
        {
            get { return (double)GetValue(ColumnSpaceProperty); }
            set { SetValue(ColumnSpaceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ColumnSpace.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColumnSpaceProperty =
            DependencyProperty.Register(
                "ColumnSpace",
                typeof(double),
                typeof(XHPanel),
                //new PropertyMetadata(0d,new PropertyChangedCallback(OnColumnSpaceChanged))
                // AffectsArrange： 影响排列
                // AffectsMeasure：影响测量
                // AffectsParentMeasure 影响上一级对象的测量
                // AffectsParentArrange 影响上一级对象的排列
                new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsArrange
                    | FrameworkPropertyMetadataOptions.AffectsMeasure)
                );

        private static void OnColumnSpaceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as XHPanel).InvalidateVisual();
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
                if (item is DependencyPropertyStudy dps)
                    dps.Index = 0;
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

            List<FrameworkElement> elements = new List<FrameworkElement>();

            for (int i = 0; i < this.InternalChildren.Count; i++)
            {
                elements.Add((FrameworkElement)this.InternalChildren[i]);
            }

            var newElements = elements.OrderBy(x => GetIndex(x)).ToList();

            for (int i = 1; i < newElements.Count+1; i++)
            {
                UIElement item = this.InternalChildren[i-1];
                //var index = GetIndex(item); // 获取对应对象的Index 附加属性值

                item.Arrange(new Rect(offset_x, offset_y, per_width, item.DesiredSize.Height));
                maxHeight = Math.Max(maxHeight, item.DesiredSize.Height);

                if (i % 3 == 0)
                {
                    offset_y += maxHeight + RowSpace;
                    offset_x = 0;
                    maxHeight = 0;
                }
                else
                    offset_x += per_width + ColumnSpace;

                //if (i == 0)
                //{
                //    item.Arrange(new Rect(offset_x, (offset_y + RowSpace), per_width, item.DesiredSize.Height));
                //    //maxHeight = Math.Max(maxHeight, item.DesiredSize.Height);
                //    testList.Add(new Test { ValueX = 0, TotalColumn = item.DesiredSize.Height });
                //}
                //else if (i == 1)
                //{
                //    item.Arrange(new Rect(per_width, (offset_y + RowSpace), per_width, item.DesiredSize.Height));
                //    //maxHeight = Math.Max(maxHeight, item.DesiredSize.Height);
                //    testList.Add(new Test { ValueX = per_width, TotalColumn = item.DesiredSize.Height });
                //}
                //else if (i == 2)
                //{
                //    item.Arrange(new Rect(per_width * 2, (offset_y + RowSpace), per_width, item.DesiredSize.Height));
                //    //maxHeight = Math.Max(maxHeight, item.DesiredSize.Height);
                //    testList.Add(new Test { ValueX = per_width * 2, TotalColumn = item.DesiredSize.Height });
                //}
                //else
                //{
                //    double minC = 10000;
                //    foreach (var m in testList)
                //    {
                //        minC = Math.Min(minC, m.TotalColumn);
                //    }
                //    Test test = new Test() { TotalColumn = minC };
                //    testList.ForEach(f =>
                //    {
                //        if (test.TotalColumn == f.TotalColumn)
                //        {
                //            test.ValueX = f.ValueX;
                //        }
                //    });
                //    item.Arrange(new Rect(test.ValueX, test.TotalColumn, per_width, item.DesiredSize.Height));
                //    //maxHeight = Math.Max(maxHeight, item.DesiredSize.Height);
                //    //testList.Add(new Test { ValueX = per_width * 2, TotalColumn = (offset_y + RowSpace) });
                //    testList.ForEach(f =>
                //    {
                //        if (f.ValueX == test.ValueX)
                //        {
                //            f.TotalColumn += item.DesiredSize.Height;
                //        }
                //    });
                //}

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
