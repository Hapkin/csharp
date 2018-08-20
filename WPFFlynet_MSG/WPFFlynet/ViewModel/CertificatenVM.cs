using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WPFFlynet.Personeel;
using WPFFlynet.Vloot;
using static WPFFlynet.App;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Messaging;
using WPFFlynet.Model.Message;

namespace WPFFlynet.ViewModel
{
    class CertificatenVM : ViewModelBase
    {
        public CertificatenVM()
        {
            RegisterCertificaatlijst();
        }

        // Properties
        private ObservableCollection<Certificaat> certificatenlijst;

        public ObservableCollection<Certificaat> lCertificaten
        {
            get { return certificatenlijst; }
            set { certificatenlijst = value; }
        }


        //methods
        void RegisterCertificaatlijst()
        {
            if (lCertificaten == null)
            {
                Messenger.Default.Register<MessageCommunicator>(this, (cert) => {
                    this.lCertificaten = cert.Certificaten;
                });
            }
        }
    }
}
