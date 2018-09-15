using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TestWPF.Model
{
    public class Kleur
    {
        public Kleur()
        { }
        public SolidColorBrush Borstel { get; set; }
        public string Naam { get; set; }
        public string Hex { get; set; }
        public byte Rood { get; set; }
        public byte Groen { get; set; }
        public byte Blauw { get; set; }


        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Kleur: {Naam.ToString()}");
            return sb.ToString();
        }
    }
}
