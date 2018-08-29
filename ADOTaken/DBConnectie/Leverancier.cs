using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DBConnectie
{
    public class Leverancier
    {
        public Leverancier(int nr, string naam, string adres, string postnr, string plaats)
        {
            LevNr = nr;
            Naam = naam;
            Adres = adres;
            PostNr = postnr;
            Woonplaats = plaats;
            Changed = false;
        }
        public Leverancier()
        { Changed = false; }

        private bool changedvalue;

        public bool Changed
        {
            get { return changedvalue; }
            set { changedvalue = value; }
        }

        private int levNrVal;

        public int LevNr
        {
            get { return levNrVal; }
            set { levNrVal = value;
                Changed = true;
            }
        }

        private string naamVal;

        public string Naam
        {
            get { return naamVal; }
            set { naamVal = value; Changed = true; }
        }


        private string adresVal;

        public string Adres
        {
            get { return adresVal; }
            set { adresVal = value;
                Changed = true;
            }
        }


        private string postnrVal;

        public string PostNr
        {
            get { return postnrVal; }
            set { postnrVal = value; Changed = true; }
        }

        private string woonplaatsVal;

        public string Woonplaats
        {
            get { return woonplaatsVal; }
            set { woonplaatsVal = value;
                Changed = true;
            }
        }




        
    }
}
