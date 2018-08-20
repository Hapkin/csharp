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
    class VluchtenVM : ViewModelBase
    {

        public VluchtenVM()
        {
            RegisterVluchten();
        }

        // Properties
        private ObservableCollection<Vlucht> vluchtlijst;
        private Vlucht selectedVlucht; //nog doen

        public ObservableCollection<Vlucht> lVluchten
        {
            get { return vluchtlijst; }
            set { vluchtlijst = value; }
        }


        //methods
        void RegisterVluchten()
        {
            if (lVluchten == null)
            {
                Messenger.Default.Register<MessageCommunicator>(this, (personeel) => {
                    this.lVluchten = personeel.Vluchten;
                });
            }
        }

        public Vlucht SelectedVlucht
        {
            get { return selectedVlucht; }
            set
            {
                selectedVlucht = value;
                RaisePropertyChanged("SelectedVlucht");
            }
        }




        
    }
}
