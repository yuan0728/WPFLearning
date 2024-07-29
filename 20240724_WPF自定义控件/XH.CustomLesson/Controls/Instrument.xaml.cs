using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace XH.CustomLesson.Controls
{
    /// <summary>
    /// Instrument.xaml 的交互逻辑
    /// </summary>
    public partial class Instrument : UserControl
    {
        // 当前值 
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(Instrument),
                new PropertyMetadata(default(double), new PropertyChangedCallback(OnPropertyChanged)));

        // 最小刻度
        public double Minimum
        {
            get { return (double)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }
        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(double), typeof(Instrument),
                new PropertyMetadata(default(double), new PropertyChangedCallback(OnPropertyChanged)));

        // 最大刻度
        public double Maximum
        {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }
        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(double), typeof(Instrument),
                new PropertyMetadata(default(double), new PropertyChangedCallback(OnPropertyChanged)));

        //// 间隔
        //public double Interval
        //{
        //    get { return (double)GetValue(IntervalProperty); }
        //    set { SetValue(IntervalProperty, value); }
        //}
        //public static readonly DependencyProperty IntervalProperty =
        //    DependencyProperty.Register("Interval", typeof(double), typeof(Instrument), new PropertyMetadata(default(double), new PropertyChangedCallback(OnPropertyChanged)));

        // 大刻度的个数
        public int ScaleCount
        {
            get { return (int)GetValue(ScaleCountProperty); }
            set { SetValue(ScaleCountProperty, value); }
        }
        public static readonly DependencyProperty ScaleCountProperty =
            DependencyProperty.Register("ScaleCount", typeof(int), typeof(Instrument),
                new PropertyMetadata(default(int), new PropertyChangedCallback(OnPropertyChanged)));

        // 刻度的厚度
        public double ScaleThickness
        {
            get { return (double)GetValue(ScaleThicknessProperty); }
            set { SetValue(ScaleThicknessProperty, value); }
        }
        public static readonly DependencyProperty ScaleThicknessProperty =
            DependencyProperty.Register("ScaleThickness", typeof(double), typeof(Instrument),
                new PropertyMetadata(default(double), new PropertyChangedCallback(OnPropertyChanged)));
        // 刻度的颜色
        public Brush ScaleBrush
        {
            get { return (Brush)GetValue(ScaleBrushProperty); }
            set { SetValue(ScaleBrushProperty, value); }
        }
        public static readonly DependencyProperty ScaleBrushProperty =
            DependencyProperty.Register("ScaleBrush", typeof(Brush), typeof(Instrument),
                new PropertyMetadata(default(Brush), new PropertyChangedCallback(OnPropertyChanged)));

        // 指针的颜色
        public Brush PointerBrush
        {
            get { return (Brush)GetValue(PointerBrushProperty); }
            set { SetValue(PointerBrushProperty, value); }
        }
        public static readonly DependencyProperty PointerBrushProperty =
            DependencyProperty.Register("PointerBrush", typeof(Brush), typeof(Instrument),
                new PropertyMetadata(default(Brush), new PropertyChangedCallback(OnPropertyChanged)));

        // 刻度字体大小 
        public new double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }
        public static new readonly DependencyProperty FontSizeProperty =
            DependencyProperty.Register("FontSize", typeof(double), typeof(Instrument),
                new PropertyMetadata(9.0, new PropertyChangedCallback(OnPropertyChanged)));




        public Instrument()
        {
            InitializeComponent();

            SetCurrentValue(MinimumProperty, 0d);
            SetCurrentValue(MaximumProperty, 100d);
            //SetCurrentValue(IntervalProperty, 10d);

            SizeChanged += (se, ev) => { Refresh(); };
        }

        static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            => (d as Instrument).Refresh();

        private void Refresh()
        {
            // 圆
            this.border.Width = Math.Min(RenderSize.Width, RenderSize.Height);
            this.border.Height = Math.Min(RenderSize.Width, RenderSize.Height);
            this.border.CornerRadius = new CornerRadius(this.border.Width / 2);
            // 半径
            double radius = this.border.Width / 2;

            this.canvasPlate.Children.Clear();
            if (ScaleCount <= 0 || radius <= 0) return;

            // 画边
            string borderPathData = $"M4,{radius}A{radius - 4} {radius - 4} 0 1 1 {radius} {this.border.Height - 4}";
            // 将字符串转换成Geometry
            var converter = TypeDescriptor.GetConverter(typeof(Geometry));
            //this.plateBorder.Data = (Geometry)converter.ConvertFrom(borderPathData);
            this.plateBorder.Data = PathGeometry.Parse(borderPathData);



            // 计算刻度
            double label = this.Minimum;
            double interval = 0;
            double step = 270.0 / (this.Maximum - this.Minimum);

            // 计算小刻度
            for (int i = 0; i < this.Maximum - this.Minimum; i++)
            {
                //添加刻度线
                Line lineScale = new Line();
                // 角度需要转换弧度
                lineScale.X1 = radius - (radius - 13) * Math.Cos(step * i * Math.PI / 180);
                lineScale.Y1 = radius - (radius - 13) * Math.Sin(step * i * Math.PI / 180);
                lineScale.X2 = radius - (radius - 8) * Math.Cos(step * i * Math.PI / 180);
                lineScale.Y2 = radius - (radius - 8) * Math.Sin(step * i * Math.PI / 180);

                lineScale.Stroke = this.ScaleBrush;
                lineScale.StrokeThickness = this.ScaleThickness;

                this.canvasPlate.Children.Add(lineScale);
            }
            // 计算大刻度
            do
            {
                //添加刻度线
                Line lineScale = new Line();
                lineScale.X1 = radius - (radius - 20) * Math.Cos(interval * step * Math.PI / 180);
                lineScale.Y1 = radius - (radius - 20) * Math.Sin(interval * step * Math.PI / 180);
                lineScale.X2 = radius - (radius - 8) * Math.Cos(interval * step * Math.PI / 180);
                lineScale.Y2 = radius - (radius - 8) * Math.Sin(interval * step * Math.PI / 180);

                lineScale.Stroke = this.ScaleBrush;
                lineScale.StrokeThickness = this.ScaleThickness;

                this.canvasPlate.Children.Add(lineScale);

                TextBlock txtScale = new TextBlock();
                txtScale.Text = label.ToString("0");
                txtScale.Width = 34;
                txtScale.TextAlignment = TextAlignment.Center;
                txtScale.Foreground = new SolidColorBrush(Colors.White);
                txtScale.RenderTransform = new RotateTransform() { Angle = 45, CenterX = 17, CenterY = 8 };
                txtScale.FontSize = this.FontSize;
                Canvas.SetLeft(txtScale, radius - (radius - 34) * Math.Cos(interval * step * Math.PI / 180) - 17);
                Canvas.SetTop(txtScale, radius - (radius - 34) * Math.Sin(interval * step * Math.PI / 180) - 8);
                this.canvasPlate.Children.Add(txtScale);

                interval += (this.Maximum - this.Minimum) / this.ScaleCount;
                label += (this.Maximum - this.Minimum) / this.ScaleCount;

            } while (interval <= this.Maximum - this.Minimum);


            // 修改指针
            string sData = "M{0} {1},{2} {0},{0} {3},{3} {0},{0} {1}";
            sData = string.Format(sData, radius, radius + 2, this.border.Width - radius / 10, radius - 4);
            converter = TypeDescriptor.GetConverter(typeof(Geometry));
            this.pointer.Data = (Geometry)converter.ConvertFrom(sData);
            this.pointer.Fill = this.PointerBrush;

            //DoubleAnimation da = new DoubleAnimation((Value - Minimum) * step + 135, new Duration(TimeSpan.FromMilliseconds(200)));
            //this.rtPointer.BeginAnimation(RotateTransform.AngleProperty, da);
            this.rtPointer.Angle = (Value - Minimum) * step + 135;

            // 修改圆  M100 200 A100 100 0 1 1 200 300
            // 厚度
            double thickness = radius / 2;
            this.circle.StrokeThickness = thickness;
            double startX = radius - thickness / 2;
            double startY = radius;
            double endX = radius - (radius - thickness / 2) * Math.Cos((Value - Minimum) * step * Math.PI / 180);
            double endY = radius - (radius - thickness / 2) * Math.Sin((Value - Minimum) * step * Math.PI / 180);

            int isLarge = 1;
            if ((Value - Minimum) * step < 180)
                isLarge = 0;

            sData = $"M{startX},{startY}A{radius / 2} {radius / 2} 0 1 1 {endX} {endY}";
            sData = $"M{thickness / 2},{radius}A{radius - thickness / 2} {radius - thickness / 2} 0 {isLarge} 1 {endX} {endY}";
            //sData = string.Format(sData, radius * 0.5, radius, radius * 1.5);
            this.circle.Data = (Geometry)converter.ConvertFrom(sData);
            this.circle.Visibility = Visibility.Visible;

            if (this.border.Width < 200)
                this.circle.Visibility = Visibility.Collapsed;
        }
    }
}
