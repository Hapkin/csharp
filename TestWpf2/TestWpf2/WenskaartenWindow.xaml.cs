using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
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
using TestWPF2.Model;
using Microsoft.Win32;
using System.IO;

namespace TestWpf2
{
    /// <summary>
    /// Interaction logic for Wenskaarten.xaml
    /// </summary>

    public partial class Wenskaarten : Window, INotifyPropertyChanged
    {
        //alle commands
        public static RoutedCommand KerstkaartCommand = new RoutedCommand();
        public static RoutedCommand GeboortekaartCommand = new RoutedCommand();
        



        //alle global variables
        public TestWPF2.Model.File MijnFile = new TestWPF2.Model.File();
        private ObservableCollection<Bal> DeBallenLijst = new ObservableCollection<Bal>();


        #region Constructor
        public Wenskaarten()
        {
            MijnKaart = new Kaart();
            
            this.DataContext = this;
            LoadSystemColors();
            LoadSystemFonts();


            //Mijn objecten aanmaken.
            Zichtbaar = Visibility.Hidden;
            CheckEnabled = false;
            NieuweBal = new Bal(lColors[0], 0, 0);


            MijnFile.MijnKaart = MijnKaart;

            //***TEMP add 3 balls
            #region Debugging

            //DeBallenLijst.Add(new Bal(lColors[10], 10, 10));
            //DeBallenLijst.Add(new Bal(lColors[15], 50, 10));
            //DeBallenLijst.Add(new Bal(lColors[20], 10, 50));

            //MijnKaart.Ballen = DeBallenLijst;
            //// add achtergrond
            //string naam = "Kerstkaart";
            //BitmapImage img = new BitmapImage(new Uri("pack://application:,,,/Img/kerstkaart.jpg", UriKind.Absolute));
            //MijnKaart.Achtergrond = new Achtergrond(naam, img);
            #endregion


            InitializeComponent();
        }
        #endregion

        #region Commands
        private void NieuwCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            NieuweKaart();
        }
        
