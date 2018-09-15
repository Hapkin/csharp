using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
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
using DBVideo;

namespace TestAdo
{
    /// <summary>
    /// Interaction logic for Videotheek.xaml
    /// </summary>
    public partial class Videotheek : Window, INotifyPropertyChanged
    {

        List<Films> NieuweFilms = new List<Films>();
        List<Films> VerwijderdeFilms = new List<Films>();

        VideoActies manager = new VideoActies();
        



        public Videotheek()
        {
            lFilms = manager.GetFilms();
            lGenres = manager.GetGenres();
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //lFilms = manager.GetFilms();
            //lGenres = manager.GetGenres();

            //System.Windows.Data.CollectionViewSource filmsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("filmsViewSource")));

            NietActief = false;


            //filmsViewSource.Source = lFilms;



            this.DataContext = this;
        }



        
        
        private bool nietActiefValue;
        public bool NietActief
        {
            get { return nietActiefValue; }
            set { nietActiefValue = value;
                RaisePropertyChanged("NietActief");
            }
        }


        private ObservableCollection<Films> filmlijst;
        public ObservableCollection<Films> lFilms
        {
            get { return filmlijst; }
            set { filmlijst = value; }
        }

        private ObservableCollection<Genres> genrelijst;
        public ObservableCollection<Genres> lGenres
        {
            get { return genrelijst; }
            set { genrelijst = value; }
        }

        private bool knopStatus = true;
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            if (knopStatus)
            {
                Toevoegen();
                knopStatus = false;
            }
            else
            {
                Bevestigen();
                knopStatus = true;
            }
            
        }
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            if (knopStatus) //Dus Verwijderen
            {
                Verwijderen();
            }
            else  //Dus Annuleren 
            {
                Annuleren();
                knopStatus = true;
            }
        }

        public void Toevoegen()
        {
            btn1.Content = "Bevestigen";
            btn2.Content = "Annuleren";

            btnOpslaan.IsEnabled = false;
            btnVerhuur.IsEnabled = false;
            lstFilms.IsEnabled = false;
            cmbGenres.SelectedIndex = 0;

            lFilms.Insert(0, new Films(0,"???",1,1,0,1,0));
            lstFilms.SelectedIndex = 0;
            NietActief = true;
        }
        public void Verwijderen()
        {
            
            if (MessageBox.Show($"Weet u zeker dat u { ((Films)lstFilms.SelectedItem).Titel } wil verwijderen?", "Verwijderen?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                VerwijderdeFilms.Add((Films)lstFilms.SelectedItem);
                lFilms.Remove((Films)lstFilms.SelectedItem);
                lstFilms.SelectedIndex = 0;
            }

        }
        public void Bevestigen()
        {
            
            btn1.Content = "Toevoegen";
            btn2.Content = "Verwijderen";

            btnOpslaan.IsEnabled = true;
            btnVerhuur.IsEnabled = true;
            lstFilms.IsEnabled = true;

            Films nieuwe = new Films();

            //decimal outPrijs;
            //if (decimal.TryParse(txtPrijs.Text, NumberStyles.Currency, CultureInfo.CurrentCulture , out outPrijs))
            //    nieuwe.Prijs = outPrijs;
            
            nieuwe = (Films)lstFilms.SelectedItem;
            nieuwe.Changed = false;
            NieuweFilms.Add(nieuwe);
            NietActief = false;

        }
        public void Annuleren()
        {
            btn1.Content = "Toevoegen";
            btn2.Content = "Verwijderen";
            lFilms.RemoveAt(0);
            lstFilms.SelectedIndex = 0;
            NietActief = false;
            btnOpslaan.IsEnabled = true;
            btnVerhuur.IsEnabled = true;
            lstFilms.IsEnabled = true;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void btnOpslaan_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Alles wegschrijven naar de databank?", "Opslaan?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
            {

                List<Films> resultaat = new List<Films>();
                StringBuilder msg = new StringBuilder();

                //nakijken of er films zijn aangepast
                List<Films> AangepasteFilms = new List<Films>();
                foreach (Films film in lFilms)
                {
                    if (film.Changed)
                        AangepasteFilms.Add(film);

                    if (AangepasteFilms.Count > 0)
                        resultaat= manager.Aanpassen(AangepasteFilms);

                }
                if (resultaat.Count() > 0)
                {
                    msg.AppendLine("Er ging iets mis bij het aanpassen van deze films: ");
                    resultaat.ForEach(m => msg.AppendLine(m.ToString()));
                    MessageBox.Show(msg.ToString());
                    msg.Clear();
                    resultaat.Clear();
                }
                AangepasteFilms.Clear();



                //opslaan nieuwe films
                if (NieuweFilms.Count > 0)
                {
                    resultaat = manager.Opslaan(NieuweFilms);
                    if (resultaat.Count() > 0)
                    {
                        msg.AppendLine("Er ging iets mis bij het opslaan van deze films: ");
                        resultaat.ForEach(m => msg.AppendLine(m.ToString()));
                        MessageBox.Show(msg.ToString());
                        msg.Clear();
                        resultaat.Clear();
                    }
                    NieuweFilms.Clear();
                }

                //verwijderen films
                if (VerwijderdeFilms.Count > 0)
                {
                    resultaat = manager.Verwijderen(VerwijderdeFilms);
                    if (resultaat.Count() > 0)
                    {
                        msg.AppendLine("Er ging iets mis bij het verwijderen van deze films: ");
                        resultaat.ForEach(m => msg.AppendLine(m.ToString()));
                        MessageBox.Show(msg.ToString());
                    }
                    VerwijderdeFilms.Clear();
                }

            }
        }



        private void btnVerhuur_Click(object sender, RoutedEventArgs e)
        {
            Films MijnFilm = (Films)lstFilms.SelectedItem;

            if(MijnFilm.InVoorraad>0)
            {
                MijnFilm.InVoorraad--;
                MijnFilm.UitVoorraad++;
                MijnFilm.TotaalVerhuurd++;


                if (lstFilms.Items.Count != (lstFilms.SelectedIndex+1))
                {
                    lstFilms.SelectedIndex++;
                    lstFilms.SelectedIndex--;
                }else
                {
                    lstFilms.SelectedIndex--;
                    lstFilms.SelectedIndex++;
                }

            } else
            {
                MessageBox.Show("Alle films zijn verhuurd!","Verhuur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }


        }



        private void testOpFouten_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Validation.GetHasError(txtTitle) ||
                Validation.GetHasError(txtInVoorraad) ||
                Validation.GetHasError(txtUitVoorraad) ||
                Validation.GetHasError(txtPrijs) ||
                Validation.GetHasError(txtTotaalVerhuurd))
            {
                MessageBox.Show("Gelieve eerst de fout op te lossen.");
                e.Handled = true;
            }
            
        }

    }
}
