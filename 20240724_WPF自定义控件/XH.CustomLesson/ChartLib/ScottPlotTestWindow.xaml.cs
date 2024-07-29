using ScottPlot;
using System.Windows;

namespace XH.CustomLesson.ChartLib
{
    /// <summary>
    /// ScottPlotTestWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ScottPlotTestWindow : Window
    {
        public ScottPlotTestWindow()
        {
            InitializeComponent();

            this.Loaded += ScottPlotTestWindow_Loaded;
        }

        private void ScottPlotTestWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // 数据加载
            var plt = wpf_plot.Plot;
            // 模拟序列数据
            double[] datas = DataGen.RandomWalk(new Random(),1000000);

            plt.AddSignal(datas);
            // 不调 Refresh 会报错 必须调用Refresh() 
            // YAxis：第一个Y轴
            // YAxis2：第二个Y轴
            plt.YAxis2.Ticks(true);
            plt.YAxis2.Color(System.Drawing.Color.Red);

            datas = DataGen.Cos(1000000);
            var series = plt.AddSignal(datas);
            //YAxisIndex 对应的Y轴 
            series.YAxisIndex = 1;

            // 可以有多个轴 第三个Y轴
            var yAxis3 = plt.AddAxis(ScottPlot.Renderable.Edge.Right,10,"新轴",System.Drawing.Color.Blue);
            datas = DataGen.Sin(1000000);
            series = plt.AddSignal(datas);
            series.YAxisIndex = 10;
            
            // 第二个X轴
            plt.XAxis2.Ticks(true);
            plt.XAxis2.Color(System.Drawing.Color.Green);
            datas = DataGen.Random(new Random(),100);
            var barPlot = plt.AddBar(datas, System.Drawing.Color.Orange);
            barPlot.XAxisIndex = 1;
            barPlot.YAxisIndex = 1;

            // 第三个X轴
            var xAxis3 = plt.AddAxis(ScottPlot.Renderable.Edge.Bottom,3, "第三个X轴", System.Drawing.Color.OrangeRed);
            xAxis3.Ticks(true);
            xAxis3.DateTimeFormat(true);
            // X轴时间格式化
            xAxis3.ManualTickSpacing(20, ScottPlot.Ticks.DateTimeUnit.Day);
            // 斜着显示
            xAxis3.TickLabelStyle(rotation: 45);

            // 第四个Y轴
            var yAxis4 = plt.AddAxis(ScottPlot.Renderable.Edge.Left,4, "第四个Y轴", System.Drawing.Color.OrangeRed);
            yAxis4.Ticks(true);
            yAxis4.DateTimeFormat(true);
            // Y轴格式化
            yAxis4.TickLabelFormat("P1", false);

            // 添加第三个数据序列 并且对齐到第三个X轴 和 第四个Y轴
            datas = DataGen.Sin(1000);
            double[] x_datas = new double[1000];
            DateTime dateTime = DateTime.Now;
            for (int i = 0; i < x_datas.Length; i++)
            {
                x_datas[i] = dateTime.AddDays(i).ToOADate();
            }    
            var scatterPlot = plt.AddScatterLines(x_datas, datas, System.Drawing.Color.Green);
            scatterPlot.YAxisIndex = 4;
            scatterPlot.XAxisIndex = 3;

            // 预警线
            var hl = plt.AddHorizontalLine(0.8, System.Drawing.Color.Red);
            // 对应到哪个Y轴
            //hl.YAxisIndex = 4;
            plt.AddVerticalLine(DateTime.Now.AddDays(50).ToOADate());

            wpf_plot.Refresh();
        }

    }
}
