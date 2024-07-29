using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace XH.EventLesson
{
    /// <summary>
    /// KeyboardEventWindow.xaml 的交互逻辑
    /// </summary>
    public partial class KeyboardEventWindow : Window
    {
        public KeyboardEventWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextInput(object sender, TextCompositionEventArgs e)
        {
            Debug.WriteLine("============= TextBox_TextInput===========");
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Debug.WriteLine("============= TextBox_PreviewTextInput===========");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Debug.WriteLine("============= TextBox_TextChanged===========");
        }
    }
}
