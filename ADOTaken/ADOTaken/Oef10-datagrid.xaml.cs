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

            var nummers = (leveranciersOb
                .GroupBy(g=>g.PostNr)
                .OrderBy(o=>o.Key)
                .Select(l => l.Key)
                .ToList());
            nummers.Insert(0, "alles");
            cmbPostNummers.ItemsSource = nummers;
            cmbPostNummers.SelectedIndex = 0;

        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            leverancierDataGrid.CommitEdit(DataGridEditingUnit.Row, true);
            foreach (Leverancier l in leveranciersOb)
            {
                if ((l.Changed == true) && (l.LevNr != 0))
                {
                    gewijzigdeLev.Add(l);
                    l.Changed = false;
                }
            }

            //gewijzigdeLev
            if (gewijzigdeLev.Count > 0 || oudeLev.Count > 0 || nieuweLev.Count > 0)
            {
                if (MessageBox.Show("Wilt u alles opslaan?", "Opslaan?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes)
                {
                    
                    var manager = new LeverancierActies();
                    List<Leverancier> resultaatLevs = new List<Leverancier>();
                    StringBuilder nietgoed = new StringBuilder();
                    StringBuilder welgoed = new StringBuilder();

                    //verwijderde leveranciers uitvoeren
                    if (oudeLev.Count > 0)
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
                    //nieuwe leveranciers uitvoeren
                    if(nieuweLev.Count>0)
                    {
                        resultaatLevs = manager.SchrijfToevoegingen(nieuweLev);
                        if (resultaatLevs.Count > 0)
                            resultaatLevs.ForEach(i => nietgoed.Append($"Niet toegevoegd {i.LevNr}: {i.Naam} \n"));
                        welgoed.Append($"{nieuweLev.Count - resultaatLevs.Count} leveranciers toegevoegd.");
                    }

                    
                    

                    resultaatLevs.Clear();
                    //bewerkte leveranciers uitvoeren
                    if (gewijzigdeLev.Count > 0)
                    {
                        resultaatLevs = manager.SchrijfWijzigingen(gewijzigdeLev);
                        if (resultaatLevs.Count > 0)
                        {
                            foreach (var l in resultaatLevs)
                            {
                                nietgoed.Append("Niet gewijzigd: " + l.LevNr + " : " + l.Naam +
                                " niet\n");
                            }
                            welgoed.Append(gewijzigdeLev.Count - resultaatLevs.Count +
                            " leverancier(s) gewijzigd in de database\n");
                        }
                    }
                    MessageBox.Show(nietgoed.ToString() + "\n\n" + welgoed.ToString(), "Info",
                    MessageBoxButton.OK);
                    oudeLev.Clear();
                    nieuweLev.Clear();
                    gewijzigdeLev.Clear();
                    //alle lijsten resetten 

                    //pagina vernieuwen en data terug uit de DB oproepen.
                    CollectionViewSource leverancierViewSource =((CollectionViewSource)(this.FindResource("leverancierViewSource")));
                    leveranciersOb = manager.GetLeveranciers();
                    leverancierViewSource.Source = leveranciersOb;

                }
            }
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
            if (cmbPostNummers.SelectedIndex != 0)
                leverancierDataGrid.Items.Filter =
                new Predicate<object>(x => ((Leverancier)x).PostNr== (string)(cmbPostNummers.SelectedValue));
            else
                leverancierDataGrid.Items.Filter = null;
        }

        

        }
    }

