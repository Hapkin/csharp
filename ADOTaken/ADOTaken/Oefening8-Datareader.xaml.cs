using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
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
    public partial class Oefening8_Datareader : Window, INotifyPropertyChanged
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
            //VulLstPlanten(null);
            var manager = new TuincentrumActies();
            lPlantenALL = manager.GetLijstPlanten(null);
            lPlanten = lPlantenALL;
            lstPlanten.ItemsSource = lPlanten;
            lstPlanten.DisplayMemberPath = "Naam";

        }




        public List<Soort> lSoort = new List<Soort>();
        private void VulcmbSoort()
        {
             
            plantGegevensViewSource =
                (CollectionViewSource)(this.FindResource("plantGegevensViewSource"));
                
            var manager = new TuincentrumActies();
            
            lSoort = manager.GetLijstSoorten();
            lSoort.Insert(0, (new Soort(0, "Alle Soorten", 0)));

            cmbSoort.ItemsSource = lSoort;
            cmbSoort.DisplayMemberPath = "Naam";
            cmbSoort.SelectedIndex=0;
        }
        private ObservableCollection<PlantGegevens> lPlantenALL = new ObservableCollection<PlantGegevens>();
        private ObservableCollection<PlantGegevens> plantenlijst;

        public ObservableCollection<PlantGegevens> lPlanten
        {
            get { return plantenlijst; }
            set { plantenlijst = value; }
        }

        private void VulLstPlanten(Soort gekozenSoort)
        {
            if (gekozenSoort.SoortNr != 0)
            {
                var lPlanten2 = (lPlantenALL.Where(x => x.Soort == gekozenSoort.Naam));
                lPlanten = new ObservableCollection<PlantGegevens>(lPlanten2);

                OnPropertyChanged("lPlanten");
            }
            else
            {
                lPlanten = lPlantenALL;
                OnPropertyChanged("lPlanten");
            }

            //if(cmbSoort.SelectedIndex!=0)
            //{ 
            //var manager = new TuincentrumActies();
            //lPlanten = manager.GetLijstPlanten(gekozenSoort);
            //lstPlanten.ItemsSource= lPlanten;
            //lstPlanten.DisplayMemberPath = "Naam";
            //} else
            //{
            //    var manager = new TuincentrumActies();
            //    lPlanten = manager.GetLijstPlanten(null);
            //    lstPlanten.ItemsSource = lPlanten;
            //    lstPlanten.DisplayMemberPath = "Naam";
            //}
        }


        private void cmbSoort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Soort gekozenSoort = (Soort)cmbSoort.SelectedItem;
            VulLstPlanten(gekozenSoort);
        }
        private PlantGegevens mijnPlant;

        public PlantGegevens MijnPlant
        {
            get { return mijnPlant; }
            set { mijnPlant = value;
                OnPropertyChanged("MijnPlant");
            }
        }


        private void lstPlanten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MijnPlant = (PlantGegevens)lstPlanten.SelectedItem;

        }



        protected void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
