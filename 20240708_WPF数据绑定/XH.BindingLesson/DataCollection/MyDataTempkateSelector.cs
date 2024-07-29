using System.Windows;
using System.Windows.Controls;

namespace XH.BindingLesson.DataCollection
{
    public class MyDataTempkateSelector:DataTemplateSelector
    {
        public DataTemplate NormalTemplate { get; set; }
        public DataTemplate WarningTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var di = item as DataItem;
            if(di.State == 1)
                return WarningTemplate;
            return NormalTemplate;
        }
    }
}
