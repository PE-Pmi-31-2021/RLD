﻿#pragma checksum "..\..\..\..\..\Presentation\Windows\BookEditDialog.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9DB848AE465149125A37964F9427EF78C35EE40F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using RLD.Presentation.Windows;
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


namespace RLD.Presentation.Windows {
    
    
    /// <summary>
    /// BookEditDialog
    /// </summary>
    public partial class BookEditDialog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\..\Presentation\Windows\BookEditDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox bookNameInput;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\..\Presentation\Windows\BookEditDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox bookGenreInput;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\..\Presentation\Windows\BookEditDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox authorNameInput;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\..\Presentation\Windows\BookEditDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker bookYearInput;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\..\Presentation\Windows\BookEditDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button browseBookButton;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\..\Presentation\Windows\BookEditDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button browseIconButton;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\..\Presentation\Windows\BookEditDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OKButton;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\..\Presentation\Windows\BookEditDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancelButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/RLD;V1.0.0.0;component/presentation/windows/bookeditdialog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Presentation\Windows\BookEditDialog.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.bookNameInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.bookGenreInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.authorNameInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.bookYearInput = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.browseBookButton = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\..\..\Presentation\Windows\BookEditDialog.xaml"
            this.browseBookButton.Click += new System.Windows.RoutedEventHandler(this.Browse_Book);
            
            #line default
            #line hidden
            return;
            case 6:
            this.browseIconButton = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\..\..\Presentation\Windows\BookEditDialog.xaml"
            this.browseIconButton.Click += new System.Windows.RoutedEventHandler(this.Browse_Image);
            
            #line default
            #line hidden
            return;
            case 7:
            this.OKButton = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\..\..\Presentation\Windows\BookEditDialog.xaml"
            this.OKButton.Click += new System.Windows.RoutedEventHandler(this.Book_Add_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.cancelButton = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

