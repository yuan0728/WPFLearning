using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XH.WPFBasicControls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string _res = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
            //initRichTextBox();

            //List<ComboxItem> itemList = new List<ComboxItem>
            //{
            //    new ComboxItem { Name = "张三", Id = "1" },
            //    new ComboxItem { Name = "李四", Id = "2" },
            //    new ComboxItem { Name = "王二", Id = "3" }
            //};
            //comboBox.ItemsSource = itemList;

        }



        #region Button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //progressBarIndeterminate.Value += 10;
            //if (progressBarDeterminate.Value > progressBarDeterminate.Maximum)
            //{
            //    progressBarDeterminate.Value = progressBarDeterminate.Minimum;
            //}
        }
        #endregion

        #region RepeatButton
        int a = 0;
        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            a++;
            // tb.Text = a.ToString();
        }
        #endregion

        #region RadioButton
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            MessageBox.Show(radioButton.Content.ToString());
        }
        #endregion

        #region TextBox
        //private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    MessageBox.Show(this.textBox.Text);
        //}

        //private void TextBox_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if(e.Key == Key.Enter)
        //    {
        //        MessageBox.Show("回车事件");
        //    }
        //}

        //private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show("失焦事件");
        //}

        #endregion

        #region RichTextBox
        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MessageBox.Show("RichTextBox_TextChanged");
        }

        private void RichTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("RichTextBox_SelectionChanged");
        }





        //private void initRichTextBox()
        //{
        //    Paragraph paragraph = new Paragraph();
        //    Run run = new Run();
        //    run.Text = "Hello World";
        //    run.Foreground = new SolidColorBrush(Colors.Orange);
        //    paragraph.Inlines.Add(run);
        //    FlowDocument flowDocument = new FlowDocument(paragraph);
        //    richTextBox.Document = flowDocument;
        //}
        #endregion

        #region CheckBox
        private void checkBox_Indeterminate(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("checkBox_Indeterminate");
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("选择");
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("未选择");
        }
        #endregion

        #region ComboBox
        //private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    MessageBox.Show(comboBox.SelectedIndex + "");
        //}
        #endregion

        #region DatePicker
        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(datePicker.Text);
        }
        #endregion

        #region PasswordBox
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(passwordBox.Password);
        }
        #endregion

        #region Slider
        //private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    MessageBox.Show(slider.Value+"");
        //}
        #endregion

        #region Button

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //progressBar.Value += 10;
        }

        private void progressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //MessageBox.Show(progressBar.Value+"");
        }
        #endregion

        #region Menu ContextMenu
        private void NewMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("New");
        }

        private void OpenMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Open");
        }

        private void SaveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("New");
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Exit");
        }

        private void CutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cut");
        }

        private void CopyMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Copy");
        }

        private void PasteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Paste");
        }
        private void ContextMenu_Opened(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Open");
        }

        private void ContextMenu_Closed(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Close");
        }


        #endregion

        #region ToolButton

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            //textBox.Clear();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Open");
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Save");
        }

        private void BoldButton_Click(object sender, RoutedEventArgs e)
        {
            //textBox.FontWeight = FontWeights.Bold;
        }

        private void FontComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox? comboBox = sender as ComboBox;
            //this.textBox.Text += $"\r\n{comboBox.SelectedItem}";
        }

        private void ToolBar_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Loaded");
        }

        private void ToolBar_Unloaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("UnLoaded");
        }

        #endregion

        #region TreeView
        private void treeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            //MessageBox.Show(((TreeViewItem)treeView.SelectedItem).Header as string);
        }
        #endregion

        #region TabControl
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //TabItem tabItem = (tabControl.SelectedItem) as TabItem;
            //tb.Text = tabItem.Header.ToString();
        }
        #endregion

        #region Expander
        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("展开");
        }

        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("关闭");
        }
        #endregion

        #region popup
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //popup.IsOpen = !popup.IsOpen;
        }


        #endregion

        #region PrintDialog
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                // 在这里执行打印操作

            }
        }

        #endregion

        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            MessageBox.Show("1");
        }
    }
    class ComboxItem
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }
}