﻿#pragma checksum "..\..\..\..\Controls\DateTimePicker.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8318A2C8A8C8D3CFD201C9B632E33415754261A9"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using ScottPlot;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using XH.MvvmPattern.Controls;


namespace XH.MvvmPattern.Controls {
    
    
    /// <summary>
    /// DateTimePicker
    /// </summary>
    public partial class DateTimePicker : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 368 "..\..\..\..\Controls\DateTimePicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBox;
        
        #line default
        #line hidden
        
        
        #line 370 "..\..\..\..\Controls\DateTimePicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton toggleButton;
        
        #line default
        #line hidden
        
        
        #line 379 "..\..\..\..\Controls\DateTimePicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup popup;
        
        #line default
        #line hidden
        
        
        #line 391 "..\..\..\..\Controls\DateTimePicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Calendar calendar;
        
        #line default
        #line hidden
        
        
        #line 419 "..\..\..\..\Controls\DateTimePicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_hour;
        
        #line default
        #line hidden
        
        
        #line 422 "..\..\..\..\Controls\DateTimePicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_minute;
        
        #line default
        #line hidden
        
        
        #line 425 "..\..\..\..\Controls\DateTimePicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_second;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/XH.MvvmPattern;component/controls/datetimepicker.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Controls\DateTimePicker.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.textBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.toggleButton = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            return;
            case 3:
            this.popup = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 4:
            this.calendar = ((System.Windows.Controls.Calendar)(target));
            return;
            case 5:
            
            #line 412 "..\..\..\..\Controls\DateTimePicker.xaml"
            ((System.Windows.Controls.Primitives.RepeatButton)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnHourUp_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 413 "..\..\..\..\Controls\DateTimePicker.xaml"
            ((System.Windows.Controls.Primitives.RepeatButton)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnMinuteUp_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 414 "..\..\..\..\Controls\DateTimePicker.xaml"
            ((System.Windows.Controls.Primitives.RepeatButton)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnSecondUp_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 415 "..\..\..\..\Controls\DateTimePicker.xaml"
            ((System.Windows.Controls.Primitives.RepeatButton)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnHourDown_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 416 "..\..\..\..\Controls\DateTimePicker.xaml"
            ((System.Windows.Controls.Primitives.RepeatButton)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnMinuteDown_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 417 "..\..\..\..\Controls\DateTimePicker.xaml"
            ((System.Windows.Controls.Primitives.RepeatButton)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnSecondDown_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.tb_hour = ((System.Windows.Controls.TextBox)(target));
            
            #line 419 "..\..\..\..\Controls\DateTimePicker.xaml"
            this.tb_hour.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tb_hour_TextChanged);
            
            #line default
            #line hidden
            return;
            case 12:
            this.tb_minute = ((System.Windows.Controls.TextBox)(target));
            
            #line 422 "..\..\..\..\Controls\DateTimePicker.xaml"
            this.tb_minute.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tb_minute_TextChanged);
            
            #line default
            #line hidden
            return;
            case 13:
            this.tb_second = ((System.Windows.Controls.TextBox)(target));
            
            #line 425 "..\..\..\..\Controls\DateTimePicker.xaml"
            this.tb_second.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tb_second_TextChanged);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 428 "..\..\..\..\Controls\DateTimePicker.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 429 "..\..\..\..\Controls\DateTimePicker.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

