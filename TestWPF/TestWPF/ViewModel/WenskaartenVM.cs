using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using TestWPF.Model;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Reflection;
using System.IO;
using Microsoft.Win32;

namespace TestWPF.ViewModel
{
    class WenskaartenVM: ViewModelBase, INotifyPropertyChanged
    {
        
        public WenskaartenVM()
        {
            LoadSystemFonts();
            LoadSystemColors();
            MijnKaart = new Kaart();
            MijnFile = new Model.File();
            MijnFile.MijnKaart = MijnKaart;
            //MijnFile.Path = "Dit is een test niet geimplementeerd";



            Zichtbaar = Visibility.Hidden;
            IsEnabled = false;


            NieuweBal = new Bal(lColors[0], 0,0); //Bal(Kleur kleur, int x, int y, int tag)



            //***TEMP add 3 balls
            List<Bal> TempBallen = new List<Bal>();
            
            Bal TempBal = new Bal(lColors[10], 10,10);
            Bal TempBal2 = new Bal(lColors[15], 50, 10);
            Bal TempBal3 = new Bal(lColors[20], 10, 50);


            TempBallen.Add(TempBal);
            TempBallen.Add(TempBal2);
            TempBallen.Add(TempBal3);



            MijnKaart.Ballen = TempBallen;

            
            //***

            //objecten en lijsten opbouwen





            //Command triggers activeren
            this.OnClosingCommand =
               new RelayCommand<CancelEventArgs>(this.OnClosingCommandExecuted);
            this.NieuwCommand =
               new RelayCommand<RoutedEventArgs>(this.NieuwCommandExecuted);
            this.OpenenCommand =
               new RelayCommand<RoutedEventArgs>(this.OpenenCommandExecuted);
            this.OpslaanCommand =
               new RelayCommand<RoutedEventArgs>(this.OpslaanCommandExecuted);
            this.AfdrukvoorbeeldCommand =
               new RelayCommand<RoutedEventArgs>(this.AfdrukvoorbeeldCommandExecuted);

            this.AfsluitenCommand =
               new RelayCommand<RoutedEventArgs>(this.AfsluitenCommandExecuted);

            //KerstkaartCommand
            this.KerstkaartCommand = 
               new RelayCommand<RoutedEventArgs>(this.KerstkaartCommandExecuted);
            //GeboortekaartCommand
            this.GeboortekaartCommand =
               new RelayCommand<RoutedEventArgs>(this.GeboortekaartCommandExecuted);



        } //*** EINDE Constructor~!
        private Model.File fileValue;

        public Model.File MijnFile
        {
            get { return fileValue; }
            set {
                fileValue = value;
                RaisePropertyChanged("MijnFile");
                RaisePropertyChanged("MijnStatus");
            }
        }
        public string MijnStatus {
            get {
                if (fileValue.Path == null)
                    return "Nieuw";
                else
                    return fileValue.Path;
            }
        }





        // VM Field en Properties
        private Bal balValue;

        public Bal NieuweBal
        {
            get { return balValue; }
            set {
                balValue = value;
                RaisePropertyChanged("NieuweBal");
            }
        }



        public List<Bal> BallenLijst
        {
            get { return MijnKaart.Ballen; }
            set {
                MijnKaart.Ballen = value;
                RaisePropertyChanged("BallenLijst");
            }
        }



        private ObservableCollection<FontFamily> _systemFonts = new ObservableCollection<FontFamily>();
        private ObservableCollection<Kleur> _systemColors = new ObservableCollection<Kleur>();
        
        public ObservableCollection<FontFamily> lFonts
        {
            get { return _systemFonts; }
        }
        public ObservableCollection<Kleur> lColors
        {
            get { return _systemColors; }
        }

        public string WensText
        {
            get { return MijnKaart.Wens.Text; }
            set {
                MijnKaart.Wens.Text = value;
                RaisePropertyChanged("WensText");
            }
        }