        private void OpenCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.FileName = "";
                dlg.DefaultExt = ".Kaart";
                dlg.Filter = "Kaarten |*.Kaart";
                if (dlg.ShowDialog() == true)
                {
                    using (StreamReader bestand = new StreamReader(dlg.FileName))
                    {
                        List<string> lijst = new List<string>();
                        string regel;
                        while ((regel = bestand.ReadLine()) != null)
                        {
                            lijst.Add(regel);
                        }
                        
                        //Achtergrond instellen + nieuwe MijnKaart wordt gestart
                        //lijst[0] == Achtergrond: Geboortekaart
                        string[] achtergrond = lijst[0].Split(':');

                        if (achtergrond[1] == " Geboortekaart")
                            GeboortekaartCommandExecuted(null, null);
                        else
                            KerstkaartCommandExecuted(null, null);

                        /* lijst[2] tot [5] (indien null wordt er null geschreven)
                           Wens:
                            Text:Begintextdfgd
                            Font:Bell MT
                            Size:18
                        */
                        string[] wenstProp = lijst[3].Split(':');
                        if (wenstProp[1] != "null")
                            WensText = wenstProp[1];

                        wenstProp = lijst[4].Split(':');
                        if (wenstProp[1] != "null")
                        {
                            var test = _systemFonts.FirstOrDefault(f => f.Source == wenstProp[1]) ?? null;
                            if (test != null)
                                FontTypeCombo.SelectedItem = test;

                        }
                        
                        wenstProp = lijst[5].Split(':');
                        if (wenstProp[1] != "null")
                            FontSizeWens = int.Parse(wenstProp[1]);




                        // DeBallenlijst
                        //Ballen: [7]
                        //Bal:    [8]
                        //Kleur: Black [9]
                        //288 || 139,2 [10]
                        //
                        DeBallenLijst.Clear();
                        int i = 8;
                        while ((i+2)<=lijst.Count())
                        {
                            //MessageBox.Show($"{lijst[i]}{lijst[i+1]}");
                            string[] Openenbal = lijst[i + 1].Split('|');
                            Kleur Openenkleur = _systemColors.FirstOrDefault(f => f.Naam == Openenbal[0]) ?? null;
                            i = i + 2;
                            if (Openenkleur != null)
                                DeBallenLijst.Add(new Bal(Openenkleur, double.Parse(Openenbal[1]), double.Parse(Openenbal[2])));
                            
                        }
                        //inputstring...

                        BallenLijst = DeBallenLijst;
                        FilePath = dlg.FileName;

                        Zichtbaar = Visibility.Visible;
                        RaisePropertyChanged("Zichtbaar");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("openen mislukt : " + ex.Message);
                //NieuweKaart();
            }
        }
        private void CloseCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            //if (MessageBox.Show("Wilt u het programma sluiten ?", "Afsluiten", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                this.Close();

        }
        private void SaveCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                if (MijnKaart.Achtergrond.Naam == "Geboortekaart")
                    dlg.FileName = "Geboortekaart";
                else
                    dlg.FileName = "Kerstkaart";
                dlg.DefaultExt = ".kaart";
                dlg.Filter = "Kaarten |*.kaart";
                if (dlg.ShowDialog() == true)
                {
                    using (StreamWriter bestand = new StreamWriter(dlg.FileName))
                    {
                        bestand.WriteLine(MijnKaart.ToString());
                        MijnFile.SavePath = dlg.FileName;
                        RaisePropertyChanged("FilePath");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("opslaan mislukt: " + ex.Message);
            }
        }
        private void PrintPreviewCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            //Niet uitgewerkt
            //var a = 1;
        }

        #endregion







        //Fields + Properties
        private Kaart kaartValue;
        public Kaart MijnKaart
        {
            get { return kaartValue; }
            set
            {
                kaartValue = value;
                RaisePropertyChanged("MijnKaart");
            }
        }

        #region Nieuwe Bal
        //*** NIEUWE BAL (een bal die nog niet in het canvas geplaatst is)
        private Bal balValue;
        public Bal NieuweBal  
        {
            get { return balValue; }
            set
            {
                balValue = value;
                RaisePropertyChanged("NieuweBal");
            }
        }
        public Kleur SelectedColor 
        {
            get
            {
                if (NieuweBal.Kleur != null)
                    return NieuweBal.Kleur;
                else
                    return _systemColors[0];
            }
            set
            {
                NieuweBal.Kleur = value;
                RaisePropertyChanged("SelectedColor"); //??
            }
        }



        //***
        #endregion

        #region Wens
        public string WensText
        {
            get { return MijnKaart.Wens.Text; }
            set
            {
                MijnKaart.Wens.Text = value;
                RaisePropertyChanged("WensText");
                RaisePropertyChanged("WensTextWidth");

            }
        }
        public int FontSizeWens
        {
            get { return MijnKaart.Wens.Size; }
            set { MijnKaart.Wens.Size = value;
                RaisePropertyChanged("FontSizeWens");
                RaisePropertyChanged("WensTextWidth");
            }
        }
        public int WensTextWidth
        {
            get {
                int bereken = ((MijnKaart.Wens.Text.Count()+4) * FontSizeWens) /2;
                return bereken;
            }

        }
        #endregion

        #region Algemeen (visible/enabled/Status)
        private Visibility zichtbaarValue;
        public Visibility Zichtbaar
        {
            get { return zichtbaarValue; }
            set
            {
                zichtbaarValue = value;
                RaisePropertyChanged("Zichtbaar");
            }
        }
        private bool checkEnableValue;
        public bool CheckEnabled
        {
            get { return checkEnableValue; }
            set
            {
                checkEnableValue = value;
                RaisePropertyChanged("CheckEnabled");
            }
        }

        public String FilePath 
        {
            get { return MijnFile.SavePath; }
            set { MijnFile.SavePath = value;
                RaisePropertyChanged("FilePath");
            }
        }
        #endregion



        #region Drag & drop
        public ObservableCollection<Bal> BallenLijst
        {
            get {
                return MijnKaart.Ballen;
            }
            set { MijnKaart.Ballen = value;
                RaisePropertyChanged("BallenLijst");
            }
        }

        #endregion
        //Methods
        private void KerstkaartCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            NieuweKaart();
            string naam = "Kerstkaart";

            BitmapImage img = new BitmapImage(new Uri("pack://application:,,,/Img/kerstkaart.jpg", UriKind.Absolute));
            MijnKaart.Achtergrond = new Achtergrond(naam, img);
            Zichtbaar = Visibility.Visible;
            CheckEnabled = true;
            RaisePropertyChanged("Zichtbaar");
            RaisePropertyChanged("MijnKaart");
        }
        private void GeboortekaartCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            NieuweKaart();
            string naam = "Geboortekaart";

            BitmapImage img = new BitmapImage(new Uri("pack://application:,,,/Img/geboortekaart.jpg", UriKind.Absolute));
            MijnKaart.Achtergrond = new Achtergrond(naam, img);
            Zichtbaar = Visibility.Visible;
            CheckEnabled = true;


            //RaisePropertyChanged("Zichtbaar");

            RaisePropertyChanged("MijnKaart");
        }


        private void NieuweKaart()
        {
            //MessageBox.Show("test");
            MijnKaart = null;
            DeBallenLijst.Clear();
            MijnKaart = new Kaart();
            WensText = "Begintext";
            FontSizeWens = 15;
            BallenLijst = DeBallenLijst;
            Zichtbaar = Visibility.Hidden;
            CheckEnabled = false;
            FilePath = null;


        }





        
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //  DISABLED DURING BUILD
            if (MessageBox.Show("Wilt u het programma sluiten ?", "Afsluiten", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.No)
                e.Cancel = true;
            
        }




        #region Methods Wens
        private void FontTypeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MijnKaart.Wens.Font = (FontFamily)FontTypeCombo.SelectedItem;
        }

        private void FontSizePlusButton_Click(object sender, RoutedEventArgs e)
        {
            FontSizeWens++;
        }
        private void FontSizeMinButton_Click(object sender, RoutedEventArgs e)
        {
            FontSizeWens--;
        }
        #endregion


        #region Methods Algemeen
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        #endregion


        #region Methods NieuweBal
        

        #endregion

        private void Ellipse_MouseMove(object sender, MouseEventArgs e)
        {
            Ellipse TempEllipse = new Ellipse();
            TempEllipse = (Ellipse)sender;
            var a = TempEllipse.Tag;
            
            if ((e.LeftButton == MouseButtonState.Pressed))
            {
                // Package the data.
                DataObject data = new DataObject();
                data.SetData(DataFormats.StringFormat, TempEllipse.Tag.ToString());
                //data.SetData("Tag", TempEllipse.Tag);
                data.SetData("Object", this);

                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }


        private void Ellipse_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string TempTag = (string)e.Data.GetData(DataFormats.StringFormat);
                //MessageBox.Show(dataString);
                Bal TempBal;
                if (DeBallenLijst.Any(p => p.Tag == int.Parse(TempTag)))
                {
                    TempBal = DeBallenLijst.First(p => p.Tag == int.Parse(TempTag));
                        }
                else
                {
                    TempBal = NieuweBal;
                }
                Point position = e.GetPosition(DropZone);
                TempBal.X = position.X;
                TempBal.Y = position.Y;
                DeBallenLijst.Add(TempBal);

                //resetNieuweBal();
            }
            //TempBal.X = Canvas.GetTop;

            //var a = MijnKaart.ToString();
        }
        //Niet gebruikt
        //private void resetNieuweBal() 
        //{
        //    NieuweBal = new Bal((SelectedColor), 0, 0);
        //    RaisePropertyChanged("SelectedColor");
        //}





        #region Comboboxen
        // opvullen van de combobox achtergrond kleur van de nieuwe bal
        // beide collections worden opgevuld onderaan de code
        private ObservableCollection<Kleur> _systemColors = new ObservableCollection<Kleur>();
        private ObservableCollection<FontFamily> _systemFonts = new ObservableCollection<FontFamily>();
        public ObservableCollection<Kleur> lColors
        {
            get { return _systemColors; }
        }
        public ObservableCollection<FontFamily> lFonts
        {
            get { return _systemFonts; }
        }
        private void LoadSystemFonts()
        {
            _systemFonts.Clear();

            var fonts = Fonts.SystemFontFamilies.OrderBy(f => f.ToString());

            foreach (var f in fonts)
                _systemFonts.Add(f);
        }
        private void LoadSystemColors()
        {
            _systemColors.Clear();

            foreach (PropertyInfo info in typeof(Colors).GetProperties())
            {
                BrushConverter bc = new BrushConverter();
                SolidColorBrush deKleur = (SolidColorBrush)bc.ConvertFromString(info.Name);
                Kleur kleurke = new Kleur();
                kleurke.Borstel = deKleur;
                kleurke.Naam = info.Name;
                _systemColors.Add(kleurke);
            }
        }
        #endregion
    }
}
