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

        //private CollectionViewSource plantGegevensViewSource;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            //System.Windows.Data.CollectionViewSource plantGegevensViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("")));
            VulcmbSoort();
            var manager = new TuincentrumActies();
            lPlantenALL = manager.GetLijstPlanten(null);
            lPlanten = lPlantenALL;


            //DataContext als laatste element zetten
            this.DataContext = this;
        }




        private ObservableCollection<Soort> soortLijst = new ObservableCollection<Soort>();
        

        public ObservableCollection<Soort> lSoort
        {
            get { return soortLijst; }
            set { soortLijst = value; }
        }

        private void VulcmbSoort()
        {
             
            //plantGegevensViewSource =
            //    (CollectionViewSource)(this.FindResource("plantGegevensViewSource"));
                
            var manager = new TuincentrumActies();
            
            lSoort = manager.GetLijstSoorten();
            lSoort.Insert(0, (new Soort(0, "Alle Soorten", 0)));


            cmbSoort.SelectedIndex=0;
        }

        //lPlantenAll is de volledige planten lijst (hieruit worden bepaalde soorten gefilterd)
        private ObservableCollection<PlantGegevens> lPlantenALL = new ObservableCollection<PlantGegevens>();
        private ObservableCollection<PlantGegevens> plantenlijst;

        public ObservableCollection<PlantGegevens> lPlanten
        {
            get { return plantenlijst; }
            set { plantenlijst = value;
                OnPropertyChanged("lPlanten");
            }
        }

        private void VulLstPlanten(Soort gekozenSoort)
        {
            if (gekozenSoort.SoortNr != 0)
            {
                var lPlanten2 = (lPlantenALL.Where(x => x.Soort == gekozenSoort.Naam));
                lPlanten = new ObservableCollection<PlantGegevens>(lPlanten2);

                
            }
            else
            {
                lPlanten = lPlantenALL;
                OnPropertyChanged("lPlanten");
            }

        }


        private void cmbSoort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MijnPlant != null)
            {
                if (MijnPlant.changed)
                    GewijzigdePlanten.Add(MijnPlant);
            }
            


            if (GewijzigdePlanten.Count>0)
            {
                if (MessageBox.Show($"er zijn {GewijzigdePlanten.Count() } gewijzigde planten. /n wilt u deze saven?", "Save?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                    Save();

                GewijzigdePlanten.Clear();
                MijnPlant.changed = false;
            }


            Soort gekozenSoort = (Soort)cmbSoort.SelectedItem;
            
            VulLstPlanten(gekozenSoort);
            BindingExpression expression = lstPlanten.GetBindingExpression(ListBox.ItemsSourceProperty);
            expression.UpdateSource();
            lstPlanten.SelectedIndex = 0;

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
            
            if (MijnPlant != null)
            {
                if (MijnPlant.changed)
                    GewijzigdePlanten.Add(MijnPlant);
            }
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


        public List<PlantGegevens> GewijzigdePlanten = new List<PlantGegevens>();

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {

            Save();
            

        }
        public void Save()
        {
            List<PlantGegevens> resultaatPlanten = new List<PlantGegevens>();
            var manager = new TuincentrumActies();


            if (GewijzigdePlanten.Count() != 0)
            {
                resultaatPlanten = manager.SchrijfWijzigingen(GewijzigdePlanten);
                if (resultaatPlanten.Count > 0)
                {
                    StringBuilder boodschap = new StringBuilder();
                    boodschap.Append("Niet gewijzigd: \n");
                    foreach (var misluktePlant in resultaatPlanten)
                    {
                        boodschap.Append("  - " + misluktePlant.Naam + "\n");
                    }
                    MessageBox.Show(boodschap.ToString());
                }
            }
            MessageBox.Show(GewijzigdePlanten.Count - resultaatPlanten.Count +
            " plant(en) gewijzigd in de database", "Info", MessageBoxButton.OK,
            MessageBoxImage.Information);
            GewijzigdePlanten.Clear();
            MijnPlant.changed = false;
        }

        private void MouseDownError(object sender, MouseButtonEventArgs e)
        {
            bool foutGevonden = false;
            if (Validation.GetHasError(kleurTextBox)|| Validation.GetHasError(kostprijsTextBox))
                foutGevonden = true;







            if (foutGevonden)
            { e.Handled = true;
                MessageBox.Show("Gelieve de error op te lossen.");
            }
        }
    }
}

