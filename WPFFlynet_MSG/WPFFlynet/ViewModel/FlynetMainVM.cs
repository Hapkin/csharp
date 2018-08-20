using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using WPFFlynet.Personeel;
using WPFFlynet.Vloot;
using WPFFlynet.Model.Message;
//using static WPFFlynet.App;
using WPFFlynet.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace WPFFlynet.ViewModel
{
    public class FlynetMainVM : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the FlynetMainVM class.
        /// </summary>



        public FlynetMainVM()
        {
            //aanmaken van de lijsten
            List<Certificaat> TempCertificatenLijst = Certificaatinlezen();
            lCertificaten = new ObservableCollection<Certificaat>(TempCertificatenLijst);

            List<Personeelslid> TempPersoneelLijst = PersoneelLijstAanmaken(TempCertificatenLijst);
            lPersoneel = new ObservableCollection<Personeelslid>(TempPersoneelLijst);

            List<Vliegtuig> TemplVliegtuigen = VliegtuigLijstAanmaken();
            lVliegtuigen = new ObservableCollection<Vliegtuig>(TemplVliegtuigen);

            List<VliegMaatschappij> TempVliegMaatschappijen = VliegMaatschappijLijstAanmaken(TemplVliegtuigen);
            lVliegMaatschappijen = new ObservableCollection<VliegMaatschappij>(TempVliegMaatschappijen);

            List<Vlucht> TempVluchten = vluchtenLijstAanmaken(TempVliegMaatschappijen, TemplVliegtuigen, TempPersoneelLijst);
            lVluchten = new ObservableCollection<Vlucht>(TempVluchten);

            MsgSend();


            CurrentViewModel = FlynetMainVM._certificatenVM;
            CertificatenViewCommand = new RelayCommand(() => ExecuteCertificatenViewCommand());
            PersoneelViewCommand = new RelayCommand(() => ExecutePersoneelViewCommand());
            VluchtenViewCommand = new RelayCommand(() => ExecuteVluchtenViewCommand());
            //msg command
            //SendCertificatenCommand = new RelayCommand<ObservableCollection<Certificaat>>(MesSendCertificaten);





            //msg command
            //SendCertificatenCommand = new RelayCommand<ObservableCollection<Certificaat>>(MesSendCertificaten);

        }


        void MsgSend()
        {
            MessageCommunicator msg = new MessageCommunicator();
            msg.Certificaten = this.lCertificaten;
            msg.Vluchten = this.lVluchten;
            msg.Personeel = this.lPersoneel;
            Messenger.Default.Send<MessageCommunicator>(msg);
        }


        //field for the msg
        //public RelayCommand<ObservableCollection<Certificaat>> SendCertificatenCommand { get; set; }
        void Registerlijsten()
        {
            if (lCertificaten == null)
            {
                Messenger.Default.Register<MessageCommunicator>(this, (msg) =>
                {
                    this.lCertificaten = msg.Certificaten;
                    this.lPersoneel = msg.Personeel;
                    this.lVluchten = msg.Vluchten;
                });
            }
        }




        //Fields


        //the current view
        private ViewModelBase _currentVM;
        private ObservableCollection<Certificaat> certificatenlijst;
        private ObservableCollection<Personeelslid> personeelslijst;
        private ObservableCollection<Vliegtuig> vliegtuiglijst;
        private ObservableCollection<VliegMaatschappij> vliegMaatschappijlijst;
        private ObservableCollection<Vlucht> vluchtlijst;



        
        

        //static instances of the viewmodels
        readonly static CertificatenVM _certificatenVM = new CertificatenVM();
        readonly static PersoneelVM _personeelVM = new PersoneelVM();
        readonly static VluchtenVM _vluchtenVM = new VluchtenVM();

        // Properties
        public ObservableCollection<Vlucht> lVluchten
        {
            get { return vluchtlijst; }
            set
            {
                vluchtlijst = value;
                RaisePropertyChanged("lVluchten");
            }
        }
        public ObservableCollection<VliegMaatschappij> lVliegMaatschappijen
        {
            get { return vliegMaatschappijlijst; }
            set
            {
                vliegMaatschappijlijst = value;
                RaisePropertyChanged("lVliegMaatschappijen");
            }
        }
        public ObservableCollection<Vliegtuig> lVliegtuigen
        {
            get { return vliegtuiglijst; }
            set
            {
                vliegtuiglijst = value;
                RaisePropertyChanged("lVliegtuigen");
            }
        }
        


        public ObservableCollection<Certificaat> lCertificaten
        {
            get { return certificatenlijst; }
            set
            {
                certificatenlijst = value;
                RaisePropertyChanged("lCertificaten");
            }
        }



        public ObservableCollection<Personeelslid> lPersoneel
        {
            get { return personeelslijst; }
            set
            {
                personeelslijst = value;

                RaisePropertyChanged("lPersoneel");
            }
        }


        /// Simple property to hold the 'FirstViewCommand' - when executed
        /// it will change the current view to the 'FirstView'
        public ICommand CertificatenViewCommand { get; private set; }
        public ICommand PersoneelViewCommand { get; private set; }
        public ICommand VluchtenViewCommand { get; private set; }

        //property with what VM to show
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentVM;
            }
            set
            {
                if (_currentVM == value)
                    return;
                _currentVM = value;
                RaisePropertyChanged("CurrentViewModel");
            }
        }




        //Methods


        /// <summary>
        /// de commands om van view te wijzigen
        /// </summary>
        private void ExecuteCertificatenViewCommand()
        {

            CurrentViewModel = FlynetMainVM._certificatenVM;
        }
        private void ExecutePersoneelViewCommand()
        {
            CurrentViewModel = FlynetMainVM._personeelVM;
        }
        private void ExecuteVluchtenViewCommand()
        {
            CurrentViewModel = FlynetMainVM._vluchtenVM;
        }






        static List<Certificaat> Certificaatinlezen()
        {
            List<Certificaat> lijstCert = new List<Certificaat>();
            //****************************************************************************************
            // Certificaten
            //****************************************************************************************

            Certificaat PPL = new Certificaat
            {
                CertificaatAfkorting = "PPL",
                CertificaatOmschrijving = "Private Pilot License"
            };
            lijstCert.Add(PPL);

            Certificaat ATPL = new Certificaat
            {
                CertificaatAfkorting = "ATPL",
                CertificaatOmschrijving = "Airline Transport Pilot License"
            };
            lijstCert.Add(ATPL);

            Certificaat IR = new Certificaat
            {
                CertificaatAfkorting = "IR",
                CertificaatOmschrijving = "Instrument Rating"
            };
            lijstCert.Add(IR);

            Certificaat CPL = new Certificaat
            {
                CertificaatAfkorting = "CPL",
                CertificaatOmschrijving = "Commercial Pilot License"
            };
            lijstCert.Add(CPL);
            Certificaat ME = new Certificaat
            {
                CertificaatAfkorting = "ME",
                CertificaatOmschrijving = "Multi Engine"
            };
            lijstCert.Add(ME);

            Certificaat MCC = new Certificaat
            {
                CertificaatAfkorting = "MCC",
                CertificaatOmschrijving = "Multi Crew Concept"
            };
            lijstCert.Add(MCC);

            Certificaat EHBO = new Certificaat
            {
                CertificaatAfkorting = "EHBO",
                CertificaatOmschrijving = "First Aid"
            };
            lijstCert.Add(EHBO);

            Certificaat EVAC = new Certificaat
            {
                CertificaatAfkorting = "EVAC",
                CertificaatOmschrijving = "Evacution Procedures"
            };
            lijstCert.Add(EVAC);

            Certificaat FIRE = new Certificaat
            {
                CertificaatAfkorting = "FIRE",
                CertificaatOmschrijving = "Fire Fighting"
            };
            lijstCert.Add(FIRE);


            Certificaat SURV = new Certificaat
            {
                CertificaatAfkorting = "SURV",
                CertificaatOmschrijving = "Survival"
            };
            lijstCert.Add(SURV);


            Certificaat IFS = new Certificaat
            {
                CertificaatAfkorting = "IFS",
                CertificaatOmschrijving = "In Flight Service"
            };
            lijstCert.Add(IFS);

            return lijstCert;

        }
        static List<Personeelslid> PersoneelLijstAanmaken(List<Certificaat> lCert)
        {
            List<Personeelslid> lPersoneel = new List<Personeelslid>();


            lPersoneel.Add(new CockpitPersoneelslid("001", "Captain Kirk", 500, Graad.Captain, 5000, new List<Certificaat>(lCert.FindAll(p => p.CertificaatAfkorting == "PPL"|| p.CertificaatAfkorting == "ATPL" || p.CertificaatAfkorting == "CPL" || p.CertificaatAfkorting == "SURV"))));


            lPersoneel.Add(new CockpitPersoneelslid("002", "Spock", 400, Graad.SecondOfficer, 4500, new List<Certificaat>(lCert.FindAll(p => p.CertificaatAfkorting == "PPL" || p.CertificaatAfkorting == "ATPL"|| p.CertificaatAfkorting == "CPL" || p.CertificaatAfkorting == "IFS"))));

            lPersoneel.Add(new KabinePersoneelslid("004", "Pavel Chekov", 300, Graad.Purser, "deur1", new List<Certificaat>(lCert.FindAll(p => p.CertificaatAfkorting == "ME" || p.CertificaatAfkorting == "MCC" || p.CertificaatAfkorting == "EHBO" || p.CertificaatAfkorting == "IFS"))));

            lPersoneel.Add(new KabinePersoneelslid("006", "SkyWalker", 300, Graad.Steward, "nooduitgang", new List<Certificaat>(lCert.FindAll(p => p.CertificaatAfkorting == "FIRE" || p.CertificaatAfkorting == "SURV" || p.CertificaatAfkorting == "EHBO" || p.CertificaatAfkorting == "IFS"))));

            return lPersoneel;
        }
        static List<Vliegtuig> VliegtuigLijstAanmaken()
        {
            List<Vliegtuig> lVliegtuigen = new List<Vliegtuig>();
            lVliegtuigen.Add(new Vliegtuig("Boeing787", 15700, 913, 2000));
            lVliegtuigen.Add(new Vliegtuig("AntonovAn-30", 1600, 430, 300));
            lVliegtuigen.Add(new Vliegtuig("BritishAerospace146", 1600, 750, 600));
            lVliegtuigen.Add(new Vliegtuig("AntonovAn-225", 15400, 800, 1500));

            return lVliegtuigen;
        }
        static List<VliegMaatschappij> VliegMaatschappijLijstAanmaken(List<Vliegtuig> lVliegtuigen)
        {
            List<VliegMaatschappij> lVliegMaatschappijen = new List<VliegMaatschappij>();
            VliegMaatschappij mBrusselsAirlines = new VliegMaatschappij();
            mBrusselsAirlines.VliegMaatschappijID = 1;
            mBrusselsAirlines.VliegMaatschappijNaam = Maatschappij.BrusselsAirlines;

            mBrusselsAirlines.Vloot = new List<Vliegtuig>(lVliegtuigen.FindAll(v => v.Type == "Boeing787" || v.Type == "BritishAerospace146"));
            lVliegMaatschappijen.Add(mBrusselsAirlines);

            VliegMaatschappij mTNTAirways = new VliegMaatschappij();
            mTNTAirways.VliegMaatschappijID = 2;
            mTNTAirways.VliegMaatschappijNaam = Maatschappij.TNTAirways;

            mTNTAirways.Vloot = new List<Vliegtuig>(lVliegtuigen.FindAll(v => v.Type == "AntonovAn-30" || v.Type == "AntonovAn-225"));
            lVliegMaatschappijen.Add(mTNTAirways);





            return lVliegMaatschappijen;
        }
        static List<Vlucht> vluchtenLijstAanmaken(List<VliegMaatschappij> lVliegMaatschappij, List<Vliegtuig> lVliegtuigen, List<Personeelslid> lPersoneel)
        {
            List<Vlucht> lVlucht = new List<Vlucht>();

            var oVliegMaatschappij = lVliegMaatschappij.Find(m => m.VliegMaatschappijNaam is Maatschappij.BrusselsAirlines);
            var oVliegtuig = oVliegMaatschappij.Vloot.Find(v => v.Type == "Boeing787");
            var loPersoneel = lPersoneel.FindAll(v => v.Naam == "Captain Kirk" || v.Naam == "Spock" || v.Naam == "Pavel Chekov" || v.Naam == "SkyWalker");

            lVlucht.Add(new Vlucht(1, "New York", 2, oVliegtuig, loPersoneel, oVliegMaatschappij));

            var oVliegMaatschappij2 = lVliegMaatschappij.Find(m => m.VliegMaatschappijNaam is Maatschappij.TNTAirways);
            var oVliegtuig2 = oVliegMaatschappij2.Vloot.Find(v => v.Type == "AntonovAn-225");
            var loPersoneel2 = lPersoneel.FindAll(v => v.Naam == "Captain Kirk" || v.Naam == "Pavel Chekov");

            lVlucht.Add(new Vlucht(2, "Beijing", 1, oVliegtuig2, loPersoneel2, oVliegMaatschappij2));

            var oVliegMaatschappij3 = lVliegMaatschappij.Find(m => m.VliegMaatschappijNaam is Maatschappij.BrusselsAirlines);
            var oVliegtuig3 = oVliegMaatschappij3.Vloot.Find(v => v.Type == "BritishAerospace146");
            var loPersoneel3 = lPersoneel.FindAll(v => v.Naam == "Captain Kirk" || v.Naam == "SkyWalker");

            lVlucht.Add(new Vlucht(3, "Singapore", 2, oVliegtuig3, loPersoneel3, oVliegMaatschappij3));




            //lVlucht.Add(vluchtAanmaken(lVliegMaatschappij, lVliegtuigen, lPersoneel,));

            return lVlucht;

        }
    }
}