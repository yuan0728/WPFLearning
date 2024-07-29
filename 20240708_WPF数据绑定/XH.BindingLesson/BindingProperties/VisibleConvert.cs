using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace XH.BindingLesson.BindingProperties
{
    public class VisibleConvert : IValueConverter
    {
        /// <summary>
        /// 数据从源到目标的时候 执行这个方法 将这个方法的结果显示在目标
        /// </summary>
        /// <param name="value">源数据</param>
        /// <param name="targetType">目标类型</param>
        /// <param name="parameter"></param>
        /// <param name="culture">基于什么文化处理（国际）</param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // 源数据
            return (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        /// 数据从目标到源的时候 执行这个方法 将这个方法的结果提交给源
        /// </summary>
        /// <param name="value">目标的数据</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Visibility)value == Visibility.Visible ? true : false;
        }
    }
}
