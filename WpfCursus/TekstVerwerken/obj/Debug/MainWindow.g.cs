﻿#pragma checksum "..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EE4ECB698D0CFC0E00ADE2C2B9D0648F755704AA"
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
using TekstVerwerken;


namespace TekstVerwerken {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxGebruikersnaam;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox psdBox;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlockAanmelding;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelTekst;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton ButtonBold;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton ButtonItalic;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.RepeatButton RepeatButtonGroter;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.RepeatButton RepeatButtonKleiner;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CheckBoxBold;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CheckBoxItalic;
        
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
            System.Uri resourceLocater = new System.Uri("/TekstVerwerken;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            this.textBoxGebruikersnaam = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.psdBox = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 3:
            
            #line 35 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.textBlockAanmelding = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.LabelTekst = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.ButtonBold = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 43 "..\..\MainWindow.xaml"
            this.ButtonBold.Checked += new System.Windows.RoutedEventHandler(this.ButtonBold_Checked);
            
            #line default
            #line hidden
            
            #line 43 "..\..\MainWindow.xaml"
            this.ButtonBold.Unchecked += new System.Windows.RoutedEventHandler(this.ButtonBold_Unchecked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ButtonItalic = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 50 "..\..\MainWindow.xaml"
            this.ButtonItalic.Click += new System.Windows.RoutedEventHandler(this.ButtonItalic_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.RepeatButtonGroter = ((System.Windows.Controls.Primitives.RepeatButton)(target));
            
            #line 52 "..\..\MainWindow.xaml"
            this.RepeatButtonGroter.Click += new System.Windows.RoutedEventHandler(this.RepeatButtonGroter_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.RepeatButtonKleiner = ((System.Windows.Controls.Primitives.RepeatButton)(target));
            
            #line 53 "..\..\MainWindow.xaml"
            this.RepeatButtonKleiner.Click += new System.Windows.RoutedEventHandler(this.RepeatButtonKleiner_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 56 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.Kleur_Checked);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 57 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.Kleur_Checked);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 58 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.Kleur_Checked);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 59 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.Kleur_Checked);
            
            #line default
            #line hidden
            return;
            case 14:
            this.CheckBoxBold = ((System.Windows.Controls.CheckBox)(target));
            
            #line 62 "..\..\MainWindow.xaml"
            this.CheckBoxBold.Click += new System.Windows.RoutedEventHandler(this.CheckBoxBold_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.CheckBoxItalic = ((System.Windows.Controls.CheckBox)(target));
            
            #line 63 "..\..\MainWindow.xaml"
            this.CheckBoxItalic.Click += new System.Windows.RoutedEventHandler(this.ButtonItalic_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

