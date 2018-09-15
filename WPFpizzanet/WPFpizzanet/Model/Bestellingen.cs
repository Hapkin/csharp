using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFpizzanet.Model
{
    public class Bestellingen
    {
        private List<Bestelling> bestellingslijstValue;

        public List<Bestelling> bestellingslijst {
            get {return bestellingslijstValue; }
            set { bestellingslijstValue = value; }
        }
         
    }
}
