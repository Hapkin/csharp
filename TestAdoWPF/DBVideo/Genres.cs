using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBVideo
{
    public class Genres
    {
        public Genres(int nr, string naam)
        {
            Nummer = nr;
            Naam = naam;
        }
        public Genres() { }


        private int nummerValue;

        public int Nummer
        {
            get { return nummerValue; }
            set { nummerValue = value; }
        }

        private string naamValue;

        public string Naam
        {
            get { return naamValue; }
            set { naamValue = value; }
        }


    }
}
