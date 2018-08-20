using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPFFlynet.Personeel;
using WPFFlynet.Vloot;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
//using GalaSoft.MvvmLight.Messaging;
using WPFFlynet.Model.Message;
using System.Collections.ObjectModel;

namespace WPFFlynet
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {


        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ViewModel.FlynetMainVM vm = new ViewModel.FlynetMainVM();
            View.FlynetMainWindow flynetView = new View.FlynetMainWindow();
            flynetView.DataContext = vm;
            flynetView.Show();
        }


        public App()
        {

        }



    }
}
