﻿#pragma checksum "..\..\Page_id_w.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6B51AD37733DA903FB98488D752F520DBC1125D6D983B443523147D1853AF4CF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ScottPlot;
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
using gmoveridCalc;


namespace gmoveridCalc {
    
    
    /// <summary>
    /// Page_id_w
    /// </summary>
    public partial class Page_id_w : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\Page_id_w.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Textbox_Userinput;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Page_id_w.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_cal;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\Page_id_w.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel StackPanel_UICalc;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\Page_id_w.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Label_MouseData;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\Page_id_w.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ScottPlot.WpfPlot WpfPlot1;
        
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
            System.Uri resourceLocater = new System.Uri("/gmoveridCalc;component/page_id_w.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Page_id_w.xaml"
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
            this.Textbox_Userinput = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\Page_id_w.xaml"
            this.Textbox_Userinput.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.Textbox_Userinput_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Button_cal = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\Page_id_w.xaml"
            this.Button_cal.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.StackPanel_UICalc = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            
            #line 40 "..\..\Page_id_w.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Label_DoubleClick);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 41 "..\..\Page_id_w.xaml"
            ((System.Windows.Controls.Label)(target)).MouseRightButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Label_RightClick);
            
            #line default
            #line hidden
            
            #line 41 "..\..\Page_id_w.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Label_DoubleClick);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 45 "..\..\Page_id_w.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Label_DoubleClick);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 46 "..\..\Page_id_w.xaml"
            ((System.Windows.Controls.Label)(target)).MouseRightButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Label_RightClick);
            
            #line default
            #line hidden
            
            #line 46 "..\..\Page_id_w.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Label_DoubleClick);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 50 "..\..\Page_id_w.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Label_DoubleClick);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 51 "..\..\Page_id_w.xaml"
            ((System.Windows.Controls.Label)(target)).MouseRightButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Label_RightClick);
            
            #line default
            #line hidden
            
            #line 51 "..\..\Page_id_w.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Label_DoubleClick);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 55 "..\..\Page_id_w.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Label_DoubleClick);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 56 "..\..\Page_id_w.xaml"
            ((System.Windows.Controls.Label)(target)).MouseRightButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Label_RightClick);
            
            #line default
            #line hidden
            
            #line 56 "..\..\Page_id_w.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Label_DoubleClick);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 88 "..\..\Page_id_w.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Label_DoubleClick);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 89 "..\..\Page_id_w.xaml"
            ((System.Windows.Controls.Label)(target)).MouseRightButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Label_RightClick);
            
            #line default
            #line hidden
            
            #line 89 "..\..\Page_id_w.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Label_DoubleClick);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 93 "..\..\Page_id_w.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Label_DoubleClick);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 94 "..\..\Page_id_w.xaml"
            ((System.Windows.Controls.Label)(target)).MouseRightButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Label_RightClick);
            
            #line default
            #line hidden
            
            #line 94 "..\..\Page_id_w.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Label_DoubleClick);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 98 "..\..\Page_id_w.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Label_DoubleClick);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 99 "..\..\Page_id_w.xaml"
            ((System.Windows.Controls.Label)(target)).MouseRightButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Label_RightClick);
            
            #line default
            #line hidden
            
            #line 99 "..\..\Page_id_w.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Label_DoubleClick);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 103 "..\..\Page_id_w.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Label_DoubleClick);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 104 "..\..\Page_id_w.xaml"
            ((System.Windows.Controls.Label)(target)).MouseRightButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Label_RightClick);
            
            #line default
            #line hidden
            
            #line 104 "..\..\Page_id_w.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Label_DoubleClick);
            
            #line default
            #line hidden
            return;
            case 20:
            this.Label_MouseData = ((System.Windows.Controls.Label)(target));
            return;
            case 21:
            this.WpfPlot1 = ((ScottPlot.WpfPlot)(target));
            
            #line 128 "..\..\Page_id_w.xaml"
            this.WpfPlot1.PreviewMouseMove += new System.Windows.Input.MouseEventHandler(this.WpfPlot1_MouseMove);
            
            #line default
            #line hidden
            
            #line 128 "..\..\Page_id_w.xaml"
            this.WpfPlot1.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.WpfPlot1_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

