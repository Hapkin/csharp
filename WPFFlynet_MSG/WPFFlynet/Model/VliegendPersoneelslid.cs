using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static WPFFlynet.App;
using WPFFlynet.Model;

namespace WPFFlynet.Personeel
{
    public abstract class VliegendPersoneelslid : Personeelslid
    {
        //  CONSTRUCTORS  //
        public VliegendPersoneelslid(string id, string naam, decimal prijsperdag) : base(id, naam, prijsperdag) { }
        public VliegendPersoneelslid(string id, string naam, decimal prijsperdag, List<Certificaat> lCert) : base(id, naam, prijsperdag) {
            this.Certificaten = lCert;
        }

        //   FIELDS   //


        // ENUM + PROPERTIES //
        public abstract Graad Graad { get; set; }
        public List<Certificaat> Certificaten { get; set; }

        // METHODS + EVENTS //
        public class GraadException : Exception
        {
            public GraadException(Graad graad, string msg) : base(msg)
            { }

        }
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            if (Certificaten != null)
            {
                sb.AppendLine("Certificaten:");
                Certificaten.ForEach(i => sb.Append($"{i.CertificaatAfkorting} "));
            }
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
