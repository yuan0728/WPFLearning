using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;

namespace XH.CustomLesson.Controls
{
    /// <summary>
    /// 按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
    ///
    /// 步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
    /// 元素中:
    ///
    ///     xmlns:MyNamespace="clr-namespace:XH.CustomLesson.Controls"
    ///
    ///
    /// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
    /// 元素中:
    ///
    ///     xmlns:MyNamespace="clr-namespace:XH.CustomLesson.Controls;assembly=XH.CustomLesson.Controls"
    ///
    /// 您还需要添加一个从 XAML 文件所在的项目到此项目的项目引用，
    /// 并重新生成以避免编译错误:
    ///
    ///     在解决方案资源管理器中右击目标项目，然后依次单击
    ///     “添加引用”->“项目”->[浏览查找并选择此项目]
    ///
    ///
    /// 步骤 2)
    /// 继续操作并在 XAML 文件中使用控件。
    ///
    ///     <MyNamespace:NumericBox/>
    ///
    /// </summary>
    /// 
    [TemplatePart(Name = "PART_Vlaue", Type = typeof(TextBox))]
    public class NumericBox : Control
    {
        TextBox txtValue = new TextBox();
        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                "Value",
                typeof(int),
                typeof(NumericBox),
                new PropertyMetadata(0, new PropertyChangedCallback(OnValueChanged)));

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var nb = (d as NumericBox);
            if (nb.txtValue == null) return;
            if (nb.Value > 30)
                nb.txtValue.Foreground = Brushes.Red;
            else if(nb.Value >0 && nb.Value < 30)
                nb.txtValue.Foreground = Brushes.Black;
            else if (nb.Value < 0)
                nb.txtValue.Foreground = Brushes.Orange;
        }


        static NumericBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericBox), new FrameworkPropertyMetadata(typeof(NumericBox)));
        }
        // 应用模板
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            // 获取模板中的事件
            txtValue = base.GetTemplateChild("PART_Value") as TextBox;
            var btnIncrease = base.GetTemplateChild("PART_IncreaseButton") as RepeatButton;
            var btnDecrease = base.GetTemplateChild("PART_DecreaseButton") as RepeatButton;

            if (txtValue != null)
            {
                // 建立对象中的Value属性和模板中的TextBox控件的Text属性的绑定
                Binding binding = new Binding("Value");
                binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                binding.RelativeSource = new RelativeSource() { AncestorType = typeof(NumericBox), Mode = RelativeSourceMode.FindAncestor };
                txtValue.SetBinding(TextBox.TextProperty, binding);
            }
            if (btnIncrease != null)
                btnIncrease.Click += BtnIncrease_Click;
            if (btnDecrease != null)
                btnDecrease.Click += BtnDecrease_Click;
        }

        private void BtnDecrease_Click(object sender, RoutedEventArgs e)
        {
            this.Value--;
        }

        private void BtnIncrease_Click(object sender, RoutedEventArgs e)
        {
            this.Value++;
        }
    }
}
