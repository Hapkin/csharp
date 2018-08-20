using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFFlynet.Vloot;
using WPFFlynet.Personeel;

namespace WPFFlynet
{
    public class Vlucht
    {
        //  CONSTRUCTORS  //
        public Vlucht(int vluchtId, string bestemming, int aantaldagen, Vliegtuig toestel, List<Personeelslid> lPersoneel, VliegMaatschappij maatschappij)
        {
            this.VluchtID = vluchtId;
            this.Bestemming = bestemming;
            this.DuurtijdInDagen = aantaldagen;
            this.Toestel = toestel;
            this.Maatschappij = maatschappij;
            this.Personeel = lPersoneel;
        }

        //   FIELDS   //


        // ENUM + PROPERTIES //
        public int VluchtID { get; set; }
        public string Bestemming { get; set; }
        public int DuurtijdInDagen { get; set; }
        public Vliegtuig Toestel { get; set; }
        public List<Personeelslid> Personeel{ get; set; }
        public VliegMaatschappij Maatschappij { get; set; }

        // METHODS + EVENTS //
        public override string ToString()
        {
            var sb = new StringBuilder();
            
            sb.AppendLine ("ID -  bestemming   - vliegmaatschappij - toestel - duurtijd(dagen)  -     personeel     ");
            sb.Append($"{this.VluchtID}  -");
            sb.Append($"{this.Bestemming}  -");
            sb.Append($"{this.Maatschappij.VliegMaatschappijNaam.ToString()}    -");
            sb.Append($"{this.Toestel.Type.ToString()}   -");
            sb.Append($"{this.DuurtijdInDagen}         -");
            this.Personeel.ForEach(i=> sb.Append($"{i.Naam}, "));
            sb.Length -= 2;
            sb.AppendLine();
            //sb.AppendLine($"{this.Personeel.ToString()}");


            return sb.ToString();
        }
        public void VolledigeInfo()
        {
            Console.WriteLine(this.ToString()  ); 
            this.BerekenVluchtKost();
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($"vliegtuigkost per dag: {this.Toestel.BerekenTotaleKostprijsPerDag()}");
            decimal kost=0;
            this.Personeel.ForEach(i => kost += i.BerekenTotaleKostprijsPerDag());
            Console.WriteLine($"personeelkost per dag: {kost}");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Cockpitpersoneel:");
            Console.WriteLine("-----------------");
            var vlucht1cockpitp = this.Personeel.FindAll(c => c.GetType() == typeof(CockpitPersoneelslid));
            vlucht1cockpitp.ForEach(i => Console.WriteLine(i.ToString()));
            Console.WriteLine("Kabinepersoneel:");
            Console.WriteLine("-----------------");
            var vlucht1kabinep = this.Personeel.FindAll(c => c.GetType() == typeof(KabinePersoneelslid));
            vlucht1kabinep.ForEach(i => Console.WriteLine(i.ToString()));
        }

        public void BerekenVluchtKost()
        {
            decimal totaleKost = 0;
            totaleKost += this.Toestel.BerekenTotaleKostprijsPerDag();
            this.Personeel.ForEach(i => totaleKost += i.BerekenTotaleKostprijsPerDag());
            totaleKost *= this.DuurtijdInDagen;
            Console.WriteLine($"Prijs vlucht: {totaleKost}");

        }


    }
}
