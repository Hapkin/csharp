using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System.ComponentModel;
using System.IO;

namespace ParkingBonMVVM.ViewModel
{
    class ParkingBonVM: ViewModelBase
    {
        private Model.ParkingBon parkingbon;
        public ParkingBonVM(Model.ParkingBon deParkingBon)
        {
            parkingbon = deParkingBon;
        }
        public DateTime Datum
        {
            get { return parkingbon.Datum; }
            set
            {
                parkingbon.Datum = value;
                RaisePropertyChanged("Datum");
            }
        }
        public DateTime Aankomst
        {
            get { return parkingbon.Aankomst; }
            set
            {
                parkingbon.Aankomst = value;
                RaisePropertyChanged("Aankomst");
            }
        }
        public DateTime Vertrek
        {
            get { return parkingbon.Vertrek; }
            set
            {
                parkingbon.Vertrek = value;
                RaisePropertyChanged("Vertrek");
            }
        }
        public int Bedrag
        {
            get { return parkingbon.Bedrag; }
            set
            {
                parkingbon.Bedrag = value;
                RaisePropertyChanged("Bedrag");
            }
        }
        public RelayCommand MeerCommand
        { get { return new RelayCommand(MeerBetalen); } }
        private void MeerBetalen()
        {
            if (Vertrek.Hour < 22)
                Bedrag++;
            Vertrek = Aankomst.AddHours(0.5 * Bedrag);
        }
        public RelayCommand MinderCommand
        { get { return new RelayCommand(MinderBetalen); } }
        private void MinderBetalen()
        {
            if (Bedrag > 0)
                Bedrag--;
            Vertrek = Aankomst.AddHours(0.5 * Bedrag);
        }
        public RelayCommand NieuwCommand
        { get { return new RelayCommand(NieuweBon); } }
        private void NieuweBon()
        {
            Bedrag = 0;
            Datum = DateTime.Today;
            Aankomst = DateTime.Now;
            Vertrek = DateTime.Now;
        }
        public RelayCommand OpenenCommand
        { get { return new RelayCommand(OpenenBon); } }
        private void OpenenBon()
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.FileName = "";
                dlg.DefaultExt = ".bon";
                dlg.Filter = "Parkingbonnen |*.bon";
                if (dlg.ShowDialog() == true)
                {
                    using (StreamReader bestand = new StreamReader(dlg.FileName))
                    {
                        Datum = Convert.ToDateTime(bestand.ReadLine());
                        Aankomst = Convert.ToDateTime(bestand.ReadLine());
                        Bedrag = Convert.ToInt32(bestand.ReadLine());
                        Vertrek = Convert.ToDateTime(bestand.ReadLine());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("openen mislukt : " + ex.Message);
            }
        }
        public RelayCommand OpslaanCommand
        { get { return new RelayCommand(OpslaanBon); } }
        private void OpslaanBon()
        {
            try
            {
                string bestandsnaam;
                bestandsnaam = Datum.Day + "-" + Datum.Month + "-" + Datum.Year +
                "om" + Aankomst.Hour + "-" + Aankomst.Minute + ".bon";
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.FileName = bestandsnaam;
                dlg.DefaultExt = ".bon";
                dlg.Filter = "Parkingbonnen |*.bon";
                if (dlg.ShowDialog() == true)
                {
                    using (StreamWriter bestand = new StreamWriter(dlg.FileName))
                    {
                        bestand.WriteLine(Datum.ToShortDateString());
                        bestand.WriteLine(Aankomst.ToShortTimeString());
                        bestand.WriteLine(Bedrag);
                        bestand.WriteLine(Vertrek.ToShortTimeString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("opslaan mislukt : " + ex.Message);
            }
        }
        public RelayCommand AfsluitenCommand
        { get { return new RelayCommand(AfsluitenApp); } }
        public void AfsluitenApp()
        {
            Application.Current.MainWindow.Close();
        }
        public RelayCommand<CancelEventArgs> AfsluitenEvent
        { get { return new RelayCommand<CancelEventArgs>(OnWindowClosing); } }
        public void OnWindowClosing(CancelEventArgs e)
        {
            if (MessageBox.Show("Afsluiten", "Wilt u het programma sluiten ?",
            MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) ==
            MessageBoxResult.No)
                e.Cancel = true;
        }
    }
}

