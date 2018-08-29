using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
    /// Interaction logic for Oef10_datagrid.xaml
    /// </summary>
    public partial class Oef10_datagrid : Window, INotifyCollectionChanged

    {
        public Oef10_datagrid()
        {
            InitializeComponent();
        }

        event NotifyCollectionChangedEventHandler INotifyCollectionChanged.CollectionChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource leverancierViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("leverancierViewSource")));
            var manager = new LeverancierActies();
            leveranciersOb = manager.GetLeveranciers();
            leverancierViewSource.Source = leveranciersOb;

            leveranciersOb.CollectionChanged += this.OnCollectionChanged;
        }
        //leveranciersOb
        public ObservableCollection<Leverancier> leveranciersOb = new ObservableCollection<Leverancier>();
        public List<Leverancier> oudeLev = new List<Leverancier>();
        public List<Leverancier> nieuweLev = new List<Leverancier>();
        public List<Leverancier> gewijzigdeLev = new List<Leverancier>();
        public void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (Leverancier lev in e.OldItems)
                {
                    oudeLev.Add(lev);
                }
            }

            if (e.NewItems != null)
            {
                foreach (Leverancier lev in e.NewItems)
                {
                    nieuweLev.Add(lev);
                }
            }

        }

        private void cmbPostNummers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Wilt u alles opslaan?", "Opslaan?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes)
            {
                leverancierDataGrid.CommitEdit(DataGridEditingUnit.Row, true);
                var manager = new LeverancierActies();
                List<Leverancier> resultaatLevs = new List<Leverancier>();
                StringBuilder nietgoed = new StringBuilder();
                StringBuilder welgoed = new StringBuilder();

                if(oudeLev.Count>0)
                {
                    resultaatLevs = manager.SchrijfVerwijdering(oudeLev);
                    if (resultaatLevs.Count > 0)
                    {
                        foreach (Leverancier l in resultaatLevs)
                        {
                            nietgoed.Append($"niet verwijderd: {l.LevNr} : {l.Naam} \n");
                        }
                    }
                    welgoed.Append($"{oudeLev.Count - resultaatLevs.Count} leveranciers verwijderd. \n ");

                }
                resultaatLevs.Clear();

            }

        }
    }
}
