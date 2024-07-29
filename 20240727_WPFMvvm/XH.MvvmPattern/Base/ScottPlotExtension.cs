using ScottPlot;
using System.Collections.ObjectModel;
using System.Windows;

namespace XH.MvvmPattern.Base
{
    public class ScottPlotExtension
    {

        // 依赖附加属性
        // 这个属性里面可以知道绑定的属性 以及被附加的对象
        public static ObservableCollection<double> GetValues(DependencyObject obj)
        {
            return (ObservableCollection<double>)obj.GetValue(ValuesProperty);
        }

        public static void SetValues(DependencyObject obj, int value)
        {
            obj.SetValue(ValuesProperty, value);
        }

        // Using a DependencyProperty as the backing store for Values.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValuesProperty =
            DependencyProperty.RegisterAttached(
                "Values",
                typeof(ObservableCollection<double>),
                typeof(ScottPlotExtension),
                new PropertyMetadata(null, new PropertyChangedCallback(OnValuesChanged)));

        // 当给Value赋值的时候 才会触发
        private static void OnValuesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var plt = d as WpfPlot;
            var newPlt = plt.Plot;
            var new_list = (ObservableCollection<double>)e.NewValue;

            var signal = newPlt.AddSignal(new_list.ToArray());
            // 对集合实例进行子项增减的时候 进行回调
            new_list.CollectionChanged += (s, e) =>
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
                {
                    signal.Update(new_list.ToArray());
                    plt.Refresh();
                }
            };

            plt.Refresh();
        }
    }
}
