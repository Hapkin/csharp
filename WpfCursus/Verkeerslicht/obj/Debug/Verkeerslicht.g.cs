﻿#pragma checksum "..\..\Verkeerslicht.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "85DBF0504C9564634E3773A2F0B37C975863BB91"
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
using Verkeerslicht;


namespace Verkeerslicht {
    
    
    /// <summary>
    /// VerkeerslichtMain
    /// </summary>
    public partial class VerkeerslichtMain : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\Verkeerslicht.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas canvasLicht;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Verkeerslicht.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse RedLight;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Verkeerslicht.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse OrangeLight;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Verkeerslicht.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse GreenLight;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Verkeerslicht.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridKnoppen;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Verkeerslicht.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonGreen;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\Verkeerslicht.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonOrange;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\Verkeerslicht.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonRed;
        
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
            System.Uri resourceLocater = new System.Uri("/Verkeerslicht;component/verkeerslicht.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Verkeerslicht.xaml"
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
            this.canvasLicht = ((System.Windows.Controls.Canvas)(target));
            return;
            case 2:
            this.RedLight = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 3:
            this.OrangeLight = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 4:
            this.GreenLight = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 5:
            this.gridKnoppen = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.ButtonGreen = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\Verkeerslicht.xaml"
            this.ButtonGreen.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ButtonOrange = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\Verkeerslicht.xaml"
            this.ButtonOrange.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ButtonRed = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\Verkeerslicht.xaml"
            this.ButtonRed.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

