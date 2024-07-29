using System.Windows;
using System.Windows.Media.Animation;

namespace XH.AnimationLesson
{
    /// <summary>
    /// LinearAniamtionWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LinearAnimationWindow : Window
    {
        public LinearAnimationWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 5秒钟 100变300 
            DoubleAnimation widthAnimation = new DoubleAnimation();
            widthAnimation.Duration = new TimeSpan(0,0,5);
            widthAnimation.From = 100;
            widthAnimation.To = 300;
            // 变化宽度
            //this.border.BeginAnimation(WidthProperty, widthAnimation);

            DoubleAnimation heightAnimation = new DoubleAnimation();
            heightAnimation.Duration = new TimeSpan(0, 0, 5);
            heightAnimation.From = 50;
            heightAnimation.To = 350;
            // 变化高度
            //this.border.BeginAnimation(HeightProperty, heightAnimation);

            // 将两个动画同步触发 如果多个动画需要同时执行 可以将相应的对象放到一个 Storyboard
            Storyboard sb = new Storyboard();
            sb.Children.Add(widthAnimation);
            sb.Children.Add(heightAnimation);

            // 这里指定相关的动画对象，与哪个页面对象相关
            // 第一个参数：动画对象
            // 第二个参数：附加对象
            Storyboard.SetTarget(widthAnimation,border);
            Storyboard.SetTargetProperty(widthAnimation,new PropertyPath("Width"));

            Storyboard.SetTarget(heightAnimation,border);
            Storyboard.SetTargetProperty(heightAnimation, new PropertyPath("Height"));
            sb.Begin();
        }
    }
}
