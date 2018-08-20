using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFFlynet.Vloot
{
    public class Vliegtuig: IKost
    {
        //  CONSTRUCTORS  //
        /*public Vliegtuig(decimal prijsPerDag)
        {

            this.BasisKostprijsPerDag = prijsPerDag;
            
        }*/
        public Vliegtuig(string type, int snelheid, int bereik, decimal prijsperdag)
        {
            this.Type = type;
            this.Kruissnelheid = snelheid;
            this.Vliegbereik = bereik;
            this.BasisKostprijsPerDag = prijsperdag;
        }

        //   FIELDS   //


        // ENUM + PROPERTIES //
        public string Type { get; set; }
        public int Kruissnelheid { get; set; }
        public int Vliegbereik { get; set; }
        public decimal BasisKostprijsPerDag { get; set; }

        // METHODS + EVENTS //
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"type: {this.Type}");
            sb.AppendLine($"vliegbereik: {this.Vliegbereik}");
            sb.AppendLine($"kruissnelheid: {this.Kruissnelheid}");
            sb.AppendLine($"basiskost per dag: {this.BasisKostprijsPerDag}");


            return sb.ToString();
        }
       
        
        public decimal BerekenTotaleKostprijsPerDag()
        {

            return this.BasisKostprijsPerDag;
        }

        
    }
}
