﻿#pragma checksum "..\..\AdminToolsWin.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8B22D3987A19C04619B06C6EF04A6BBFF514FBCBE839A85018DC0B77441E5560"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Prac03;
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


namespace Prac03 {
    
    
    /// <summary>
    /// AdminToolsWin
    /// </summary>
    public partial class AdminToolsWin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\AdminToolsWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox OldPassTB;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\AdminToolsWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NewPassTB;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\AdminToolsWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RepeatNewPassTB;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\AdminToolsWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ChangePassBtn;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\AdminToolsWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid UsersDG;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\AdminToolsWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox BlockCB;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\AdminToolsWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CustomPassCB;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\AdminToolsWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LoginTB;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\AdminToolsWin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddUserBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/Prac03;component/admintoolswin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AdminToolsWin.xaml"
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
            
            #line 8 "..\..\AdminToolsWin.xaml"
            ((Prac03.AdminToolsWin)(target)).Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.OldPassTB = ((System.Windows.Controls.TextBox)(target));
            
            #line 11 "..\..\AdminToolsWin.xaml"
            this.OldPassTB.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TB_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.NewPassTB = ((System.Windows.Controls.TextBox)(target));
            
            #line 12 "..\..\AdminToolsWin.xaml"
            this.NewPassTB.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TB_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.RepeatNewPassTB = ((System.Windows.Controls.TextBox)(target));
            
            #line 13 "..\..\AdminToolsWin.xaml"
            this.RepeatNewPassTB.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TB_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ChangePassBtn = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\AdminToolsWin.xaml"
            this.ChangePassBtn.Click += new System.Windows.RoutedEventHandler(this.ChangePassBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.UsersDG = ((System.Windows.Controls.DataGrid)(target));
            
            #line 18 "..\..\AdminToolsWin.xaml"
            this.UsersDG.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.UsersDG_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BlockCB = ((System.Windows.Controls.CheckBox)(target));
            
            #line 19 "..\..\AdminToolsWin.xaml"
            this.BlockCB.Click += new System.Windows.RoutedEventHandler(this.BlockCB_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.CustomPassCB = ((System.Windows.Controls.CheckBox)(target));
            
            #line 20 "..\..\AdminToolsWin.xaml"
            this.CustomPassCB.Click += new System.Windows.RoutedEventHandler(this.CustomPassCB_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.LoginTB = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\AdminToolsWin.xaml"
            this.LoginTB.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.LoginTB_TextChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.AddUserBtn = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\AdminToolsWin.xaml"
            this.AddUserBtn.Click += new System.Windows.RoutedEventHandler(this.AddUserBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
