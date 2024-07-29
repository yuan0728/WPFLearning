using Kitware.VTK;
using PointCloudSharp;

namespace XH.PclLesson
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        PointCloudXYZ cloud = new PointCloudXYZ();
        RenderWindowControl renderWindowControl = new RenderWindowControl();

        private void Form1_Load(object sender, EventArgs e)
        {
            renderWindowControl.Dock = DockStyle.Fill;
            this.Controls.Add(renderWindowControl);


            string path = $"{Environment.CurrentDirectory}/rabbit.pcd";
            PclCSharp.Io.loadPcdFile(path, cloud.PointCloudXYZPointer);


            vtkRenderer renderer = showPointCloud(cloud);
            vtkRenderWindow renWin = renderWindowControl.RenderWindow;
            // ������ɫActor����ӵ�����Ⱦ��Renderer������Ⱦ
            renWin.AddRenderer(renderer);
            //ˢ��panel�������Ͳ���Ҫ���һ����Ļ�Ż���ʾ����
            this.Refresh();
        }

        //�����ƶ�����ӻ�
        vtkRenderer showPointCloud(PointCloudXYZ in_pc)
        {
            //��ʾ����
            vtkPoints points = vtkPoints.New();
            //�ѵ���ָ���еĵ����ηŽ�points
            for (int i = 0; i < cloud.Size; i++)
            {
                points.InsertNextPoint(cloud.GetX(i), cloud.GetY(i), cloud.GetZ(i));

            }


            //����ÿ������������ݣ����������ɫ
            vtkUnsignedCharArray colors_rgb = setColorBaseAxis('y', cloud);
            vtkPolyData polydata = vtkPolyData.New();
            //��points���ݴ���polydata
            polydata.SetPoints(points);
            //�������ݵ���ɫ���Դ���polydata
            polydata.GetPointData().SetScalars(colors_rgb);

            vtkVertexGlyphFilter glyphFilter = vtkVertexGlyphFilter.New();
            glyphFilter.SetInputConnection(polydata.GetProducerPort());
            // �½���ͼ��
            vtkPolyDataMapper mapper = vtkPolyDataMapper.New();
            //������ɫģʽ�������Ĭ��ģʽ������Ҳ��
            //����unsigned char���͵ı����������ݵ�����ɫֵ����ִ����ʽ�������������͵ı������ݣ���ͨ����ѯ��ӳ��
            mapper.SetColorModeToDefault();

            mapper.SetScalarVisibility(1);
            mapper.SetInputConnection(glyphFilter.GetOutputPort());// ���ӹܵ�

            vtkActor actor = vtkActor.New(); // �½���ɫ
            actor.SetMapper(mapper); // ������ͼ��

            //��ͼ�������ɫ�̶ȱ�,�̶�ֵ����ɫ��Ļ�û��Ӧ
            vtkScalarBarActor scalarBar = vtkScalarBarActor.New();
            scalarBar.SetLookupTable(mapper.GetLookupTable());
            scalarBar.SetTitle("Point Cloud");
            scalarBar.SetHeight(0.7);
            scalarBar.SetWidth(0.1);
            scalarBar.SetNumberOfLabels(10);
            scalarBar.GetLabelTextProperty().SetFontSize(4);
            vtkRenderer out_render = vtkRenderer.New();

            out_render.AddActor(actor);
            //�����ɫ�̶ȱ�
            out_render.AddActor(scalarBar);
            // ����Viewport����
            out_render.SetViewport(0.0, 0.0, 1.0, 1.0);
            // �򿪽���ɫ��������
            out_render.GradientBackgroundOn();
            out_render.SetBackground(0.2, 0.3, 0.3);
            out_render.SetBackground2(0.8, 0.8, 0.8);
            return out_render;
        }


        /*����ָ�������趨������ɫ����
         ��Сֵ������Ϊ��ɫ��0��0��255����������ɫͨ������ֵ��255���м�λ�ð�����仯�ݼ���0��
         ��ɫͨ������ֵ��0������仯������255���м�λ������Ϊ��ɫ��0��255��0����
         ������ɫͨ������ֵ��255������仯�ݼ���0����ɫͨ����ֵ��0������仯������255��
         ����ֵλ������Ϊ��255��0��0��*/
        vtkUnsignedCharArray setColorBaseAxis(char axis, PointCloudXYZ in_pc)
        {
            vtkUnsignedCharArray colors_rgb = vtkUnsignedCharArray.New();
            //���Ƶļ�ֵ,��һ�ڶ���Ԫ�طֱ���x����С���ֵ��yz��������
            double[] minmax = new double[6];
            in_pc.GetMinMaxXYZ(minmax);
            double z = minmax[5] - minmax[4];//z��Ĳ�ֵ
            double y = minmax[3] - minmax[2];//y��Ĳ�ֵ
            double x = minmax[1] - minmax[0];//x��Ĳ�ֵ
            double z_median = z / 2;
            double y_median = y / 2;
            double x_median = x / 2;
            colors_rgb.SetNumberOfComponents(3);//������ɫ����֣���Ϊ��rgb���������Ϊ3
            double r = 0, g = 0, b = 0;
            if (axis == 'x')
            {
                for (int i = 0; i < in_pc.Size; i++)
                {
                    //�м�ֵΪ�磬xֵ�����м�ֵ��b���Ϊ0��r����𽥱��
                    if ((in_pc.GetX(i) - minmax[0]) > x_median)
                    {
                        //xֵҪ�ȹ�һ���ٳ���255����Ȼ��ֵ���ᳬ��255

                        r = (255 * ((in_pc.GetX(i) - minmax[0] - x_median) / x_median)); ;
                        g = (255 * (1 - ((in_pc.GetX(i) - minmax[0] - x_median) / x_median)));
                        b = 0;
                        colors_rgb.InsertNextTuple3(r, g, b);
                    }
                    //�м�ֵΪ�磬xֵС���м�ֵ��r���Ϊ0��b����𽥱��
                    else
                    {
                        //xֵҪ�ȹ�һ���ٳ���255����Ȼ��ֵ���ᳬ��255
                        r = 0;
                        g = (255 * ((in_pc.GetX(i) - minmax[0]) / x_median));
                        b = (255 * (1 - ((in_pc.GetX(i) - minmax[0]) / x_median))); ;
                        colors_rgb.InsertNextTuple3(r, g, b);
                    }
                }
            }
            else if (axis == 'y')
            {
                for (int i = 0; i < in_pc.Size; i++)
                {
                    //�м�ֵΪ�磬yֵ�����м�ֵ��b���Ϊ0��r����𽥱��
                    if ((in_pc.GetY(i) - minmax[2]) > y_median)
                    {
                        //yֵҪ�ȹ�һ���ٳ���255����Ȼ��ֵ���ᳬ��255
                        r = (255 * ((in_pc.GetY(i) - minmax[2] - y_median) / y_median)); ;
                        g = (255 * (1 - ((in_pc.GetY(i) - minmax[2] - y_median) / y_median)));
                        b = 0;
                        colors_rgb.InsertNextTuple3(r, g, b);
                    }
                    //�м�ֵΪ�磬yֵС���м�ֵ��r���Ϊ0��b����𽥱��
                    else
                    {
                        r = 0;
                        g = (255 * ((in_pc.GetY(i) - minmax[2]) / y_median));
                        b = (255 * (1 - ((in_pc.GetY(i) - minmax[2]) / y_median))); ;
                        colors_rgb.InsertNextTuple3(r, g, b);
                    }
                }
            }
            else if (axis == 'z')
            {

                for (int i = 0; i < in_pc.Size; i++)
                {
                    //�м�ֵΪ�磬zֵ�����м�ֵ��b���Ϊ0��r����𽥱��
                    if ((in_pc.GetZ(i) - minmax[4]) > z_median)
                    {
                        //zֵҪ�ȹ�һ���ٳ���255����Ȼ��ֵ���ᳬ��255
                        r = (255 * ((in_pc.GetZ(i) - minmax[4] - z_median) / z_median)); ;
                        g = (255 * (1 - ((in_pc.GetZ(i) - minmax[4] - z_median) / z_median)));
                        b = 0;
                        colors_rgb.InsertNextTuple3(r, g, b);
                    }
                    //�м�ֵΪ�磬zֵС���м�ֵ��r���Ϊ0��b����𽥱��
                    else
                    {
                        r = 0;
                        g = (255 * ((in_pc.GetZ(i) - minmax[4]) / z_median));
                        b = (255 * (1 - ((in_pc.GetZ(i) - minmax[4]) / z_median)));
                        colors_rgb.InsertNextTuple3(r, g, b);
                    }
                }
            }

            return colors_rgb;
        }
    }
}
