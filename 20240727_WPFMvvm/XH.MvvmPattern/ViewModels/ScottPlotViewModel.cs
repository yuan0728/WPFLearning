using ScottPlot;
using System.Collections.ObjectModel;
using System.Windows;

namespace XH.MvvmPattern.ViewModels
{
    public class ScottPlotViewModel
    {
        public ObservableCollection<double> Datas { get; set; } 
        public ScottPlotViewModel()
        {
            Datas = new ObservableCollection<double>(DataGen.RandomWalk(new Random(), 10));

            // 实时监控 持续获取数据 
            Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(1000);

                    Application.Current.Dispatcher.BeginInvoke(() =>
                    {
                        Datas.Add(new Random().NextDouble());
                        Datas.RemoveAt(0);
                    });
                }
            });
        }
    }
}
