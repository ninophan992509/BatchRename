﻿#pragma checksum "..\..\NewCasePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4BA583E3F8A4FEAEEC37AB10DA9E6C2FBABD12FD91D18BDA47161E552C47E9AB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Batch_Rename;
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


namespace Batch_Rename {
    
    
    /// <summary>
    /// NewCasePage
    /// </summary>
    public partial class NewCasePage : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\NewCasePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton ButtonLowerCase;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\NewCasePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton ButtonUpperCase;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\NewCasePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton ButtonLowerCaseFirstLetter;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\NewCasePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton ButtonUpperCaseFirstLetter;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\NewCasePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ReturnOldName;
        
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
            System.Uri resourceLocater = new System.Uri("/Batch Rename;component/newcasepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\NewCasePage.xaml"
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
            this.ButtonLowerCase = ((System.Windows.Controls.RadioButton)(target));
            
            #line 10 "..\..\NewCasePage.xaml"
            this.ButtonLowerCase.Checked += new System.Windows.RoutedEventHandler(this.ButtonLowerCase_Checked);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ButtonUpperCase = ((System.Windows.Controls.RadioButton)(target));
            
            #line 11 "..\..\NewCasePage.xaml"
            this.ButtonUpperCase.Checked += new System.Windows.RoutedEventHandler(this.ButtonUpperCase_Checked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ButtonLowerCaseFirstLetter = ((System.Windows.Controls.RadioButton)(target));
            
            #line 12 "..\..\NewCasePage.xaml"
            this.ButtonLowerCaseFirstLetter.Checked += new System.Windows.RoutedEventHandler(this.ButtonLowerCaseFirstLetter_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ButtonUpperCaseFirstLetter = ((System.Windows.Controls.RadioButton)(target));
            
            #line 13 "..\..\NewCasePage.xaml"
            this.ButtonUpperCaseFirstLetter.Checked += new System.Windows.RoutedEventHandler(this.ButtonUpperCaseFirstLetter_Checked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ReturnOldName = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\NewCasePage.xaml"
            this.ReturnOldName.Click += new System.Windows.RoutedEventHandler(this.ReturnOldName_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

