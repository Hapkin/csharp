using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TestWPF2.Model
{
    public class Kleur
    {
        public Kleur()
        { }
        public SolidColorBrush Borstel { get; set; }
        public string Naam { get; set; }



        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append($"{Naam.ToString()}");
            
            return sb.ToString();
        }
    }
}
