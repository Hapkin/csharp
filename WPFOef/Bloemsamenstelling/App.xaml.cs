using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;



namespace Bloemsamenstelling
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //Model.Kleur mijnBloem = new Model.Kleur();
            ViewModel.BloemVM vm = new ViewModel.BloemVM();
            BloemSamenstelling.View.BloemWindow mijnTekstboxView = new BloemSamenstelling.View.BloemWindow();
            mijnTekstboxView.DataContext = vm;
            mijnTekstboxView.Show();
        }
    }
}