        public FontFamily SelectedFont
        {
            get {
                if (MijnKaart.Wens.Font!=null)
                    return MijnKaart.Wens.Font;
                else
                    return _systemFonts[3];
            }
            set
            {
                MijnKaart.Wens.Font = value;
                RaisePropertyChanged("SelectedFont"); //??
            }
        }
        public int FontSize
        {
            get
            {
                    return MijnKaart.Wens.Size;
                
            }
            set
            {
                MijnKaart.Wens.Size = value;
                RaisePropertyChanged("FontSize"); //??
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




        private Kaart kaartValue;

        public Kaart MijnKaart
        {
            get { return kaartValue; }
            set { kaartValue = value;
                RaisePropertyChanged("MijnKaart");
            }
        }
        private Visibility zichtbaarValue;

        public Visibility Zichtbaar
        {
            get { return zichtbaarValue; }
            set { zichtbaarValue = value;
                RaisePropertyChanged("Zichtbaar");
            }
        }

        private bool isEnableValue;

        public bool IsEnabled
        {
            get { return isEnableValue; }
            set { isEnableValue = value;
                RaisePropertyChanged("IsEnabled");
            }
        }










        // Commands
        public RelayCommand<RoutedEventArgs> FontSizePlusCommand
        {
            get { return new RelayCommand<RoutedEventArgs>(FontSizePlusCommandExecuted); }
        }
        public RelayCommand<RoutedEventArgs> FontSizeMinCommand
        {
            get { return new RelayCommand<RoutedEventArgs>(FontSizeMinCommandExecuted); }
        }
        public RelayCommand<RoutedEventArgs> KerstkaartCommand { get; set; }
        public RelayCommand<RoutedEventArgs> GeboortekaartCommand { get; set; }
        


        public RelayCommand<CancelEventArgs> OnClosingCommand { get; set; }
        public RelayCommand<RoutedEventArgs> NieuwCommand { get; set; }
        public RelayCommand<RoutedEventArgs> OpenenCommand { get; set; }
        public RelayCommand<RoutedEventArgs> OpslaanCommand { get; set; }
        public RelayCommand<RoutedEventArgs> AfdrukvoorbeeldCommand { get; set; }    
        public RelayCommand<RoutedEventArgs> AfsluitenCommand { get; set; }
        private void FontSizePlusCommandExecuted(RoutedEventArgs e)
        {
            int temp = MijnKaart.Wens.Size;
            temp++;
            FontSize = temp;
            //RaisePropertyChanged("SizeFont");
        }
        private void FontSizeMinCommandExecuted(RoutedEventArgs e)
        {
            FontSize--;
            //RaisePropertyChanged("SizeFont");
        }
        private void KerstkaartCommandExecuted(RoutedEventArgs e)
        {
            NieuwCommandExecuted(null);
            string naam = "Kerstkaart";
            
            BitmapImage img = new BitmapImage(new Uri("pack://application:,,,/Img/kerstkaart.jpg",UriKind.Absolute));
            MijnKaart.Achtergrond = new Achtergrond(naam, img);
            Zichtbaar = Visibility.Visible;
            IsEnabled = true;
            RaisePropertyChanged("Zichtbaar");
            RaisePropertyChanged("MijnKaart");
            //if (mijnKaart.Achtergrond != null)
#pragma warning disable CS0219 // Variable is assigned but its value is never used
            //{ int a = 1; }
#pragma warning restore CS0219 // Variable is assigned but its value is never used
                
        }
        private void GeboortekaartCommandExecuted(RoutedEventArgs e)
        {
            NieuwCommandExecuted(null);
            string naam = "Geboortekaart";

            BitmapImage img = new BitmapImage(new Uri("pack://application:,,,/Img/geboortekaart.jpg", UriKind.Absolute));
            MijnKaart.Achtergrond = new Achtergrond(naam, img);
            Zichtbaar = Visibility.Visible;
            IsEnabled = true;


            //RaisePropertyChanged("Zichtbaar");

            RaisePropertyChanged("MijnKaart");
        }


            private void NieuwCommandExecuted(RoutedEventArgs e)
        {
            MijnKaart = null;
            MijnKaart = new Kaart();
            Zichtbaar = Visibility.Hidden;
            IsEnabled = false;
            
        }
        private void OpenenCommandExecuted(RoutedEventArgs e)
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

                        MijnFile.Path = dlg.FileName;


                        //Achtergrond instellen + nieuwe MijnKaart wordt gestart
                        //lijst[0] == Achtergrond: Geboortekaart
                        string[] achtergrond = lijst[0].Split(':');
                                              
                        if (achtergrond[1]== " Geboortekaart")
                            GeboortekaartCommandExecuted(null);
                        else
                            KerstkaartCommandExecuted(null);

                        /* lijst[2] tot [5] (indien null wordt er null geschreven)
                           Wens:
                            Text:Begintextdfgd
                            Font:Bell MT
                            Size:18
                        */
                        string[] wenstProp = lijst[3].Split(':');
                        if (wenstProp[1] != "null")
                            MijnKaart.Wens.Text = wenstProp[0];
                        wenstProp = lijst[4].Split(':');
                        if (wenstProp[1] != "null")
                            MijnKaart.Wens.Text = wenstProp[0];
                        wenstProp = lijst[5].Split(':');
                        if (wenstProp[1] != "null")
                            MijnKaart.Wens.Text = wenstProp[0];



                        // einde uitwerking load| 15u45
                        // ballen lijst wordt momenteel verstoord zodat er 0 ballen worden opgeslagen.



                        RaisePropertyChanged("MijnStatus");

                        Zichtbaar = Visibility.Visible;
                        RaisePropertyChanged("Zichtbaar");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("openen mislukt : " + ex.Message);
            }


        }
        private void OpslaanCommandExecuted(RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                if(MijnKaart.Achtergrond.Naam == "Geboortekaart")
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
                        MijnFile.Path = dlg.FileName;
                        RaisePropertyChanged("MijnStatus");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("opslaan mislukt: " + ex.Message);
            }
        }
        private void AfdrukvoorbeeldCommandExecuted(RoutedEventArgs e)
        {

#pragma warning disable CS0219 // Variable is assigned but its value is never used
            int a = 1;
#pragma warning restore CS0219 // Variable is assigned but its value is never used
        }
        
