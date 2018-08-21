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
using AdoGemeenschap;


namespace ADOCursus
{
    /// <summary>
    /// Interaction logic for OverzichtBrouwers.xaml
    /// </summary>
    public partial class OverzichtBrouwers : Window
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

        public List<Brouwer> brouwersOb = new List<Brouwer>();
        private void VulDeGrid()
        {
            brouwerViewSource =
                (CollectionViewSource)(this.FindResource("brouwerViewSource"));
            var manager = new BrouwerManager();
            brouwersOb = manager.GetBrouwersBeginNaam(textBoxZoeken.Text);
            brouwerViewSource.Source = brouwersOb;
            labelTotalRowCount.Content = brouwerDataGrid.Items.Count;
            goUpdate();
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
            Binding binding1 = BindingOperations.GetBinding(postcodeTextBox,
            TextBox.TextProperty);
            binding1.ValidationRules.Clear();
            var binding2 = (postcodeColumn as DataGridBoundColumn).Binding as Binding;
            binding2.ValidationRules.Clear();
            brouwerDataGrid.RowValidationRules.Clear();
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



        private void goUpdate()
        {
            goToPreviousButton.IsEnabled = !(brouwerViewSource.View.CurrentPosition == 0);
            goToFirstButton.IsEnabled = !(brouwerViewSource.View.CurrentPosition == 0);
            goToNextButton.IsEnabled =
            !(brouwerViewSource.View.CurrentPosition == brouwerDataGrid.Items.Count - 1);
            goToLastButton.IsEnabled =
            !(brouwerViewSource.View.CurrentPosition == brouwerDataGrid.Items.Count - 1);
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
    }
}
