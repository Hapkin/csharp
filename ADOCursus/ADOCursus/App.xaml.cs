using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Data.Common;
using System.Threading;
using System.Windows.Markup;
using System.Globalization;

namespace ADOCursus
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            string connectionString = 
                @"server=.\sqlexpress;database=Bieren;integrated security=true";
            Application.Current.Properties["Bieren2"] = connectionString;
            
            
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("nl-BE"); ;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("nl-BE"); ;

            FrameworkElement.LanguageProperty.OverrideMetadata(
              typeof(FrameworkElement),
              new FrameworkPropertyMetadata(
                    XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
            base.OnStartup(e);
        }

    }
}
