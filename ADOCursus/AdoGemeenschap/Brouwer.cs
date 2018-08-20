using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoGemeenschap
{
    public class Brouwer
    {
        public Brouwer(Int32 brNr, String brNaam, String adres, Int16 postcode, String gemeente, Int32? omzet)
        {
            brouwersNrValue = brNr;
            this.BrNaam = brNaam;
            this.Adres = adres;
            this.Postcode = postcode;
            this.Gemeente = gemeente;
            this.Omzet = omzet;
        }
        public string BrNaam { get; set; }

        private Int32 brouwersNrValue;
        public Int32 BrouwerNr
        {
            get { return brouwersNrValue; }
        }
        public string Naam { get; set; }
        public string Adres { get; set; }
        private Int16 postcodeValue;
        public Int16 Postcode
        {
            get { return postcodeValue; }
            set
            {
                if (value < 1000 || value > 9999)
                    throw new Exception("Postcode moet tussen 1000 en 9999 liggen");
                else
                    postcodeValue = value;
            }
        }
        public string Gemeente { get; set; }
        private Int32 omzetValue;
        public Int32? Omzet
        {
            get { return omzetValue; }
            set
            {
                if (value.HasValue && Convert.ToInt32(value) < 0)
                { throw new Exception("Omzet moet positief zijn"); }
                else { omzetValue = (Int32)value; }
            }
        }

    }
}

