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
    /// Interaction logic for Oefening5_ExecuteScalar.xaml
    /// </summary>
    public partial class Oefening5_ExecuteScalar : Window
    {
        public Oefening5_ExecuteScalar()
        {
            InitializeComponent();
        }

        private void buttonGemKostprijs_Click(object sender, RoutedEventArgs e)
        {
            var manager = new TuincentrumActies();
            try
            {
                labelStatus.Content =
                manager.BerekenGemKostprijs(txtSoort.Text).ToString("C");
            }
            catch (Exception ex)
            { labelStatus.Content = ex.Message; }
        }
    }
}
