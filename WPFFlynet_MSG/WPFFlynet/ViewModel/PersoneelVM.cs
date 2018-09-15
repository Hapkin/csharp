using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WPFFlynet.Personeel;
using WPFFlynet.Vloot;
using WPFFlynet.Model.Message;
//using static WPFFlynet.App;
using WPFFlynet.Model;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Messaging;

using System.Windows.Data;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFFlynet.ViewModel
{
    class PersoneelVM : ViewModelBase, INotifyPropertyChanged
    {
        public PersoneelVM()
        {
            this.Test = 2;
            RegisterPersoneellijst();
            RegisterCertificaatlijst();
        }

        //fields
        private ObservableCollection<Personeelslid> personeelslijst;
        private Personeelslid selectedPersoneelslid;
        private ObservableCollection<Certificaat> certificatenlijst;
        //public event PropertyChangedEventHandler PropertyChanged;


        // Properties
        private int tempValue = 1;
        public int Test
        {
            get { return tempValue; }
            set { tempValue = value;
                RaisePropertyChanged("Test");
            }
        }

        public ObservableCollection<Personeelslid> lPersoneel
        {
            get { return personeelslijst; }
            set { personeelslijst = value; }
        }
        public ObservableCollection<Certificaat> lCertificaten
        {
            get { return certificatenlijst; }
            set {
                certificatenlijst = value;
                RaisePropertyChanged("lCertificaten");
            }
        }


        //methods
        void RegisterPersoneellijst()
        {
            if (lPersoneel == null)
            {
                Messenger.Default.Register<MessageCommunicator>(this, (personeel) => {
                    this.lPersoneel = personeel.Personeel;
                    if (lPersoneel != null)
                        this.SelectedPersoneel= lPersoneel.First(p => p.Naam == "Captain Kirk");
                });
            }
        }
        void RegisterCertificaatlijst()
        {
            if (lCertificaten == null)
            {
                Messenger.Default.Register<MessageCommunicator>(this, (cert) => {
                    this.certificatenlijst = cert.Certificaten;
                });
            }
        }

        public Personeelslid SelectedPersoneel
        {
            get { return selectedPersoneelslid; }
            set
            {
                selectedPersoneelslid = value;

                RaisePropertyChanged("SelectedPersoneel");
                
            }
        }

        //private void RaisePropertyChanged(String info)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(info));
        //    }
        //}


    }


}
