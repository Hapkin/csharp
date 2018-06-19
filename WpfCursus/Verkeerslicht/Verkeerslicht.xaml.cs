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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Verkeerslicht
{
    /// <summary>
    /// Interaction logic for VerkeerslichtMain.xaml
    /// </summary>
    public partial class VerkeerslichtMain : Window
    {
        public VerkeerslichtMain()
        {
            InitializeComponent();
            Grid gridKnoppen = this.gridKnoppen;
            IEnumerable<Button> knoppen = gridKnoppen.Children.OfType<Button>();
            Canvas canvasLicht = this.canvasLicht;
            IEnumerable<Ellipse> ellipses = canvasLicht.Children.OfType<Ellipse>();

            foreach (Button knop in knoppen.Where(i=> i.Name!= "ButtonOrange"))
            {
                knop.IsEnabled = false;
            }
            foreach (Ellipse licht in ellipses.Where(i=> i.Name != "RedLight"))
            {
                licht.Visibility= System.Windows.Visibility.Hidden;
            }
            
            

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button knop = (Button)sender;
            Button knopGreen = this.ButtonGreen;
            Button knopOrange = this.ButtonOrange;
            Button knopRed = this.ButtonRed;

            knop.IsEnabled = false;

            //IEnumerable van alle lichten
            Canvas canvasLicht = this.canvasLicht;
            IEnumerable<Ellipse> ellipses = canvasLicht.Children.OfType<Ellipse>();

            //welke knop is er gedrukt
            string tag = knop.Tag.ToString();

            //kleur maken van de string Tag
            SolidColorBrush kleur =
                (SolidColorBrush)new BrushConverter().ConvertFromString(tag);

            //kleur op de achtergrond van de knop toepassen
            knop.Background = kleur;

            // stoplicht zichtbaarmaken
            Ellipse stoplicht = ellipses.First(x => x.Name.ToString() == (tag + "Light"));
            stoplicht.Visibility = System.Windows.Visibility.Visible;



            // alle andere lichten onzichtbaar maken
            var Lichten = ellipses
                        .Where(x => x.Name.ToString() != (tag + "Light"))
                        .ToList();
            Lichten.ForEach(p => p.Visibility = System.Windows.Visibility.Hidden);


            // alle andere knoppen terug naar de default kleur zetten
            switch (tag)
            {
                case "Red":
                    knopOrange.IsEnabled = true;
                    knopOrange.Focus();
                    knopGreen.ClearValue(Control.BackgroundProperty);
                    knopOrange.ClearValue(Control.BackgroundProperty);
                    break;
                case "Orange":
                    knopGreen.IsEnabled = true;
                    knopGreen.Focus();
                    knopGreen.ClearValue(Control.BackgroundProperty);
                    knopRed.ClearValue(Control.BackgroundProperty);
                    break;
                case "Green":
                    knopRed.IsEnabled = true;
                    knopRed.Focus();
                    knopRed.ClearValue(Control.BackgroundProperty);
                    knopOrange.ClearValue(Control.BackgroundProperty);
                    break;
            }








        }
    }
}
