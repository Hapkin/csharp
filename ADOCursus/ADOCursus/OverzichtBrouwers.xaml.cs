using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
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
using AdoGemeenschap;


namespace ADOCursus
{
    /// <summary>
    /// Interaction logic for OverzichtBrouwers.xaml
    /// </summary>
    public partial class OverzichtBrouwers : Window  //, INotifyCollectionChanged? voor gebruik ObservableCollection
    {
        private CollectionViewSource brouwerViewSource;

        public OverzichtBrouwers()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //System.Windows.Data.CollectionViewSource brouwerViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("brouwerViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // brouwerViewSource.Source = [generic data source]

            //CollectionViewSource brouwerViewSource =
            //    ((CollectionViewSource)(this.FindResource("brouwerViewSource")));
            //var manager = new BrouwerManager();
            //List<Brouwer> brouwersOb = new List<Brouwer>();
            //brouwersOb = manager.GetBrouwersBeginNaam(textBoxZoeken.Text);
            //brouwerViewSource.Source = brouwersOb;

            VulDeGrid();
            textBoxZoeken.Focus();
            var nummers = (from b in brouwersOb
                           orderby b.Postcode
                           select b.Postcode.ToString()).Distinct().ToList();
            nummers.Insert(0, "alles");
            comboBoxPostCode.ItemsSource = nummers;
            comboBoxPostCode.SelectedIndex = 0;
        }
        private void buttonZoeken_Click(object sender, RoutedEventArgs e)
        {
            VulDeGrid();
        }
        private void textBoxZoeken_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                VulDeGrid();
            }
        }

       
        

        private void VulDeGrid()
        {
            brouwerViewSource =
                (CollectionViewSource)(this.FindResource("brouwerViewSource"));
            var manager = new BrouwerManager();
            brouwersOb = manager.GetBrouwersBeginNaam(textBoxZoeken.Text);
            brouwerViewSource.Source = brouwersOb;
            labelTotalRowCount.Content = brouwerDataGrid.Items.Count;
            goUpdate();
            brouwersOb.CollectionChanged += this.OnCollectionChanged;
        }

        private void goToFirstButton_Click(object sender, RoutedEventArgs e)
        {
            brouwerViewSource.View.MoveCurrentToFirst();
            goUpdate();
        }
        private void goToPreviousButton_Click(object sender, RoutedEventArgs e)
        {
            brouwerViewSource.View.MoveCurrentToPrevious();
            goUpdate();
        }
        private void goToNextButton_Click(object sender, RoutedEventArgs e)
        {
            brouwerViewSource.View.MoveCurrentToNext();
            goUpdate();
        }
        private void goToLastButton_Click(object sender, RoutedEventArgs e)
        {
            brouwerViewSource.View.MoveCurrentToLast();
            goUpdate();
        }

        private void goButton_Click(object sender, RoutedEventArgs e)
        {
            int position;
            int.TryParse(textBoxGo.Text, out position);
            if (position > 0 && position <= brouwerDataGrid.Items.Count)
            {
                brouwerViewSource.View.MoveCurrentToPosition(position - 1);
            }
            else
            {
                MessageBox.Show("The input index is not valid.");
            }
            goUpdate();
        }
        private void brouwerDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            goUpdate();
        }
        private void checkBoxPostcode0_Click(object sender, RoutedEventArgs e)
        {
            //bidning van de postcodeTextBox
            Binding binding1 = BindingOperations.GetBinding(postcodeTextBox,
            TextBox.TextProperty);
            binding1.ValidationRules.Clear();

            //binding van de gridboxColumn
            var binding2 = (postcodeColumn as DataGridBoundColumn).Binding as Binding;
            binding2.ValidationRules.Clear();
            brouwerDataGrid.RowValidationRules.Clear();

            //nakijken of de checkbox is gecheckt en aan de hand daarvan bepalen welke validatie toe te passen
            switch (checkBoxPostcode0.IsChecked)
            {
                case true:
                    binding1.ValidationRules.Add(new PostcodeRangeRule0());
                    binding2.ValidationRules.Add(new PostcodeRangeRule0());
                    brouwerDataGrid.RowValidationRules.Add(new PostcodeRangeRule0());
                    break;
                case false:
                    binding1.ValidationRules.Add(new PostcodeRangeRule());
                    binding2.ValidationRules.Add(new PostcodeRangeRule());
                    brouwerDataGrid.RowValidationRules.Add(new PostcodeRangeRule());
                    break;
                default:
                    binding1.ValidationRules.Add(new PostcodeRangeRule());
                    binding2.ValidationRules.Add(new PostcodeRangeRule());
                    brouwerDataGrid.RowValidationRules.Add(new PostcodeRangeRule());
                    break;
            }
        }

        private void testOpFouten_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            bool foutGevonden = false;
            foreach (var c in gridDetail.Children)
            {
                if (c is AdornerDecorator)
                {
                    if (Validation.GetHasError(((AdornerDecorator)c).Child))
                    {
                        foutGevonden = true;
                    }
                }
                else if (Validation.GetHasError((DependencyObject)c))
                {
                    foutGevonden = true;
                }
            }
            foreach (var c in brouwerDataGrid.ItemsSource)
            {
                var d = brouwerDataGrid.ItemContainerGenerator.ContainerFromItem(c);
                if (d is DataGridRow)
                {
                    if (Validation.GetHasError(d))
                    {
                        foutGevonden = true;
                    }
                }
            }
            if (foutGevonden)
                e.Handled = true;
        }

        private void comboBoxPostCode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxPostCode.SelectedIndex == 0)
                brouwerDataGrid.Items.Filter = null;
            else
            //brouwerDataGrid.Items.Filter = new Predicate<object>(PostCodeFilter);
            {
                brouwerDataGrid.Items.Filter = new Predicate<object>(x => ((Brouwer)x).Postcode == Convert.ToInt16(comboBoxPostCode.SelectedValue));
            }

            goUpdate();
            labelTotalRowCount.Content = brouwerDataGrid.Items.Count - 1;
        }
        /*
        public bool PostCodeFilter(object br)
        {
            Brouwer b = br as Brouwer;
            bool result = (b.Postcode == Convert.ToInt16(comboBoxPostCode.SelectedValue));
            return result;
        }*/


        private void goUpdate()
        {
            goToPreviousButton.IsEnabled = !(brouwerViewSource.View.CurrentPosition == 0);
            goToFirstButton.IsEnabled = !(brouwerViewSource.View.CurrentPosition == 0);
            goToNextButton.IsEnabled =
            !(brouwerViewSource.View.CurrentPosition == brouwerDataGrid.Items.Count - 2);
            goToLastButton.IsEnabled =
            !(brouwerViewSource.View.CurrentPosition == brouwerDataGrid.Items.Count - 2);
            if (brouwerDataGrid.Items.Count != 0)
            {
                if (brouwerDataGrid.SelectedItem != null)
                {
                    brouwerDataGrid.ScrollIntoView(brouwerDataGrid.SelectedItem);
                    listBoxBrouwers.ScrollIntoView(brouwerDataGrid.SelectedItem);
                }
            }
            textBoxGo.Text = (brouwerViewSource.View.CurrentPosition + 1).ToString();
        }




        //SAVE, DELETE, UPDATE
        public ObservableCollection<Brouwer> brouwersOb = new ObservableCollection<Brouwer>();
        public List<Brouwer> OudeBrouwers = new List<Brouwer>();
        public List<Brouwer> NieuweBrouwers = new List<Brouwer>();
        public List<Brouwer> GewijzigdeBrouwers = new List<Brouwer>();


        void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs
        e)
        {
            if (e.OldItems != null)
            {
                foreach (Brouwer oudeBrouwer in e.OldItems)
                {
                    OudeBrouwers.Add(oudeBrouwer);
                }
            }
            if (e.NewItems != null)
            {
                foreach (Brouwer nieuweBrouwer in e.NewItems)
                {
                    NieuweBrouwers.Add(nieuweBrouwer);
                }
            }
            labelTotalRowCount.Content = brouwerDataGrid.Items.Count;
        }



        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            //als je nog in de rij staat die je net hebt aangemaakt moet deze eerst nog gesaved worden.
            brouwerDataGrid.CommitEdit(DataGridEditingUnit.Row, true);

            List<Brouwer> resultaatBrouwers = new List<Brouwer>();
            var manager = new BrouwerManager();

            //oude brouwers
            if (OudeBrouwers.Count() != 0)
            {
                resultaatBrouwers = manager.SchrijfVerwijderingen(OudeBrouwers);
                if (resultaatBrouwers.Count > 0)
                {
                    StringBuilder boodschap = new StringBuilder();
                    boodschap.Append("Niet verwijderd: \n");
                    foreach (var b in resultaatBrouwers)
                    {
                        boodschap.Append("Nummer: " + b.BrouwerNr + " : " + b.BrNaam + " niet\n");
                    }
                    MessageBox.Show(boodschap.ToString());
                }
            }
            MessageBox.Show(OudeBrouwers.Count - resultaatBrouwers.Count +
            " brouwer(s) verwijderd in de database", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

            //nieuwe brouwers
            resultaatBrouwers.Clear();
            if (NieuweBrouwers.Count() != 0)
            {
                resultaatBrouwers = manager.SchrijfToevoegingen(NieuweBrouwers);
                if (resultaatBrouwers.Count > 0)
                {
                    StringBuilder boodschap = new StringBuilder();
                    boodschap.Append("Niet toegevoegd: \n");
                    foreach (var b in resultaatBrouwers)
                    {
                        boodschap.Append("Nummer: " + b.BrouwerNr + " : " + b.BrNaam
                        + " niet\n");
                    }
                    MessageBox.Show(boodschap.ToString());
                }
            }
            MessageBox.Show(NieuweBrouwers.Count - resultaatBrouwers.Count +
            " brouwer(s) toegevoegd aan de database", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

            //bewerkte brouwers
            foreach (Brouwer b in brouwersOb)
            {
                if ((b.Changed == true) && (b.BrouwerNr != 0)) GewijzigdeBrouwers.Add(b);
                b.Changed = false;
}
            resultaatBrouwers.Clear();
            if (GewijzigdeBrouwers.Count() != 0)
            {
                resultaatBrouwers = manager.SchrijfWijzigingen(GewijzigdeBrouwers);
                if (resultaatBrouwers.Count > 0)
                {
                    StringBuilder boodschap = new StringBuilder();
                    boodschap.Append("Niet gewijzigd: \n");
                    foreach (var b in resultaatBrouwers)
                    {
                        boodschap.Append("Nummer: " + b.BrouwerNr + " : " + b.BrNaam + " niet\n");
                    }
                    MessageBox.Show(boodschap.ToString());
                }
            }
            MessageBox.Show(GewijzigdeBrouwers.Count - resultaatBrouwers.Count +
            " brouwer(s) gewijzigd in de database", "Info", MessageBoxButton.OK,
            MessageBoxImage.Information);

            //grid refreshen zodat de BrouwerNr aangepast wordt
            VulDeGrid();


            OudeBrouwers.Clear();
            NieuweBrouwers.Clear();
        }

        
    }
}
