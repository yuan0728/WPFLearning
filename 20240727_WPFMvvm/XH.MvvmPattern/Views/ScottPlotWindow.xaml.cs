using ScottPlot;
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

namespace XH.MvvmPattern.Views
{
    /// <summary>
    /// ScottPlotWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ScottPlotWindow : Window
    {
        public ScottPlotWindow()
        {
            InitializeComponent();
            //this.Loaded += ScottPlotWindow_Loaded;
        }

        private void ScottPlotWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var plt = wpf_plot.Plot;
            double[] datas = DataGen.RandomWalk(new Random(), 10);
            var series = plt.AddSignal(datas);
            wpf_plot.Refresh();
        }
    }
}
