using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.ComponentModel;
using MVVMVoorbeeld.View;

namespace MVVMVoorbeeld.ViewModel
{
    class TekstMetOpmaakVM : ViewModelBase
    {
        private Model.TekstMetOpmaak opgemaakteTekst;
        public TekstMetOpmaakVM(Model.TekstMetOpmaak deTekst)
        {
            opgemaakteTekst = deTekst;
        }

        public Action CloseAction { get; set; }


        public string Inhoud
        {
            get { return opgemaakteTekst.Inhoud; }
            set
            {
                opgemaakteTekst.Inhoud = value;
                RaisePropertyChanged("Inhoud");
            }
        }
        public Boolean Vet
        {
            get { return opgemaakteTekst.Vet; }
            set
            {
                opgemaakteTekst.Vet = value;
                RaisePropertyChanged("Vet");
            }
        }
        public Boolean Schuin
        {
            get { return opgemaakteTekst.Schuin; }
            set
            {
                opgemaakteTekst.Schuin = value;
                RaisePropertyChanged("Schuin");
            }
        }
        public RelayCommand NieuwCommand
        {
            get { return new RelayCommand(NieuwTextBox); }
        }
        private void NieuwTextBox()
        {
            Vet = false;
            Schuin = false;
            TextBoxView test = new TextBoxView();
            test.DataContext = this;
            test.Show();
            Inhoud = string.Empty;
        }
        public RelayCommand PrintCommand
        {
            get { return new RelayCommand(PrintPreview); }
        }
        private void PrintPreview()
        {
            PrintPreview test = new PrintPreview();
            test.DataContext = this;
            test.Show();
        }

        public RelayCommand OpslaanCommand
        {
            get { return new RelayCommand(OpslaanBestand); }
        }
        private void OpslaanBestand()
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.FileName = "tekstbox";
                dlg.DefaultExt = ".box";
                dlg.Filter = "Textbox documents |*.box";
                if (dlg.ShowDialog() == true)
                {
                    using (StreamWriter bestand = new StreamWriter(dlg.FileName))
                    {
                        bestand.WriteLine(Inhoud);
                        bestand.WriteLine(Vet.ToString());
                        bestand.WriteLine(Schuin.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("opslaan mislukt : " + ex.Message);
            }
        }
        public RelayCommand OpenenCommand
        {
            get { return new RelayCommand(OpenenBestand); }
        }

        private void OpenenBestand()
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.FileName = "";
                dlg.DefaultExt = ".box";
                dlg.Filter = "Textbox documents |*.box";
                if (dlg.ShowDialog() == true)
                {
                    using (StreamReader bestand = new StreamReader(dlg.FileName))
                    {
                        Inhoud = bestand.ReadLine();
                        Vet = Convert.ToBoolean(bestand.ReadLine());
                        Schuin = Convert.ToBoolean(bestand.ReadLine());
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("openen mislukt : " + ex.Message);
            }

        }
        public RelayCommand AfsluitenCommand
        {
            get { return new RelayCommand(AfsluitenApp); }
        }
        private void AfsluitenApp()
        {
            Application.Current.MainWindow.Close();
        }





        public RelayCommand AfsluitenPrintCommand
        {
            get { return new RelayCommand(AfsluitenPrint); }
        }
        private void AfsluitenPrint()
        {


            //var w = Application.Current.Windows[1];
            //w.Close();

            //Window.GetWindow(AssociatedObject)?.Close();

            foreach (var item in App.Current.Windows)
            {
                MessageBox.Show(Application.Current.MainWindow.Title.ToString());
            }
            //MessageBox.Show(Application.Current.MainWindow.Title.ToString());


            //MessageBox.Show(Application.Current.Windows.ToString());
            //App.Current.Shutdown();


        }

        public RelayCommand<CancelEventArgs> ClosingCommand
        {
            get { return new RelayCommand<CancelEventArgs>(OnWindowClosing); }
        }
        public void OnWindowClosing(CancelEventArgs e)
        {
            if (MessageBox.Show("Afsluiten", "Wilt u het programma sluiten ?",
            MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) ==
            MessageBoxResult.No)
                e.Cancel = true;
        }



    }//einde class
}
