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
using System.Windows.Shapes;
using DBConnectie;

namespace ADOTaken
{
    /// <summary>
    /// Interaction logic for Oefening6_meerdereReturns.xaml
    /// </summary>
    public partial class Oefening6_meerdereReturns : Window
    {
        public Oefening6_meerdereReturns()
        {
            InitializeComponent();
        }

        private void buttonOpzoeken_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var manager = new TuincentrumActies();
                var resultaat = manager.PlantGegevensOpzoeken(Convert.ToInt16(txtPlantNr.Text));
                lblNaam.Content = resultaat.Naam;
                lblSoort.Content = resultaat.Soort;
                lblLeverancier.Content = resultaat.Leverancier;
                lblKostprijs.Content = String.Format("{0:C}",resultaat.Kostprijs);
                lblKleur.Content = resultaat.Kleur;
                
            }
            catch(Exception ex)
            {
                lblNaam.Content = ex.Message;
                lblSoort.Content = "";
                lblLeverancier.Content = "";
                lblKostprijs.Content = "";
                lblKleur.Content = "";
            }
        }
    }
}
