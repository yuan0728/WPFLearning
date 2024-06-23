using HelixToolkit.Wpf;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace XH.ThreeDLesson
{
    /// <summary>
    /// HelixToolkitWindow.xaml 的交互逻辑
    /// </summary>
    public partial class HelixToolkitWindow : Window
    {
        public HelixToolkitWindow()
        {
            InitializeComponent();
            this.Loaded += HelixToolkitWindow_Loaded;
        }

        private void HelixToolkitWindow_Loaded(object sender, RoutedEventArgs e)
        {
            string[] model_files = System.IO.Directory.GetFiles($"{Environment.CurrentDirectory}/3D_Models");

            ModelImporter importer = new ModelImporter();

            Model3DGroup group = new Model3DGroup();
            foreach (string file in model_files)
            {
                // 模型文件解析 过程 ==> GeometryModel3D
                var mg = importer.Load(file);

                group.Children.Add(mg.Children[0]);
            }
            this.model.Content = group;
        }
    }
}
