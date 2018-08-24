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
    /// Interaction logic for Oefening8_Datareader.xaml
    /// </summary>
    public partial class Oefening8_Datareader : Window
    {
        public Oefening8_Datareader()
        {
            InitializeComponent();
        }

        private CollectionViewSource plantGegevensViewSource;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            //System.Windows.Data.CollectionViewSource plantGegevensViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("")));
            VulcmbSoort();
            VulLstPlanten(null);
        }




        public List<Soort> lSoort = new List<Soort>();
        private void VulcmbSoort()
        {
             
            plantGegevensViewSource =
                (CollectionViewSource)(this.FindResource("plantGegevensViewSource"));
                
            var manager = new TuincentrumActies();
            lSoort = manager.GetLijstSoorten();
            cmbSoort.ItemsSource = lSoort;
            cmbSoort.DisplayMemberPath = "Naam";
        }
        public List<PlantGegevens> lPlanten = new List<PlantGegevens>();
        private void VulLstPlanten(Soort gekozenSoort)
        {
            
            var manager = new TuincentrumActies();
            lPlanten = manager.GetLijstPlanten(gekozenSoort);
            lstPlanten.ItemsSource= lPlanten;
            lstPlanten.DisplayMemberPath = "Naam";
        }


        private void cmbSoort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Soort gekozenSoort = (Soort)cmbSoort.SelectedItem;
            VulLstPlanten(gekozenSoort);
        }
    }
}
