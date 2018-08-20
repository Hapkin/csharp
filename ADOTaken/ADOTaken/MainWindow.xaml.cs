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
using DBConnectie;

namespace ADOTaken
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

        private void buttonConnectieTuin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DBTuincerntrum DB = new DBTuincerntrum();
                using (var conTuin = DB.GetConnection())
                {
                    conTuin.Open();
                    labelStatus.Content = "TuinCentrum is geopend";
                }
            }
            catch (Exception ex)
            {
                labelStatus.Content = ex.Message;
            }
        }

        private void buttonEindejaarskorting_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var manager = new TuincentrumActies();
                
                manager.EindejaarsKorting();
                labelStatus.Content = manager.EindejaarsKorting().ToString()
                    + " plantenprijzen aangepast";
                //geeft het aantal planten terug
            }
            catch (Exception ex)
            {
                labelStatus.Content = ex.Message;
            }
        }

        private void buttonToevoegen_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                int nieuwId;
                var manager = new TuincentrumActies();
                var deLeverancier = new Leverancier();
                deLeverancier.Naam = txtNaam.Text;
                deLeverancier.Adres = txtAdres.Text;
                deLeverancier.PostNr = txtPostcode.Text;
                deLeverancier.Woonplaats = txtPlaats.Text;
                nieuwId = manager.LeverancierToevoegen(deLeverancier);
                labelStatus.Content = $"leverancier met nummer {nieuwId.ToString()} is toegevoegd";
            }
            catch (Exception ex)
            {
                labelStatus.Content = ex.Message;
            }
        }
    }
}
