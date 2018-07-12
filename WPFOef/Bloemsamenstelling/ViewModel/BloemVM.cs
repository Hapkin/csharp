using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bloemsamenstelling;
using BloemSamenstelling.Model;
using System.Reflection;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace Bloemsamenstelling.ViewModel
{
    class BloemVM : ViewModelBase
    {
        public BloemVM()
        {
            //this.cirkelsKleuren = deKleur;
            kleurenLijst= lijstOpmaken();
            CirkelsKleuren = kleurenLijst;
            //RechthoekenKleuren = kleurenLijst;
            //CirkelKaderKleuren = kleurenLijst;
            //RechthoekKaderKleuren = kleurenLijst;
        }

        //private List<Kleur> kleurenLijst = new List<Kleur>();
        private ObservableCollection<Kleur> kleurenLijst = new ObservableCollection<Kleur>();


        public ObservableCollection<Kleur> CirkelsKleuren
        {
            get { return kleurenLijst; }
            set { kleurenLijst = value;
                RaisePropertyChanged("cirkelsKleuren");
                }
        }
        //public ObservableCollection<Kleur> RechthoekenKleuren
        //{
        //    get { return kleurenLijst; }
        //    set { kleurenLijst = value;
        //        RaisePropertyChanged("rechthoekenKleuren");
        //    }
        //}
        //public ObservableCollection<Kleur> CirkelKaderKleuren
        //{
        //    get { return kleurenLijst; }
        //    set { kleurenLijst = value;
        //        RaisePropertyChanged("cirkelKaderKleuren");
        //    }
        //}
        //public ObservableCollection<Kleur> RechthoekKaderKleuren
        //{
        //    get { return kleurenLijst; }
        //    set { kleurenLijst = value;
        //        RaisePropertyChanged("rechthoekKaderKleuren");
        //    }
        //}

        public ObservableCollection<Kleur> lijstOpmaken()
        {
            ObservableCollection<Kleur> Temp = new ObservableCollection<Kleur>();
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
                Temp.Add(kleurke);
            }
            return Temp;
        }

    }
}
