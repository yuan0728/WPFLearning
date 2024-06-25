using HelixToolkit.Wpf;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// CustormModelWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CustormModelWindow : Window
    {
        public CustormModelWindow()
        {
            InitializeComponent();
            
            this.Loaded += CustormModelWindow_Loaded;
        }

        private void CustormModelWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //LoadModel();
            LoadPoints();
        }

        //private static void LoadModel()
        //{
        //    ModelImporter importer = new ModelImporter();

        //    Model3DGroup group = new Model3DGroup();

        //    group.Children.Add(importer.Load("D:\\Users\\yhl18\\Desktop\\无标题.obj"));

        //    model.Content = group;
        //}
        private void LoadPoints()
        {
            var lines = File.ReadLines($"{Environment.CurrentDirectory}/PointCloud/pc.pts").ToList();

            Point3DCollection points = new Point3DCollection(); 

            foreach (var line in lines)
            {
                var point = line.Trim().Split(' ').Select(l => double.Parse(l)).ToArray();

                points.Add(new Point3D(point[0], point[1], point[2]));
            }

            PointsVisual3D pointsVisual3D = new PointsVisual3D();
            pointsVisual3D.Color = Colors.Orange;
            pointsVisual3D.Size = 5;
            pointsVisual3D.Points = points;

            this.hv.Children.Add(pointsVisual3D);
        }
    }
}
