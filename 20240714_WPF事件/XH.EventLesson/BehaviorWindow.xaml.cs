using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace XH.EventLesson
{
    /// <summary>
    /// BehaviorWindow.xaml 的交互逻辑
    /// </summary>
    public partial class BehaviorWindow : Window
    {
        public BehaviorWindow()
        {
            InitializeComponent();
        }
    }
    // 创建一个行为类 用来封装事件逻辑：对象移动的事件逻辑

    public class DragMoveBehavior:Behavior<FrameworkElement>
    {
        private Point start_point_border;
        private Point start_point_canvas;
        private bool is_moving_border = false;
        private bool is_moving_canvas = false;
        private double start_x_border, start_y_border, start_x_canvas, start_canvas;
        // 执行当前行为所依附的对象的事件挂载
        protected override void OnAttached()
        {
            base.OnAttached();

            // AssociatedObject：所依附的对象
            AssociatedObject.MouseLeftButtonDown += AssociatedObject_MouseLeftButtonDown;
            AssociatedObject.MouseMove += AssociatedObject_MouseMove; 
            AssociatedObject.MouseLeftButtonUp += AssociatedObject_MouseLeftButtonUp; 
        }
        // 
        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.MouseLeftButtonDown -= AssociatedObject_MouseLeftButtonDown;
            AssociatedObject.MouseMove -= AssociatedObject_MouseMove;
            AssociatedObject.MouseLeftButtonUp -= AssociatedObject_MouseLeftButtonUp;
        }

        private void AssociatedObject_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            is_moving_border = false;

            // 释放控件鼠标强制捕捉
            Mouse.Capture(null);
            //this.border.ReleaseMouseCapture();
            e.Handled = true;
        }

        private void AssociatedObject_MouseMove(object sender, MouseEventArgs e)
        {
            if (!is_moving_border) return;

            // 光标移动后 在canvas上的当前位置
            Point p = e.GetPosition(AssociatedObject.Parent as Canvas);
            double offset_x = p.X - start_point_border.X;
            double offset_y = p.Y - start_point_border.Y;

            //Canvas.SetLeft(this.border, offset_x + start_x);
            //Canvas.SetTop(this.border, offset_y + start_y);
            // 移动的差值是光标开始和移动的数值
            Canvas.SetLeft(AssociatedObject, offset_x + start_x_border);
            Canvas.SetTop(AssociatedObject, offset_y + start_y_border);

            e.Handled = true;
        }

        private void AssociatedObject_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // 获取光标canvas上的当前位置
            start_point_border = e.GetPosition(AssociatedObject.Parent as Canvas);

            start_x_border = Canvas.GetLeft(AssociatedObject);
            start_y_border = Canvas.GetTop(AssociatedObject);

            is_moving_border = true;

            // 第一种 把对象绑定到光标上 两种处理
            Mouse.Capture(AssociatedObject);

            e.Handled = true;
            // 第二种 强制捕捉鼠标
            //this.border.CaptureMouse();
        }
    }
}
