using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static WPFFlynet.App;
using WPFFlynet.Model;

namespace WPFFlynet.Personeel
{
    class KabinePersoneelslid : VliegendPersoneelslid
    {
        //  CONSTRUCTORS  //
        public KabinePersoneelslid(string id, string naam, decimal prijsperdag) : base(id, naam, prijsperdag)
        {

            this.Graad = Graad.Steward;
        }
        public KabinePersoneelslid(string id, string naam, decimal prijsperdag, Graad graad, string werkpositie, List<Certificaat> lCert): base(id, naam, prijsperdag, lCert)
        {
            this.Graad = graad;
            this.Werkpositie = werkpositie;
        }

        //   FIELDS   //
        private Graad graadValue;

        // ENUM + PROPERTIES //
        public string Werkpositie { get; set; }
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
                        case Graad.Purser:
                        case Graad.Steward:
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
            sb.AppendLine($"graad: {Graad.ToString()}");
            if (Werkpositie != null)
                sb.AppendLine($"positie: {Werkpositie.ToString()}");

            sb.AppendLine($"kostprijs per dag: {this.BerekenTotaleKostprijsPerDag()}");
            sb.AppendLine("-------------------------------------");

            return sb.ToString();
        }
        public override decimal BerekenTotaleKostprijsPerDag()
        {
            decimal prijs;
            prijs = base.BerekenTotaleKostprijsPerDag();
            switch (Graad)
            {
                case Graad.Purser:
                    prijs = prijs * 1.2M;
                    break;
                case Graad.Steward:
                    //prijs = prijs;
                    break;
            }

            if (this.Certificaten.Exists(i => i.CertificaatAfkorting=="EHBO"))
            {
                prijs += 5;
            }
            


            return prijs;
        }

    }
}
