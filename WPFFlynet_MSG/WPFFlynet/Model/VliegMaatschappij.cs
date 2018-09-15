using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static WPFFlynet.App;
using WPFFlynet.Model;

namespace WPFFlynet.Vloot
{
    public class VliegMaatschappij
    {
        //  CONSTRUCTORS  //


        //   FIELDS   //


        // ENUM + PROPERTIES //
        public int VliegMaatschappijID { get; set; }
        public Maatschappij VliegMaatschappijNaam { get; set; }
        public List<Vliegtuig> Vloot { get; set; }

        // METHODS + EVENTS //
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Naam: {this.VliegMaatschappijID} - {this.VliegMaatschappijNaam}");
            sb.AppendLine("vliegtuigen: ");
            Vloot.ForEach(i => sb.AppendLine(i.Type.ToString()));


            return sb.ToString();
        }

    }
}
