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
    /// Interaction logic for Oefening4_transactions.xaml
    /// </summary>
    public partial class Oefening4_transactions : Window
    {
        public Oefening4_transactions()
        {
            InitializeComponent();
        }

        private void buttonVervangLeverancier_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var manager = new TuincentrumActies();
                manager.UpdateThenRemoveLeverancier(2,3);
                labelStatus.Content = "OK";
            }
            catch (Exception ex)
            {
                labelStatus.Content = ex.Message;
            }
        }
    }
}
