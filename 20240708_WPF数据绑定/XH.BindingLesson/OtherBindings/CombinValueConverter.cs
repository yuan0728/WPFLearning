using System.Globalization;
using System.Windows.Data;

namespace XH.BindingLesson.OtherBindings
{
    public class CombinValueConverter : IMultiValueConverter
    {
        // 源到目标
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string v = string.Empty;
            foreach (var item in values)
            {
                v += item+",";
            }
            return v.TrimEnd(',');
        }

        // 目标到源
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {

            string[] str = value.ToString().Split(',');
            object[] result = new object[str.Length];
            result[0] = int.Parse(str[0].ToString());
            result[1] = str[1].ToString();

            return result;
        }
    }
}
