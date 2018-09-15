using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static WPFFlynet.App;
using WPFFlynet.Model;

namespace WPFFlynet.Personeel
{
    class CockpitPersoneelslid : VliegendPersoneelslid
    {
        //  CONSTRUCTORS  //
        public CockpitPersoneelslid(string id, string naam, decimal prijsperdag) : base(id, naam, prijsperdag)
        {


            this.Graad = Graad.JuniorOfficer;
        }
        public CockpitPersoneelslid(string id, string naam, decimal prijsperdag, Graad graad, int vlieguren, List<Certificaat> lCert) : base(id, naam, prijsperdag, lCert)
        {
            this.Graad = graad;
            this.VliegUren = vlieguren;
        }

        //   FIELDS   //
        private Graad graadValue;

        // ENUM + PROPERTIES //
        public int VliegUren { get; set; }
        public override Graad Graad
        {
            get
            { return graadValue; }

            set
            {
                try
                {
                    switch (value)
                    {
                        case Graad.Captain:
                        case Graad.SecondOfficer:
                        case Graad.SeniorFlightOfficer:
                        case Graad.JuniorOfficer:
                            graadValue = value;
                            break;
                        default:
                            throw new GraadException(value, $"Graad: {value} mag niet gebruikt worden!");
                    }

                }
                catch (GraadException ex)
                {
                    Console.WriteLine("Fout:" + ex.Message);
                }
            }
        }

        // METHODS + EVENTS //
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            if (VliegUren != 0)
                sb.AppendLine($"Vlieguren: {VliegUren}");
                      
            sb.AppendLine(Graad.ToString());
            sb.AppendLine($"kostprijs per dag: {BerekenTotaleKostprijsPerDag().ToString()}");
            sb.AppendLine("-------------------------------------");
            return sb.ToString();
        }
        public override decimal BerekenTotaleKostprijsPerDag()
        {
            decimal prijs;
            prijs = base.BerekenTotaleKostprijsPerDag();
            switch (Graad)
            {
                case Graad.Captain:
                    prijs = prijs * 1.3M;
                    break;
                case Graad.SeniorFlightOfficer:
                    prijs = prijs * 1.2M;
                    break;
                case Graad.SecondOfficer:
                    prijs = prijs * 1.1M;
                    break;
                case Graad.JuniorOfficer:
                    //prijs = prijs;
                    break;
            }

            if (this.Certificaten.Exists(i => i.CertificaatAfkorting == "CPL"))
            {
                prijs += 50;
            }
            return prijs;
        }


    }
}
