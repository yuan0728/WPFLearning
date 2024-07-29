using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace XH.BindingLesson.BindingProperties
{
    public class GenderConverter : IValueConverter
    {
        // 源到目标
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // 
            if(int.Parse(value.ToString()) == int.Parse(parameter.ToString()))
                return true;
            else
                return false;
        }
        
        // 目标到源
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //
            if(bool.Parse(value.ToString()))
                return true;
            return null;
        }
    }
}
