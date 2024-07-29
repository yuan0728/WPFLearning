using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace XH.PropertyLesson
{
    public class DependencyPropertyStudy : Control
    {

        #region 普通属性 prop + tab
        public int Id { get; set; } = int.MaxValue;
        #endregion

        #region 完整属性 propfull + tab
        private string _name = "Hello";

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                // 当属性值 发生变化的时候 可以 添加执行逻辑
                if (value == "Hello")
                {

                }
            }
        }
        #endregion

        # region 依赖属性
        // 依赖属性 所在对象必须是依赖对象
        /*
         * 1、声名 DependencyProperty
         *    约定：名字命名为：名字+Property
         *    readonly 只能被赋值一次，不能被二次修改
         * 2、注册
         * 3、包装
         */
        public static readonly DependencyProperty ValueProperty;

        // 注册 需要在构造函数之前 
        static DependencyPropertyStudy()
        {
            // 基本的三个参数： 属性名称、属性类型、所属类型、默认值（值改变回调，强制回调）、验证回调
            // 默认值一定要和属性类型严格一致

            // 回调执行顺序：验证回调 --> 加载方法 --> 强制回调 --> 属性变化回调 --> 验证回调

            // 委托回到方法参数
            ValueProperty = DependencyProperty.Register(
                "Value",
                typeof(double),
                typeof(DependencyPropertyStudy),
                new PropertyMetadata(
                    1d,
                    new PropertyChangedCallback(OnValueChanged),
                    new CoerceValueCallback(OnValueCoerce)),
                new ValidateValueCallback(OnValueValidation));

            // ValueProperty = DependencyProperty.Register("Value",typeof(double),typeof(DependencyPropertyStudy));

        }

        // 属性值变化回调：处理的是监听属性值的变化
        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            // 如果调用成功 这里将之后对应的依赖值发生了变化
            // 当两次值一样的时候，不触发
            // 静态回调 本方法体的非静态方法
            (d as DependencyPropertyStudy).Refresh();
        }

        /// <summary>
        /// 对数据的判断结果 编译能触发限制报错信息
        /// </summary>
        /// <param name="v">依赖属性所接受到的最新的值</param>
        /// <returns>对数据的判断结果</returns>
        private static bool OnValueValidation(object v)
        {
            //if((double)v > 2000d)
            //    return false;
            return true;
        }

        // 强制回调参数
        private static object OnValueCoerce(DependencyObject d, object v)
        {
            if ((double)v > 255d)
                return 255d;
            if ((double)v < 0d)
                return 0d;
            return v;
        }

        private void Refresh()
        {

        }

        // 包装
        // 利用普通属性 对依赖属性的封装
        // 目的是为了在代码中 方便访问
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set
            {
                SetValue(ValueProperty, value);
            }
        }

        // propdp + tab
        public string StrProp
        {
            get { return (string)GetValue(StrPropProperty); }
            set { SetValue(StrPropProperty, value); }
        }

        public static readonly DependencyProperty StrPropProperty =
            DependencyProperty.Register(
                "StrProp",
                typeof(string),
                typeof(DependencyPropertyStudy),
                new FrameworkPropertyMetadata(
                    "Hello",
                    FrameworkPropertyMetadataOptions.AffectsParentArrange |
                    FrameworkPropertyMetadataOptions.AffectsParentMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender |
                    FrameworkPropertyMetadataOptions.NotDataBindable));




        public int Test
        {
            get { return (int)GetValue(TestProperty); }
            set { SetValue(TestProperty, value); }
        }

        // 依赖属性的继承 继承于XHPanel 的 TestProperty
        // 允许元素树中的子元素从最近的父元素获取特定属性的值
        // 由于父元素也可以通过属性值继承获得其属性值，因此系统可能地归回页面根
        public static readonly DependencyProperty TestProperty =
            XHPanel.TestProperty.AddOwner(
                typeof(DependencyPropertyStudy),
                new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.Inherits));



        //public Button MyButton
        //{
        //    get { return (Button)GetValue(MyButtonProperty); }
        //    set { SetValue(MyButtonProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for MyButton.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty MyButtonProperty =
        //    DependencyProperty.Register("MyButton", typeof(Button), typeof(DependencyPropertyStudy),
        //        new PropertyMetadata(new Button()));



        public int Index
        {
            get { return (int)GetValue(IndexProperty); }
            set { SetValue(IndexProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Index.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IndexProperty =
            DependencyProperty.Register("Index", typeof(int), typeof(DependencyPropertyStudy), new PropertyMetadata(-1));



        /*
         依赖附加属性的意义与作用
            给其他对象提供依赖属性功能
            有些对象的某些属性不能做绑定（PasswordBox）
            例子：布局控件做动态子项
            代码片段关键词：propa
         */


        // ctor + tab
        public DependencyPropertyStudy()
        {
            // 取出源信息
            // 已有的对象，来取出对应信息
            //DependencyPropertyDescriptor dpd = DependencyPropertyDescriptor.FromProperty(Button.WidthProperty, typeof(Button));
            //dpd.AddValueChanged(this.MyButton, new EventHandler(OnButtonWidthChanged));


            this.Id = int.MaxValue;
            this.Loaded += (s, e) =>
            {
                // 获取依赖属性和赋值依赖属性
                var v = this.GetValue(ValueProperty);
                //this.SetValue(ValueProperty, 4.5d);
                //this.Value = 123d;
                //this.Value = 123d;

                this.SetValue(ValueProperty, 200d);
                this.SetValue(ValueProperty, 2001d);

            };
        }

        private void OnButtonWidthChanged(object sender,EventArgs e)
        {

        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            drawingContext.DrawRectangle(this.Background, new Pen(Brushes.Transparent, 0d), new Rect(0, 0, this.RenderSize.Width, this.RenderSize.Height));
        }
        #endregion
    }
}
