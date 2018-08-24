using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnectie
{
    public class PlantGegevens
    {
        public PlantGegevens(int nummer, string naam, string soort, string leverancier, string kleur, decimal kprijs)
        {
            Nummer = nummer;
            Naam = naam;
            Soort = soort;
            Leverancier = leverancier;
            Kleur = kleur;
            Kostprijs = kprijs;
        }
        public int Nummer { get; set; }
        public string Naam { get; set; }
        public string Soort { get; set; }
        public string Leverancier { get; set; }
        public string Kleur { get; set; }
        public decimal Kostprijs { get; set; }

    }
}
