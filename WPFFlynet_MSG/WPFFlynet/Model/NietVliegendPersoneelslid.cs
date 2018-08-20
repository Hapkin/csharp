using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static WPFFlynet.App;
using WPFFlynet.Model;

namespace WPFFlynet.Personeel
{
    class NietVliegendPersoneelslid: Personeelslid
    {
        //  CONSTRUCTORS  //
        public NietVliegendPersoneelslid(string id, string naam, decimal prijsperdag):base(id, naam, prijsperdag)
        {

        }

        //   FIELDS   //


        // ENUM + PROPERTIES //
        
        public int UrenPerWeek { get; set; }
        public Afdeling? Afdeling { get; set; } //? geeft null als object en niet enum met value 0

        // METHODS + EVENTS //
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            if (UrenPerWeek != 0)
                sb.AppendLine($"UrenPerWeek: {this.UrenPerWeek}");
            
            if (Afdeling!=null)
                sb.AppendLine($"Afdeling: {this.Afdeling.ToString()}");
            return sb.ToString();
        }
    }
}
