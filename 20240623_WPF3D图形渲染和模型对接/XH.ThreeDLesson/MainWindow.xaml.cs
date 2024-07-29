using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XH.ThreeDLesson
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // this.gm.Geometry = this.SetEarth(180, 180, 50);
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            aar.Angle = e.NewValue;
        }

        private void Slider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tt.OffsetX = e.NewValue;
        }

        private void Viewport3D_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // VisualTreeHelper.HitTest();
        }

        private void ModelUIElement3D_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ModelUIElement3D model = sender as ModelUIElement3D;
            var geo = model.Model as GeometryModel3D;
            (geo.BackMaterial as DiffuseMaterial).Brush = Brushes.Black;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Test");
        }



        //private MeshGeometry3D SetEarth(int numx, int numz, double r = 3)
        //{
        //    MeshGeometry3D mesh = new MeshGeometry3D();

        //    double dTh = 2 * Math.PI / numx;
        //    double dPhi = Math.PI / numz;

        //    double X(double th, double phi) => r * Math.Sin(phi) * Math.Cos(th);
        //    double Y(double th, double phi) => r * Math.Sin(phi) * Math.Sin(th);
        //    double Z(double phi) => r * Math.Cos(phi);

        //    // Make the points.
        //    for (int i = 0; i <= numx; i++)
        //    {
        //        for (int j = 0; j <= numz; j++)
        //        {
        //            var th = i * dTh;
        //            var phi = j * dPhi;
        //            mesh.Positions.Add(new Point3D(X(th, phi), Y(th, phi), Z(phi)));
        //            mesh.TextureCoordinates.Add(new Point(th, phi));
        //        }
        //    }

        //    // 生成三角形
        //    for (int i = 0; i < numx; i++)
        //    {
        //        for (int j = 0; j < numz; j++)
        //        {
        //            int i1 = i * (numz + 1) + j;
        //            int i2 = i1 + 1;
        //            int i3 = i2 + (numz + 1);
        //            int i4 = i3 - 1;

        //            mesh.TriangleIndices.Add(i1);
        //            mesh.TriangleIndices.Add(i2);
        //            mesh.TriangleIndices.Add(i3);

        //            mesh.TriangleIndices.Add(i1);
        //            mesh.TriangleIndices.Add(i3);
        //            mesh.TriangleIndices.Add(i4);
        //        }
        //    }
        //    return mesh;
        //}
    }
}