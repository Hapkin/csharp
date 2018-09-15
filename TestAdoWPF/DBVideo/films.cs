using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBVideo
{
    public class Films
    {
        public Films(int nr, string titel, int genre, int inv, int uitv, decimal prijs, int totaal)
        {
            BandNr = nr;
            Titel = titel;
            GenreNr = genre;
            InVoorraad = inv;
            UitVoorraad = uitv;
            Prijs = prijs;
            TotaalVerhuurd = totaal;
            Changed = false;

        }
        public Films() { }

        private bool changeValue;

        public bool Changed
        {
            get { return changeValue; }
            set { changeValue = value; }
        }


        private int bandNrValue;

        public int BandNr
        {
            get { return bandNrValue; }
            set { bandNrValue = value; }
        }
        private string titelValue;

        public string Titel
        {
            get { return titelValue; }
            set { titelValue = value;
                //Changed = true; //testfase
            }
        }
        private int genreValue;

        public int GenreNr
        {
            get { return genreValue; }
            set { genreValue = value; }
        }
        private int inValue;

        public int InVoorraad
        {
            get { return inValue; }
            set { inValue = value;
                Changed = true;
            }
        }

        private int uitValue;

        public int UitVoorraad
        {
            get { return uitValue; }
            set { uitValue = value;
                Changed = true;
            }
        }

        private decimal prijsValue;

        public decimal Prijs
        {
            get { return prijsValue; }
            set { prijsValue = value; }
        }

        private int totaalVerhuurdValue;

        public int TotaalVerhuurd
        {
            get { return totaalVerhuurdValue; }
            set { totaalVerhuurdValue = value; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append($"Naam: {this.Titel}");
            return sb.ToString();
        }






    }
}
