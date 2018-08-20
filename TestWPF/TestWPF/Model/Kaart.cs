using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace TestWPF.Model
{
    public class Kaart
    {
        public Kaart()
        {
            //this.Achtergrond = new Achtergrond();
            this.Ballen = new List<Bal>();
            this.Wens = new Wens();
        }


        public List<Bal> Ballen { get; set; }
        public Achtergrond Achtergrond { get; set; }

        public Wens Wens { get; set; }





        public override string ToString()
        {


            var sb = new StringBuilder();
            //sb.AppendLine($"Kaart:");
            sb.AppendLine($"{Achtergrond.ToString()}");
            sb.AppendLine($"{Wens.ToString()}");
            sb.AppendLine("Ballen:");
            if (Ballen != null)
                Ballen.ForEach(i => sb.AppendLine(i.ToString()));
            return sb.ToString();

        }

    }
}
