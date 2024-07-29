using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace XH.PropertyLesson
{
    public class PWHelper
    {


        public static string GetPassword(DependencyObject obj)
        {
            return (string)obj.GetValue(PasswordProperty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj">所附加的对象</param>
        /// <param name="value"></param>
        public static void SetPassword(DependencyObject obj, string value)
        {
            obj.SetValue(PasswordProperty, value);
        }

        // Using a DependencyProperty as the backing store for Password.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.RegisterAttached(
                "Password", 
                typeof(string), 
                typeof(PWHelper), 
                new PropertyMetadata(
                    "",
                    new PropertyChangedCallback(OnPasswordChanged)));

        // 1、可以获取到对应的控件 PasswordBox
        // 2、关联两个方向
        //    - 从绑定到控件
        //    - 从控件到绑定（针对拿到的控件进行PasswordChanged事件的绑定）

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DependencyObject">实际附加的对象</param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private static void OnPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (d as PasswordBox);
            if (control == null) return;

            control.Password = e.NewValue as string;
        }

        private static void Control_PasswordChanged(object sender, RoutedEventArgs e)
        {
            SetPassword((DependencyObject)sender, (sender as PasswordBox).Password);
        }

        public static object GetAttached(DependencyObject obj)
        {
            return (object)obj.GetValue(AttachedProperty);
        }

        public static void SetAttached(DependencyObject obj, object value)
        {
            obj.SetValue(AttachedProperty, value);
        }

        // 挂载事件
        public static readonly DependencyProperty AttachedProperty =
            DependencyProperty.RegisterAttached("Attached", typeof(object), typeof(PWHelper), 
                new PropertyMetadata(null,new PropertyChangedCallback(OnAttachedChanged)));

        private static void OnAttachedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (d as PasswordBox);
            if (control == null) return;

            // 防止多次附加事件 可以先减 后加
            control.PasswordChanged -= Control_PasswordChanged; 
            control.PasswordChanged += Control_PasswordChanged; 
        }
    }
}
