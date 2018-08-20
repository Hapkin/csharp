using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;
using AdoGemeenschap;

namespace ADOCursus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonBieren_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    using (var conBieren = new SqlConnection())
            //    {
            //        conBieren.ConnectionString =
            //        @"server=.\sqlexpress;database=Bieren;user id=sa;password=Vdab123";
            //        //@"server=.\sqlexpress;database=Bieren;integrated security=true";
            //        conBieren.Open();
            //        labelStatus.Content = "Bieren geopend";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    labelStatus.Content = ex.Message;
            //}
            // mogelijkheid2
            /*            
            try
            {
                using (var conBieren = new SqlConnection(
                @"server=.\sqlexpress;database=Bieren;integrated security=true"))
                {
                    conBieren.Open();
                    labelStatus.Content = "Bieren geopend";
                }
            }
            catch (Exception ex)
            {
                labelStatus.Content = ex.Message;
            }*/


            //// VIA REFERENCE ! System.Configuration;
            // ++ APP.config!!
            //using (var conBieren = new SqlConnection())
            //{
            //    ConnectionStringSettings conString =
            //    ConfigurationManager.ConnectionStrings["Bieren"];
            //    conBieren.ConnectionString = conString.ConnectionString;
            //    conBieren.Open();
            //    labelStatus.Content = "Bieren geopend";
            //}


            //// VIA APP.XAML.CS!!
            //using (var conBieren = new SqlConnection())
            //{
            //    conBieren.ConnectionString =
            //    Application.Current.Properties["Bieren2"].ToString();
            //    conBieren.Open();
            //    labelStatus.Content = "Bieren geopend";
            //}


            //try
            //{
            //    var conString = ConfigurationManager.ConnectionStrings["Bieren"];
            //    var factory = DbProviderFactories.GetFactory(conString.ProviderName);
            //    using (var conBieren = factory.CreateConnection())
            //    {
            //        conBieren.ConnectionString = conString.ConnectionString;
            //        conBieren.Open();
            //        labelStatus.Content = "Bieren geopend";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    labelStatus.Content = ex.Message;
            //}

            try
            {
                BierenDbManager manager = new BierenDbManager();
                using (var conBieren = manager.GetConnection())
                {
                    conBieren.Open();
                    labelStatus.Content = "Bieren geopend";
                }
            }
            catch (Exception ex)
            {
                labelStatus.Content = ex.Message;
            }
        }

        private void buttonBank_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var manager = new RekeningenManager();
                labelStatus.Content = manager.SaldoBonus() +
                                    " rekeningen aangepast";
            }
            catch (Exception ex)
            {
                labelStatus.Content = ex.Message;
            }
        }

        private void buttonStorten_Click(object sender, RoutedEventArgs e)
        {
            Decimal teStorten;
            if (decimal.TryParse(textBoxTeStorten.Text, out teStorten))
            {
                try
                {
                    var manager = new RekeningenManager();
                    if (manager.Storten(teStorten, textBoxRekeningNr.Text))
                    { labelStatus.Content = "OK"; }
                    else
                    { labelStatus.Content = "Rekening niet gevonden"; }
                }
                catch (Exception ex)
                { labelStatus.Content = ex.Message; }
            }
            else
            { labelStatus.Content = "Tik een getal bij het storten"; }
        }
    }
}
