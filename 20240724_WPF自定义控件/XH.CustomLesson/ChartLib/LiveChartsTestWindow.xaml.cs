using LiveCharts;
using LiveCharts.Wpf;
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

namespace XH.CustomLesson.ChartLib
{
    /// <summary>
    /// ChartTestWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LiveChartsTestWindow : Window
    {
        public SeriesCollection SeriesList { get; set; } = new SeriesCollection();
        public Func<double, string> YLableFormatter { get; set; } = d =>d.ToString("0.00");
        public LiveChartsTestWindow()
        {
            InitializeComponent();

            this.DataContext = this;

            //YLableFormatter = YLableFormatterFunc;

            SeriesList.Add(new LineSeries
            {
                Values = new ChartValues<double> { 75, 14, 36, 33, 89, 76, 23, 21, 77, 90, 21, 22, 54, 90, 32, 47, 97, 81, 63, 21 },
                Title = "压力",
                Stroke = Brushes.Green,
            });
        }
        //private string YLableFormatterFunc(double value)
        //{
        //    // 保留两位小数
        //    return value.ToString("0.00");
        //}
    }
}
