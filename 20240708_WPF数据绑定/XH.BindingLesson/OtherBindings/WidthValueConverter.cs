using System.Globalization;
using System.Windows.Data;

namespace XH.BindingLesson.OtherBindings
{
    public class WidthValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return double.Parse(values[0].ToString()) * double.Parse(values[1].ToString());
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
