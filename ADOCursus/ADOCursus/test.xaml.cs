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
    /// Interaction logic for test.xaml
    /// </summary>
    public partial class test : Window
    {
        public test()
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
            //brouwersOb = manager.GetBrouwersBeginNaam("");
            //brouwerViewSource.Source = brouwersOb;
        }
    }
}
