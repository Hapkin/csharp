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
            changed = false;
        }
        public int Nummer { get;
            set; }
        public string Naam { get; set; }
        public string Soort { get; set; }
        public string Leverancier { get; set; }
        private string kleurValue;

        public string Kleur
        {
            get { return kleurValue; }
            set { kleurValue = value;
                changed = true;
            }
        }
        private decimal prijsValue;

        public decimal Kostprijs
        {
            get { return prijsValue; }
            set { prijsValue = value;
                changed = true;
            }
        }

        public bool changed { get; set; }

    }
}
