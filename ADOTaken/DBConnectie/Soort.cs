using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnectie
{
    public class Soort
    {
        public Soort(int nr, string naam, int mag)
        {
            this.SoortNr = nr;
            this.Naam = naam;
            this.Magazijn = mag;
        }
        public int SoortNr { get; private set; }
        public string Naam { get; set; }
        public int Magazijn{ get; set; }
    }
}
