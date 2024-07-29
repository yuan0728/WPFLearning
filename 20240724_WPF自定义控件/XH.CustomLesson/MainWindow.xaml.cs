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

namespace XH.CustomLesson
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DateTime Current { get; set; } = new DateTime(2020,10,1,20,30,40);
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DateTimePicker_SeletedChanged(object sender, DateTime e)
        {

        }
    }
}