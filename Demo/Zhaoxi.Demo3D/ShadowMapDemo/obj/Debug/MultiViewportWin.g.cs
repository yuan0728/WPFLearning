﻿#pragma checksum "..\..\MultiViewportWin.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4665EE961595B4FA960C558E3EDD0DBDBFBDF23166E7C117F9F7568ED2AD0DEB"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using HelixToolkit.Wpf.SharpDX;
using ShadowMapDemo;
using SharpDX;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace ShadowMapDemo {
    
    
    /// <summary>
    /// MultiViewportWin
    /// </summary>
    public partial class MultiViewportWin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\MultiViewportWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HelixToolkit.Wpf.SharpDX.ModelContainer3DX sharedModels;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\MultiViewportWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HelixToolkit.Wpf.SharpDX.ShadowMap3D shadowMap;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\MultiViewportWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HelixToolkit.Wpf.SharpDX.MeshGeometryModel3D model1;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\MultiViewportWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HelixToolkit.Wpf.SharpDX.MeshGeometryModel3D model2;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\MultiViewportWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HelixToolkit.Wpf.SharpDX.MeshGeometryModel3D model3;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\MultiViewportWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HelixToolkit.Wpf.SharpDX.MeshGeometryModel3D plane;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\MultiViewportWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HelixToolkit.Wpf.SharpDX.LineGeometryModel3D lines;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\MultiViewportWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HelixToolkit.Wpf.SharpDX.LineGeometryModel3D grid;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\MultiViewportWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HelixToolkit.Wpf.SharpDX.Viewport3DX view1;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\MultiViewportWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HelixToolkit.Wpf.SharpDX.Viewport3DX view2;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ShadowMapDemo;component/multiviewportwin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MultiViewportWin.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.sharedModels = ((HelixToolkit.Wpf.SharpDX.ModelContainer3DX)(target));
            return;
            case 2:
            this.shadowMap = ((HelixToolkit.Wpf.SharpDX.ShadowMap3D)(target));
            return;
            case 3:
            this.model1 = ((HelixToolkit.Wpf.SharpDX.MeshGeometryModel3D)(target));
            return;
            case 4:
            this.model2 = ((HelixToolkit.Wpf.SharpDX.MeshGeometryModel3D)(target));
            return;
            case 5:
            this.model3 = ((HelixToolkit.Wpf.SharpDX.MeshGeometryModel3D)(target));
            return;
            case 6:
            this.plane = ((HelixToolkit.Wpf.SharpDX.MeshGeometryModel3D)(target));
            return;
            case 7:
            this.lines = ((HelixToolkit.Wpf.SharpDX.LineGeometryModel3D)(target));
            return;
            case 8:
            this.grid = ((HelixToolkit.Wpf.SharpDX.LineGeometryModel3D)(target));
            return;
            case 9:
            this.view1 = ((HelixToolkit.Wpf.SharpDX.Viewport3DX)(target));
            return;
            case 10:
            this.view2 = ((HelixToolkit.Wpf.SharpDX.Viewport3DX)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

