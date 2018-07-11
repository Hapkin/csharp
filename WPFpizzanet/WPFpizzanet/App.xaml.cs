using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WPFpizzanet
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Model.Bestellingen mijnTekst = new Model.Bestellingen();
            ViewModel.PizzanetVM vm = new ViewModel.PizzanetVM(mijnTekst);
            View.PizzanetWindow mijnTekstboxView = new View.PizzanetWindow();
            mijnTekstboxView.DataContext = vm;
            mijnTekstboxView.Show();
        }
    }
}
