// Updated by XamlIntelliSenseFileGenerator 27.03.2021 21:40:16
#pragma checksum "..\..\..\..\Views\AddWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "27D8CE60B569FC6BE2E1D9B6E06CA68D46CE31D7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FolderSyncer;
using FolderSyncer.ModelViews;
using ModernWpf;
using ModernWpf.Controls;
using ModernWpf.Controls.Primitives;
using ModernWpf.DesignTime;
using ModernWpf.Markup;
using ModernWpf.Media.Animation;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace FolderSyncer
{


    /// <summary>
    /// AddWindows
    /// </summary>
    public partial class AddWindows : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden


#line 13 "..\..\..\..\Views\AddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FolderSyncer.ModelViews.AddFolderViewModel vm;

#line default
#line hidden


#line 29 "..\..\..\..\Views\AddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FirstFolderAdd;

#line default
#line hidden


#line 32 "..\..\..\..\Views\AddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SecondFolderAdd;

#line default
#line hidden


#line 36 "..\..\..\..\Views\AddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FirstFolder;

#line default
#line hidden


#line 42 "..\..\..\..\Views\AddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SecondFolder;

#line default
#line hidden


#line 49 "..\..\..\..\Views\AddWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Done;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.3.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/FolderSyncer;component/views/addwindow.xaml", System.UriKind.Relative);

#line 1 "..\..\..\..\Views\AddWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.AddWindow = ((FolderSyncer.AddWindows)(target));
                    return;
                case 2:
                    this.vm = ((FolderSyncer.ModelViews.AddFolderViewModel)(target));
                    return;
                case 3:
                    this.FirstFolderAdd = ((System.Windows.Controls.Button)(target));
                    return;
                case 4:
                    this.SecondFolderAdd = ((System.Windows.Controls.Button)(target));
                    return;
                case 5:
                    this.FirstFolder = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 6:
                    this.SecondFolder = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 7:
                    this.Done = ((System.Windows.Controls.Button)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Window AddWindow;
    }
}