        private void AfsluitenCommandExecuted(RoutedEventArgs e)
        {
            if (MessageBox.Show( "Wilt u het programma sluiten ?", "Afsluiten", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                Application.Current.MainWindow.Close();
        }

        private void OnClosingCommandExecuted(CancelEventArgs cancelEventArgs)
        {

            //bool mustCancelClosing= cancelEventArgs.Cancel;
            bool mustCancelClosing = false;

            //!!!terug activeren!!!
            if (MessageBox.Show( "Wilt u het programma sluiten ?", "Afsluiten", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.No)
                mustCancelClosing = true;

            if (mustCancelClosing)
            {
                cancelEventArgs.Cancel = true;
            }
        }

        private void AfdrukvoorbeeldExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        //public RelayCommand<MouseEventArgs> MouseDownCommand
        //{

        ////get { return new RelayCommand<MouseEventArgs>(MuisIn); }
        //}



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

            //var colors = Fonts.SystemFontFamilies.OrderBy(f => f.ToString());
            foreach (PropertyInfo info in typeof(Colors).GetProperties())
            {
                BrushConverter bc = new BrushConverter();
                SolidColorBrush deKleur = (SolidColorBrush)bc.ConvertFromString(info.Name);
                Kleur kleurke = new Kleur();
                kleurke.Borstel = deKleur;
                kleurke.Naam = info.Name;
                kleurke.Hex = deKleur.ToString();
                kleurke.Rood = deKleur.Color.R;
                kleurke.Groen = deKleur.Color.G;
                kleurke.Blauw = deKleur.Color.B;
                _systemColors.Add(kleurke);
            }
        }


    }






}
