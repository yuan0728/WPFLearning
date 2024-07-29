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

namespace XH.BindingLesson.OtherBindings
{
    /// <summary>
    /// PriorityBindingWindow.xaml 的交互逻辑
    /// </summary>
    public partial class PriorityBindingWindow : Window
    {
        public PriorityBindingWindow()
        {
            InitializeComponent();

            this.Loaded += PriorityBindingWindow_Loaded;

        }

        private void PriorityBindingWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.tb.Text = "456";

            // 删除所有绑定关系
            BindingOperations.ClearAllBindings(this.tb);
            // 删除特定的绑定关系
            BindingOperations.ClearBinding(this.tb,TextBox.TextProperty);
        }
    }
}
