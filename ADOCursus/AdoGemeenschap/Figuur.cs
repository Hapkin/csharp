using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoGemeenschap
{
    public class Figuur
    {
        public Figuur(Int32 id, String naam, Object versie)
        {
            ID = id;
            Naam = naam;
            Versie = versie;
            Changed = false;

        }
        public Figuur() { }

        public Int32 ID { get; set; }
        private string naamValue;

        public string Naam
        {
            get { return naamValue; }
            set { naamValue = value;
                Changed = true;
            }
        }
        public bool Changed { get; set; }
        public Object Versie { get; set; }
        //Het timestamp datatype is een array van bytes. (byte[]).Daarom vangen dat op in een object.
        
    }
}
