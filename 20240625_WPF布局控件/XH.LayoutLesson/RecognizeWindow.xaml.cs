using Microsoft.Ink;
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

namespace XH.LayoutLesson
{
    /// <summary>
    /// RecognizeWindow.xaml 的交互逻辑
    /// </summary>
    public partial class RecognizeWindow : Window
    {
        public RecognizeWindow()
        {
            InitializeComponent();
        }

        Ink ink = new Ink();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 识别库
            using RecognizerContext recognizerContext = new RecognizerContext();

            recognizerContext.Strokes = ink.CreateStrokes();
            recognizerContext.Strokes.Add(CombineStrokr());

            RecognitionResult result = recognizerContext.Recognize(out RecognitionStatus status);
            RecognitionAlternates als = result.GetAlternatesFromSelection();

            List<string> strs = new List<string>();
            for (int i = 0; i < als.Count; i++)
            {
                strs.Add(als[i].ToString());
            }
        }

        // Strokr 合并
        private Stroke CombineStrokr()
        {
            List<System.Drawing.Point> points = new List<System.Drawing.Point>();
            foreach (var item in this.inkCanvas.Strokes)
            {
                // 将 StylusPoints 转换为 System.Drawing.Point 
                points.AddRange(item.StylusPoints.Select(p => new System.Drawing.Point((int)p.X, (int)p.Y)).ToList());
            }

            return ink.CreateStroke(points.ToArray());
        }
    }
}
