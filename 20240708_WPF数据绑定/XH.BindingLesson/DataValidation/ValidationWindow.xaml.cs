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

namespace XH.BindingLesson.DataValidation
{
    /// <summary>
    /// ValidationWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ValidationWindow : Window
    {
        public ValidationWindow()
        {
            InitializeComponent();

            Data data = new Data();
            var v = data.Value;

            //var vv = data["Value"];

            //List<string> Test = new List<string>();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // 清除焦点
            Keyboard.ClearFocus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 是否有报错
            if (Validation.GetHasError(this.tb1))
            {
                // 获取报错
               var errors = Validation.GetErrors(this.tb1);
               var errStr = errors[0].ErrorContent;
            }
            // 是否有报错
            if (Validation.GetHasError(this.tb2))
            {
                // 获取报错
               var errors = Validation.GetErrors(this.tb2);
               var errStr = errors[0].ErrorContent;
            }
        }
    }
}
