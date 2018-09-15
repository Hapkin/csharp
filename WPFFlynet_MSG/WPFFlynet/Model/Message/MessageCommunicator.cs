using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WPFFlynet.Personeel;
using WPFFlynet.Vloot;
//using static WPFFlynet.App;
using System.Collections.ObjectModel;


namespace WPFFlynet.Model.Message
{
    class MessageCommunicator
    {
        private ObservableCollection<Certificaat> certificatenlijst;

        public ObservableCollection<Certificaat> Certificaten
        {
            get { return certificatenlijst; }
            set { certificatenlijst = value; }
        }

        public ObservableCollection<Vlucht> Vluchten { get; set; }

        public ObservableCollection<Personeelslid> Personeel { get; set; }


    }
}
