using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingBonMVVM.Model
{
    public class ParkingBon
    {
        public ParkingBon()
        {
            Datum = DateTime.Now;
            Aankomst = DateTime.Now;
            Vertrek = Aankomst;
            Bedrag = 0;
        }
        public DateTime Datum { get; set; }
        public DateTime Aankomst { get; set; }
        public DateTime Vertrek { get; set; }
        public int Bedrag { get; set; }
    }
}
