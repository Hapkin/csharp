using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestWPF.Model;

namespace TestWPF.Model
{
    public class Bal: IMovable
    {
        public Bal(Kleur kleur, int x, int y)
        {
            this.Kleur = kleur;
            this.X = x;
            this.Y = y;
            this.Tag = tagConst;
            
        }

        public FrameworkElement Parent { get; set; }



        private Kleur kleurValue;
        private double locatieXValue;
        private double locatieYValue;
        private int tagConst;
        private int tagValue;

        public Kleur Kleur
        {
            get { return kleurValue; }
            set { kleurValue = value; }
        }




        public int Tag
        {
            get { return tagValue; }
            private set {
                tagValue = value;
                tagConst = tagConst++;
            }
        }
        public double X
        {
            get { return locatieXValue; }
            set { locatieXValue = value; }
        }

        public double Y
        {
            get { return locatieYValue; }
            set { locatieYValue = value; }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Bal:");
            sb.AppendLine($"{Kleur.ToString()}");
            sb.AppendLine($"{Tag.ToString()}");
            sb.AppendLine($"{X.ToString()} || {Y.ToString()}");
            return sb.ToString();
        }
    }
}
