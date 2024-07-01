using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows.Media;

namespace XH.LayoutLesson
{
    public class RGB : MarkupExtension
    {
        public byte Alpha { get; set; } = 255; // 颜色深浅度
        byte R, G, B;
        public RGB(byte r, byte g, byte b)
        {
            R = r; G = g; B = b;
        }
        public RGB(byte a, byte r, byte g, byte b)
        {
            Alpha = a; R = r; G = g; B = b;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            // 0 0 0 黑色
            // 255 255 255 白色
            return new SolidColorBrush(Color.FromArgb(Alpha,R, G, B));
        }
    }
}
