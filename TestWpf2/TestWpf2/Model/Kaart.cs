using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF2.Model
{
    public class Kaart
    {
        public Kaart()
        {
            this.Ballen = new ObservableCollection<Bal>();
            this.Wens = new Wens();
        }


        public ObservableCollection<Bal> Ballen { get; set; }
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
            {
                foreach (var i in Ballen)
                {
                    sb.AppendLine(i.ToString());
                }
                sb.Length--;
            }
            return sb.ToString();

        }

    }
}
