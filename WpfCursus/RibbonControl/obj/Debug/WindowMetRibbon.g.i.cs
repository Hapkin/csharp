﻿#pragma checksum "..\..\WindowMetRibbon.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3CB2ABFC425550D22D8C2C2024FEC5E3072E3B9C"
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
using WindowMetRibbonControl;


namespace WindowMetRibbonControl {
    
    
    /// <summary>
    /// WindowMetRibbon
    /// </summary>
    public partial class WindowMetRibbon : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 40 "..\..\WindowMetRibbon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Ribbon.RibbonQuickAccessToolBar Qat;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\WindowMetRibbon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Ribbon.RibbonToggleButton ButtonVet;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\WindowMetRibbon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Ribbon.RibbonToggleButton ButtonSchuin;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\WindowMetRibbon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Ribbon.RibbonGallery MRUGallery;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\WindowMetRibbon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Ribbon.RibbonGalleryCategory MRUGalleryCat;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\WindowMetRibbon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Ribbon.RibbonCheckBox CheckBoxAlleenLezen;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\WindowMetRibbon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Ribbon.RibbonMenuButton MenuKleur;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\WindowMetRibbon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxVoorbeeld;
        
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
            System.Uri resourceLocater = new System.Uri("/RibbonControl;component/windowmetribbon.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WindowMetRibbon.xaml"
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
            
            #line 8 "..\..\WindowMetRibbon.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.HelpExecuted);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 9 "..\..\WindowMetRibbon.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.NewExecuted);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 10 "..\..\WindowMetRibbon.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.OpenExecuted);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 11 "..\..\WindowMetRibbon.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.SaveExecuted);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 12 "..\..\WindowMetRibbon.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.CloseExecuted);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 13 "..\..\WindowMetRibbon.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.PrintExecuted);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 14 "..\..\WindowMetRibbon.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.PreviewExecuted);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Qat = ((System.Windows.Controls.Ribbon.RibbonQuickAccessToolBar)(target));
            return;
            case 9:
            this.ButtonVet = ((System.Windows.Controls.Ribbon.RibbonToggleButton)(target));
            return;
            case 10:
            this.ButtonSchuin = ((System.Windows.Controls.Ribbon.RibbonToggleButton)(target));
            return;
            case 11:
            this.MRUGallery = ((System.Windows.Controls.Ribbon.RibbonGallery)(target));
            
            #line 74 "..\..\WindowMetRibbon.xaml"
            this.MRUGallery.SelectionChanged += new System.Windows.RoutedPropertyChangedEventHandler<object>(this.MRUGallery_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 12:
            this.MRUGalleryCat = ((System.Windows.Controls.Ribbon.RibbonGalleryCategory)(target));
            return;
            case 13:
            this.CheckBoxAlleenLezen = ((System.Windows.Controls.Ribbon.RibbonCheckBox)(target));
            return;
            case 14:
            this.MenuKleur = ((System.Windows.Controls.Ribbon.RibbonMenuButton)(target));
            return;
            case 15:
            
            #line 104 "..\..\WindowMetRibbon.xaml"
            ((System.Windows.Controls.Ribbon.RibbonRadioButton)(target)).Click += new System.Windows.RoutedEventHandler(this.Radio_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 105 "..\..\WindowMetRibbon.xaml"
            ((System.Windows.Controls.Ribbon.RibbonRadioButton)(target)).Click += new System.Windows.RoutedEventHandler(this.Radio_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 106 "..\..\WindowMetRibbon.xaml"
            ((System.Windows.Controls.Ribbon.RibbonRadioButton)(target)).Click += new System.Windows.RoutedEventHandler(this.Radio_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 107 "..\..\WindowMetRibbon.xaml"
            ((System.Windows.Controls.Ribbon.RibbonRadioButton)(target)).Click += new System.Windows.RoutedEventHandler(this.Radio_Click);
            
            #line default
            #line hidden
            return;
            case 19:
            this.TextBoxVoorbeeld = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
