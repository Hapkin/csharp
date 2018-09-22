using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WPFComboboxtest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.lGenres = new ObservableCollection<Genres>();
            this.lFilms = new ObservableCollection<Films>();
            InitializeComponent();
        }


        //Properties
        private ObservableCollection<Films> filmlijst;

        public ObservableCollection<Films> lFilms
        {
            get { return filmlijst; }
            set { filmlijst = value; }
        }

        private ObservableCollection<Genres> genreslijst;

        public ObservableCollection<Genres> lGenres
        {
            get { return genreslijst; }
            set { genreslijst = value; }
        }



        //Methods
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            Genres horror = new Genres(1, "Horror");
            Genres aktie = new Genres(2, "Aktie");
            lGenres.Add(horror);
            lGenres.Add(aktie);

            lFilms.Add(new Films(1, "Batman", aktie));
            lFilms.Add(new Films(2, "Red dragon", horror));
            this.DataContext = this;



        }
    }
}
