﻿#pragma checksum "..\..\RegenboogWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7C225F9048F7135857C87DC20AC1961E9E9E5E94"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace RegenboogDragDrop {
    
    
    /// <summary>
    /// WindowRegenboog
    /// </summary>
    public partial class WindowRegenboog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\RegenboogWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel DropZone;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\RegenboogWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle dropRed;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\RegenboogWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle dropOrange;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\RegenboogWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle dropYellow;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\RegenboogWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle dropGreen;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\RegenboogWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle dropBlue;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\RegenboogWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle dropIndigo;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\RegenboogWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle dropViolet;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\RegenboogWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonCheck;
        
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
            System.Uri resourceLocater = new System.Uri("/RegenboogDragDrop;component/regenboogwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\RegenboogWindow.xaml"
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
            
            #line 17 "..\..\RegenboogWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseMove += new System.Windows.Input.MouseEventHandler(this.Rectangle_MouseMove);
            
            #line default
            #line hidden
            
            #line 17 "..\..\RegenboogWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).DragEnter += new System.Windows.DragEventHandler(this.Rectangle_DragEnter);
            
            #line default
            #line hidden
            
            #line 17 "..\..\RegenboogWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).DragLeave += new System.Windows.DragEventHandler(this.Rectangle_DragLeave);
            
            #line default
            #line hidden
            
            #line 17 "..\..\RegenboogWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).Drop += new System.Windows.DragEventHandler(this.Rectangle_Drop);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 18 "..\..\RegenboogWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseMove += new System.Windows.Input.MouseEventHandler(this.Rectangle_MouseMove);
            
            #line default
            #line hidden
            
            #line 18 "..\..\RegenboogWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).DragEnter += new System.Windows.DragEventHandler(this.Rectangle_DragEnter);
            
            #line default
            #line hidden
            
            #line 18 "..\..\RegenboogWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).DragLeave += new System.Windows.DragEventHandler(this.Rectangle_DragLeave);
            
            #line default
            #line hidden
            
            #line 18 "..\..\RegenboogWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).Drop += new System.Windows.DragEventHandler(this.Rectangle_Drop);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 19 "..\..\RegenboogWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseMove += new System.Windows.Input.MouseEventHandler(this.Rectangle_MouseMove);
            
            #line default
            #line hidden
            
            #line 19 "..\..\RegenboogWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).DragEnter += new System.Windows.DragEventHandler(this.Rectangle_DragEnter);
            
            #line default
            #line hidden
            
            #line 19 "..\..\RegenboogWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).DragLeave += new System.Windows.DragEventHandler(this.Rectangle_DragLeave);
            
            #line default
            #line hidden
            
            #line 19 "..\..\RegenboogWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).Drop += new System.Windows.DragEventHandler(this.Rectangle_Drop);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 20 "..\..\RegenboogWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseMove += new System.Windows.Input.MouseEventHandler(this.Rectangle_MouseMove);
            
            #line default
            #line hidden
            
            #line 20 "..\..\RegenboogWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).DragEnter += new System.Windows.DragEventHandler(this.Rectangle_DragEnter);
            
            #line default
            #line hidden
            
            #line 20 "..\..\RegenboogWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).DragLeave += new System.Windows.DragEventHandler(this.Rectangle_DragLeave);
            
            #line default
            #line hidden
            
            #line 20 "..\..\RegenboogWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).Drop += new System.Windows.DragEventHandler(this.Rectangle_Drop);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 21 "..\..\RegenboogWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseMove += new System.Windows.Input.MouseEventHandler(this.Rectangle_MouseMove);
            
            #line default
            #line hidden
            
            #line 21 "..\..\RegenboogWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).DragEnter += new System.Windows.DragEventHandler(this.Rectangle_DragEnter);
            
            #line default
            #line hidden
            
            #line 21 "..\..\RegenboogWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).DragLeave += new System.Windows.DragEventHandler(this.Rectangle_DragLeave);
            
            #line default
            #line hidden
            
            #line 21 "..\..\RegenboogWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).Drop += new System.Windows.DragEventHandler(this.Rectangle_Drop);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 22 "..\..\RegenboogWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseMove += new System.Windows.Input.MouseEventHandler(this.Rectangle_MouseMove);
            
            #line default
            #line hidden
            
            #line 22 "..\..\RegenboogWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).DragEnter += new System.Windows.DragEventHandler(this.Rectangle_DragEnter);
            
            #line default
            #line hidden
            
            #line 22 "..\..\RegenboogWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).DragLeave += new System.Windows.DragEventHandler(this.Rectangle_DragLeave);
            
            #line default
            #line hidden
            
            #line 22 "..\..\RegenboogWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).Drop += new System.Windows.DragEventHandler(this.Rectangle_Drop);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 23 "..\..\RegenboogWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseMove += new System.Windows.Input.MouseEventHandler(this.Rectangle_MouseMove);
            
            #line default
            #line hidden
            
            #line 23 "..\..\RegenboogWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).DragEnter += new System.Windows.DragEventHandler(this.Rectangle_DragEnter);
            
            #line default
            #line hidden
            
            #line 23 "..\..\RegenboogWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).DragLeave += new System.Windows.DragEventHandler(this.Rectangle_DragLeave);
            
            #line default
            #line hidden
            
            #line 23 "..\..\RegenboogWindow.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).Drop += new System.Windows.DragEventHandler(this.Rectangle_Drop);
            
            #line default
            #line hidden
            return;
            case 8:
            this.DropZone = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 9:
            this.dropRed = ((System.Windows.Shapes.Rectangle)(target));
            
            #line 26 "..\..\RegenboogWindow.xaml"
            this.dropRed.MouseMove += new System.Windows.Input.MouseEventHandler(this.Rectangle_MouseMove);
            
            #line default
            #line hidden
            
            #line 26 "..\..\RegenboogWindow.xaml"
            this.dropRed.DragEnter += new System.Windows.DragEventHandler(this.Rectangle_DragEnter);
            
            #line default
            #line hidden
            
            #line 26 "..\..\RegenboogWindow.xaml"
            this.dropRed.DragLeave += new System.Windows.DragEventHandler(this.Rectangle_DragLeave);
            
            #line default
            #line hidden
            
            #line 26 "..\..\RegenboogWindow.xaml"
            this.dropRed.Drop += new System.Windows.DragEventHandler(this.Rectangle_Drop);
            
            #line default
            #line hidden
            return;
            case 10:
            this.dropOrange = ((System.Windows.Shapes.Rectangle)(target));
            
            #line 27 "..\..\RegenboogWindow.xaml"
            this.dropOrange.MouseMove += new System.Windows.Input.MouseEventHandler(this.Rectangle_MouseMove);
            
            #line default
            #line hidden
            
            #line 27 "..\..\RegenboogWindow.xaml"
            this.dropOrange.DragEnter += new System.Windows.DragEventHandler(this.Rectangle_DragEnter);
            
            #line default
            #line hidden
            
            #line 27 "..\..\RegenboogWindow.xaml"
            this.dropOrange.DragLeave += new System.Windows.DragEventHandler(this.Rectangle_DragLeave);
            
            #line default
            #line hidden
            
            #line 27 "..\..\RegenboogWindow.xaml"
            this.dropOrange.AddHandler(System.Windows.DragDrop.DropEvent, new System.Windows.DragEventHandler(this.Rectangle_Drop));
            
            #line default
            #line hidden
            return;
            case 11:
            this.dropYellow = ((System.Windows.Shapes.Rectangle)(target));
            
            #line 28 "..\..\RegenboogWindow.xaml"
            this.dropYellow.MouseMove += new System.Windows.Input.MouseEventHandler(this.Rectangle_MouseMove);
            
            #line default
            #line hidden
            
            #line 28 "..\..\RegenboogWindow.xaml"
            this.dropYellow.DragEnter += new System.Windows.DragEventHandler(this.Rectangle_DragEnter);
            
            #line default
            #line hidden
            
            #line 28 "..\..\RegenboogWindow.xaml"
            this.dropYellow.DragLeave += new System.Windows.DragEventHandler(this.Rectangle_DragLeave);
            
            #line default
            #line hidden
            
            #line 28 "..\..\RegenboogWindow.xaml"
            this.dropYellow.AddHandler(System.Windows.DragDrop.DropEvent, new System.Windows.DragEventHandler(this.Rectangle_Drop));
            
            #line default
            #line hidden
            return;
            case 12:
            this.dropGreen = ((System.Windows.Shapes.Rectangle)(target));
            
            #line 29 "..\..\RegenboogWindow.xaml"
            this.dropGreen.MouseMove += new System.Windows.Input.MouseEventHandler(this.Rectangle_MouseMove);
            
            #line default
            #line hidden
            
            #line 29 "..\..\RegenboogWindow.xaml"
            this.dropGreen.DragEnter += new System.Windows.DragEventHandler(this.Rectangle_DragEnter);
            
            #line default
            #line hidden
            
            #line 29 "..\..\RegenboogWindow.xaml"
            this.dropGreen.DragLeave += new System.Windows.DragEventHandler(this.Rectangle_DragLeave);
            
            #line default
            #line hidden
            
            #line 29 "..\..\RegenboogWindow.xaml"
            this.dropGreen.AddHandler(System.Windows.DragDrop.DropEvent, new System.Windows.DragEventHandler(this.Rectangle_Drop));
            
            #line default
            #line hidden
            return;
            case 13:
            this.dropBlue = ((System.Windows.Shapes.Rectangle)(target));
            
            #line 30 "..\..\RegenboogWindow.xaml"
            this.dropBlue.MouseMove += new System.Windows.Input.MouseEventHandler(this.Rectangle_MouseMove);
            
            #line default
            #line hidden
            
            #line 30 "..\..\RegenboogWindow.xaml"
            this.dropBlue.DragEnter += new System.Windows.DragEventHandler(this.Rectangle_DragEnter);
            
            #line default
            #line hidden
            
            #line 30 "..\..\RegenboogWindow.xaml"
            this.dropBlue.DragLeave += new System.Windows.DragEventHandler(this.Rectangle_DragLeave);
            
            #line default
            #line hidden
            
            #line 30 "..\..\RegenboogWindow.xaml"
            this.dropBlue.AddHandler(System.Windows.DragDrop.DropEvent, new System.Windows.DragEventHandler(this.Rectangle_Drop));
            
            #line default
            #line hidden
            return;
            case 14:
            this.dropIndigo = ((System.Windows.Shapes.Rectangle)(target));
            
            #line 31 "..\..\RegenboogWindow.xaml"
            this.dropIndigo.MouseMove += new System.Windows.Input.MouseEventHandler(this.Rectangle_MouseMove);
            
            #line default
            #line hidden
            
            #line 31 "..\..\RegenboogWindow.xaml"
            this.dropIndigo.DragEnter += new System.Windows.DragEventHandler(this.Rectangle_DragEnter);
            
            #line default
            #line hidden
            
            #line 31 "..\..\RegenboogWindow.xaml"
            this.dropIndigo.DragLeave += new System.Windows.DragEventHandler(this.Rectangle_DragLeave);
            
            #line default
            #line hidden
            
            #line 31 "..\..\RegenboogWindow.xaml"
            this.dropIndigo.AddHandler(System.Windows.DragDrop.DropEvent, new System.Windows.DragEventHandler(this.Rectangle_Drop));
            
            #line default
            #line hidden
            return;
            case 15:
            this.dropViolet = ((System.Windows.Shapes.Rectangle)(target));
            
            #line 32 "..\..\RegenboogWindow.xaml"
            this.dropViolet.MouseMove += new System.Windows.Input.MouseEventHandler(this.Rectangle_MouseMove);
            
            #line default
            #line hidden
            
            #line 32 "..\..\RegenboogWindow.xaml"
            this.dropViolet.DragEnter += new System.Windows.DragEventHandler(this.Rectangle_DragEnter);
            
            #line default
            #line hidden
            
            #line 32 "..\..\RegenboogWindow.xaml"
            this.dropViolet.DragLeave += new System.Windows.DragEventHandler(this.Rectangle_DragLeave);
            
            #line default
            #line hidden
            
            #line 32 "..\..\RegenboogWindow.xaml"
            this.dropViolet.AddHandler(System.Windows.DragDrop.DropEvent, new System.Windows.DragEventHandler(this.Rectangle_Drop));
            
            #line default
            #line hidden
            return;
            case 16:
            this.ButtonCheck = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\RegenboogWindow.xaml"
            this.ButtonCheck.Click += new System.Windows.RoutedEventHandler(this.ButtonCheck_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
