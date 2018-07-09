using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Parkingbon
{
    /// <summary>
    /// Interaction logic for ParkingbonWindow.xaml
    /// </summary>
    public partial class ParkingbonWindow : Window
    {
        public ParkingbonWindow()
        {
            InitializeComponent();
            Nieuw();
        }
        private void Nieuw()
        {
            DatumBon.SelectedDate = DateTime.Now;
            AankomstLabelTijd.Content = DateTime.Now.ToLongTimeString();
            TeBetalenLabel.Content = "0 €";
            VertrekLabelTijd.Content = AankomstLabelTijd.Content;
            StatusItem.Content = "nieuwe bon";
            SaveEnAfdruk(false);
        }
        private void SaveEnAfdruk(Boolean actief)
        {
            PrintPreviewButton.IsEnabled = actief;
            SaveButton.IsEnabled = actief;
            BonAfdrukken.IsEnabled = actief;
            BonOpslaan.IsEnabled = actief;
        }
        private void NewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Nieuw();
        }
        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Parkeerbonnen | *.bon";
                if (dlg.ShowDialog() == true)
                {
                    using (StreamReader invoer = new StreamReader(dlg.FileName))
                    {
                        DatumBon.SelectedDate = Convert.ToDateTime(invoer.ReadLine());
                        AankomstLabelTijd.Content = invoer.ReadLine();
                        TeBetalenLabel.Content = invoer.ReadLine();
                        VertrekLabelTijd.Content = invoer.ReadLine();
                    }
                    StatusItem.Content = dlg.FileName;
                    SaveEnAfdruk(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("opslaan mislukt: " + ex.Message);
            }
        }
        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                DateTime tijd = (DateTime)DatumBon.SelectedDate;
                dlg.FileName = tijd.Day.ToString() + "-" + tijd.Month.ToString() +
                "-" + tijd.Year.ToString() + "om" +
                AankomstLabelTijd.Content.ToString().Replace(":", "-");
                dlg.DefaultExt = ".bon";
                dlg.Filter = "Parkeerbonnen | *.bon";
                if (dlg.ShowDialog() == true)
                {
                    using (StreamWriter uitvoer = new StreamWriter(dlg.FileName))
                    {
                        uitvoer.WriteLine(tijd.ToShortDateString());
                        uitvoer.WriteLine(AankomstLabelTijd.Content);
                        uitvoer.WriteLine(TeBetalenLabel.Content);
                        uitvoer.WriteLine(VertrekLabelTijd.Content);
                    }
                    StatusItem.Content = dlg.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("opslaan mislukt: " + ex.Message);
            }
        }
        private double vertPositie;
        private void PrintPreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            FixedDocument document = new FixedDocument();
            document.DocumentPaginator.PageSize = new Size(640, 320);
            PageContent inhoud = new PageContent();
            document.Pages.Add(inhoud);
            FixedPage pagina = new FixedPage();
            inhoud.Child = pagina;
            pagina.Width = 640;
            pagina.Height = 320;
            Image logo = new Image();
            logo.Source = logoImage.Source;
            logo.Margin = new Thickness(96);
            pagina.Children.Add(logo);
            vertPositie = 96;
            pagina.Children.Add(Regel("datum: " + DatumBon.Text));
            pagina.Children.Add(Regel("starttijd : " + AankomstLabelTijd.Content));
            pagina.Children.Add(Regel("eindtijd : " + VertrekLabelTijd.Content));
            pagina.Children.Add(Regel("bedrag betaald : " + TeBetalenLabel.Content));
            Afdrukvoorbeeld preview = new Afdrukvoorbeeld();
            preview.Owner = this;
            preview.AfdrukDocument = document;
            preview.ShowDialog();
        }
        private TextBlock Regel(string tekst)
        {
            TextBlock deRegel = new TextBlock();
            deRegel.Margin = new Thickness(300, vertPositie, 96, 96);
            deRegel.FontSize = 18;
            vertPositie += 36; // 18 * 2
            deRegel.Text = tekst;
            return deRegel;
        }
        private void CloseExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
        private void minder_Click(object sender, RoutedEventArgs e)
        {
            int bedrag = Convert.ToInt32(TeBetalenLabel.Content.ToString().Replace("€", ""));
        if (bedrag > 0)
                bedrag -= 1;
            TeBetalenLabel.Content = bedrag.ToString() + " €";
            VertrekLabelTijd.Content =
            Convert.ToDateTime(AankomstLabelTijd.Content).AddHours(0.5 *
            bedrag).ToLongTimeString();
            SaveEnAfdruk(!(bedrag == 0));
        }
        private void meer_Click(object sender, RoutedEventArgs e)
        {
            int bedrag = Convert.ToInt32(TeBetalenLabel.Content.ToString().Replace("€", ""));
            DateTime vertrekuur = Convert.ToDateTime(AankomstLabelTijd.Content).AddHours(0.5 * bedrag);
            if (vertrekuur.Hour < 22)
                bedrag += 1;
            TeBetalenLabel.Content = bedrag.ToString() + " €";

            VertrekLabelTijd.Content = Convert.ToDateTime(AankomstLabelTijd.Content).AddHours(0.5 *bedrag).ToLongTimeString();
            SaveEnAfdruk(!(bedrag == 0));
        }
    }
}

