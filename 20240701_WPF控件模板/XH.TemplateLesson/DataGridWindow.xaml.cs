using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace XH.TemplateLesson
{
    /// <summary>
    /// DataGridWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DataGridWindow : Window
    {
        
        public DataGridWindow()
        {
            InitializeComponent();
            List<DataItem> DataItemList = new List<DataItem>();
            for (int i = 0; i < 10; i++)
            {
                DataItem d = CreateData("AAA" + i, i / 2 + "年级", (i % 2 == 0 ? "女" : "男"), i % 3 == 0);
                DataItemList.Add(d);
            }
            this.dg.ItemsSource = DataItemList;
        }

        private DataItem CreateData(string name, string cate, string sex, bool s)
        {
            DataItem d = new DataItem();
            d.Name = name;
            d.Category = cate;
            d.Gender = sex;
            d.Target = "BBB";
            d.Value = "CCC";
            d.IsSelected = s;
            return d;
        }
    }
    class DataItem
    {
        public string Name { get; set; }
        public string Target { get; set; }
        public string Gender { get; set; }
        public string Value { get; set; }
        public bool IsSelected { get; set; }
        public string Category { get; set; }
    }
}
