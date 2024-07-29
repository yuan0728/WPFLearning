using System.Collections.ObjectModel;
using System.Windows;

namespace XH.BindingLesson.Example
{
    /// <summary>
    /// ColumnChartWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ColumnChartWindow : Window
    {
        public ColumnChartWindow()
        {
            InitializeComponent();

            this.DataContext = new ChartDataSource();

        }
    }

    public class ChartDataSource
    {
        public ObservableCollection<ColumnItem> datas { get; set; } = new ObservableCollection<ColumnItem>();

        public ChartDataSource()
        {
            for (int i = 0; i < 15; i++)
            {
                datas.Add(new ColumnItem()
                {
                    Value = new Random().Next(10, 200),
                    LabelText = DateTime.Now.ToString("mm:ss"),
                });
            }

            Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(1000);
                    // 报错 ：跨UI线程  ObservableCollection这个类型的数据 会导致界面的对象渲染变更（控件的增减）
                    // 界面上的操作都需要在UI线程（主线程）处理
                    // Task属于子线程（后台线程）
                    try
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            datas.Add(new ColumnItem()
                            {
                                Value = new Random().Next(10, 200),
                                LabelText = DateTime.Now.ToString("mm:ss"),
                            });
                            if (datas.Count > 20)
                                datas.RemoveAt(0);
                        });
                    }
                    catch (Exception ex) { }
                }
            });
        }
    }

    public class ColumnItem
    {
        public string LabelText { get; set; }
        public int Value { get; set; }
    }
}
