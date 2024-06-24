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
        List<ModelUIElement3D> models = new List<ModelUIElement3D>();
        public HelixToolkitWindow()
        {
            InitializeComponent();
            this.Loaded += HelixToolkitWindow_Loaded;
        }

        private void HelixToolkitWindow_Loaded(object sender, RoutedEventArgs e)
        {
            /*stl文件*/
            string[] model_files = System.IO.Directory.GetFiles($"{Environment.CurrentDirectory}/3D_Models");

            ModelImporter importer = new ModelImporter();

            // Model3DGroup group = new Model3DGroup();
            foreach (string file in model_files)
            {
                ModelUIElement3D mui = new ModelUIElement3D();
                // 模型文件解析 过程 ==> GeometryModel3D
                var mg = importer.Load(file);
                var geo = mg.Children[0] as GeometryModel3D;

                //geo.Material = new DiffuseMaterial(Brushes.Red);
                geo.Material = NormalMaterial(Brushes.White);
                geo.BackMaterial = NormalMaterial(Brushes.White);

                mui.Model = geo;

                // 添加鼠标动作
                //mui.MouseLeftButtonDown += (se, ev) =>
                //{
                //    geo.Material = NormalMaterial(Brushes.Green);
                //    geo.BackMaterial = NormalMaterial(Brushes.Green);
                //};
                mui.MouseLeftButtonDown += Mui_MouseLeftButtonDown;

                // 旋转底座
                //if (file.IndexOf("LINK1_CAD") > -1)
                //{
                //    RotateTransform3D rt = new RotateTransform3D();
                //    rt.Rotation = new AxisAngleRotation3D(new Vector3D(0,0,1),0);
                //    rt.CenterX = 0;
                //    rt.CenterY = 0;
                //    rt.CenterZ = 0;
                //    mui.Transform = rt;

                //    currentMUI = mui;
                //}

                //if (file.IndexOf("LINK1_CAD") > -1)
                //{
                //    geo.Material = NormalMaterial(Brushes.Green);
                //    geo.BackMaterial = NormalMaterial(Brushes.Green);
                //}

                this.hv.Children.Add(mui);

                models.Add(mui);
            }
            // this.model.Content = group;
            SetTransform();
        }

        ModelUIElement3D currentMUI = null;
        GeometryModel3D currentModel = null;

        private void Mui_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (currentModel != null)
            {
                currentModel.Material = NormalMaterial(Brushes.White);
                currentModel.BackMaterial = NormalMaterial(Brushes.White);
            }
            ModelUIElement3D mui = sender as ModelUIElement3D;
            GeometryModel3D geo = mui.Model as GeometryModel3D;

            currentModel = geo;

            geo.Material = NormalMaterial(Brushes.Green);
            geo.BackMaterial = NormalMaterial(Brushes.Green);
        }

        private void SetTransform()
        {
            var tg1 = new Transform3DGroup();
            var tt1 = new TranslateTransform3D(0, 0, 0);
            var rt1 = new RotateTransform3D(
                    new AxisAngleRotation3D(
                        new Vector3D(0, 0, 1),
                        0),
                    new Point3D(0, 0, 0));
            tg1.Children.Add(tt1);
            tg1.Children.Add(rt1);
            models[1].Transform = tg1;
            models[4].Transform = tg1;

            var tg2 = new Transform3DGroup();
            var tt2 = new TranslateTransform3D(0, 0, 0);
            var rt2 = new RotateTransform3D(
                    new AxisAngleRotation3D(
                        new Vector3D(0, 1, 0),
                        0),
                    new Point3D(175, -200, 500));
            tg2.Children.Add(tt2);
            tg2.Children.Add(rt2);
            tg2.Children.Add(tg1);
            models[2].Transform = tg2;
            models[5].Transform = tg2;

            var tg3 = new Transform3DGroup();
            var tt3 = new TranslateTransform3D(0, 0, 0);
            var rt3 = new RotateTransform3D(
                    new AxisAngleRotation3D(
                        new Vector3D(0, 1, 0),
                        0),
                    new Point3D(190, -700, 1595));
            tg3.Children.Add(tt3);
            tg3.Children.Add(rt3);
            tg3.Children.Add(tg2);
            models[3].Transform = tg3;
            models[6].Transform = tg3;
            models[7].Transform = tg3;

            var tg4 = new Transform3DGroup();
            var tt4 = new TranslateTransform3D(0, 0, 0);
            var rt4 = new RotateTransform3D(
                    new AxisAngleRotation3D(
                        new Vector3D(1, 0, 0),
                        0),
                    new Point3D(400, 0, 1765));
            tg4.Children.Add(tt4);
            tg4.Children.Add(rt4);
            tg4.Children.Add(tg3);
            models[8].Transform = tg4;

            var tg5 = new Transform3DGroup();
            var tt5 = new TranslateTransform3D(0, 0, 0);
            var rt5 = new RotateTransform3D(
                    new AxisAngleRotation3D(
                        new Vector3D(0, 1, 0),
                        0),
                    new Point3D(1405, 50, 1765));
            tg5.Children.Add(tt5);
            tg5.Children.Add(rt5);
            tg5.Children.Add(tg4);
            models[9].Transform = tg5;

            var tg6 = new Transform3DGroup();
            var tt6 = new TranslateTransform3D(0, 0, 0);
            var rt6 = new RotateTransform3D(
                    new AxisAngleRotation3D(
                        new Vector3D(1, 0, 0),
                        0),
                    new Point3D(1405, 0, 1765));
            tg6.Children.Add(tt6);
            tg6.Children.Add(rt6);
            tg6.Children.Add(tg5);
            models[10].Transform = tg6;
        }

        private static MaterialGroup NormalMaterial(Brush mainColor)
        {
            var materialGroup = new MaterialGroup();
            EmissiveMaterial emissMat = new EmissiveMaterial(mainColor);
            DiffuseMaterial diffMat = new DiffuseMaterial(mainColor);
            SpecularMaterial specMat = new SpecularMaterial(mainColor, 200);
            materialGroup.Children.Add(emissMat);
            materialGroup.Children.Add(diffMat);
            materialGroup.Children.Add(specMat);

            return materialGroup;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int index = int.Parse((sender as Slider).Tag.ToString());
            (((models[index].Transform as Transform3DGroup)
                .Children[1] as RotateTransform3D)
                .Rotation as AxisAngleRotation3D)
                .Angle = e.NewValue;
        }
    }
}
