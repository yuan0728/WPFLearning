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
using System.Windows.Shapes;

namespace XH.EventLesson
{
    /// <summary>
    /// MouseEventWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MouseEventWindow : Window
    {
        public MouseEventWindow()
        {
            InitializeComponent();
        }


        #region 光标移动色块

        private Point start_point_border;
        private Point start_point_canvas;
        private bool is_moving_border = false;
        private bool is_moving_canvas = false;
        private double start_x_border, start_y_border, start_x_canvas, start_canvas;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Border border = (Border)sender;
            // 获取光标canvas上的当前位置
            start_point_border = e.GetPosition(this.canvas);

            start_x_border = Canvas.GetLeft(border);
            start_y_border = Canvas.GetTop(border);

            is_moving_border = true;

            // 第一种 把对象绑定到光标上 两种处理
            Mouse.Capture(border);

            e.Handled = true;
            // 第二种 强制捕捉鼠标
            //this.border.CaptureMouse();
        }

        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            Border border = (Border)sender;
            if (!is_moving_border) return;

            // 光标移动后 在canvas上的当前位置
            Point p = e.GetPosition(this.canvas);
            double offset_x = p.X - start_point_border.X;
            double offset_y = p.Y - start_point_border.Y;

            //Canvas.SetLeft(this.border, offset_x + start_x);
            //Canvas.SetTop(this.border, offset_y + start_y);
            // 移动的差值是光标开始和移动的数值
            Canvas.SetLeft(border, offset_x + start_x_border);
            Canvas.SetTop(border, offset_y + start_y_border);

            e.Handled = true;
        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            is_moving_border = false;

            // 释放控件鼠标强制捕捉
            Mouse.Capture(null);
            //this.border.ReleaseMouseCapture();
            e.Handled = true;
        }

        #endregion

        #region Canvas 框选
        Rectangle rectangle = new Rectangle()
        {
            Stroke = Brushes.Red,
            StrokeDashArray= new DoubleCollection { 2, 2 },
            StrokeThickness = 1,
        };

        private Point current_point;
        private void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            start_point_canvas = e.GetPosition(this.canvas);

            this.canvas.Children.Remove(rectangle);
            this.canvas.Children.Add(rectangle);

            Canvas.SetLeft(rectangle, start_point_canvas.X);
            Canvas.SetTop(rectangle, start_point_canvas.Y);

            // 初始化矩形
            rectangle.Width = 0;
            rectangle.Height = 0;

            is_moving_canvas = true;
        }

        private void canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            is_moving_canvas = false;

            this.canvas.Children.Remove(rectangle);
        }

        private void canvas_Click(object sender, RoutedEventArgs e)
        {

        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!is_moving_canvas) return;

            current_point = e.GetPosition(this.canvas);

            rectangle.Width = (current_point.X - start_point_canvas.X) < 0 ? 0 : current_point.X - start_point_canvas.X;
            rectangle.Height = (current_point.Y - start_point_canvas.Y) < 0 ? 0 : current_point.Y - start_point_canvas.Y;

        }

        #endregion
    }
}
