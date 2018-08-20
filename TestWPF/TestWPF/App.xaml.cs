using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TestWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {



        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //Model.Kaart model = new Model.Kaart();
            ViewModel.WenskaartenVM vm = new ViewModel.WenskaartenVM();
            View.WenskaartView View = new View.WenskaartView();
            View.DataContext = vm;
            View.Show();
        }
    }
}
