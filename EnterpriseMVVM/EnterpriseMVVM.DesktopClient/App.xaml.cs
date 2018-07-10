// -----------------------------------------------------------------------------
//  <copyright file="App.xaml.cs" company="DCOM Engineering, LLC">
//      Copyright (c) DCOM Engineering, LLC.  All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------------
namespace EnterpriseMVVM.DesktopClient
{
    using System.Windows;
    using ViewModels;
    using Views;

    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var window = new MainWindow
                         {
                             DataContext = new CustomerViewModel()
                         };

            window.ShowDialog();
        }
    }
}