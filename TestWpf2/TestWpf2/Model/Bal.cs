using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestWPF2.Model
{
    public class Bal
    {
        public Bal(Kleur kleur, double x, double y)
        {
            this.Kleur = kleur;
            this.X = x;
            this.Y = y;
            this.Tag = tagConst;
            tagConst++;

        }

        //public FrameworkElement Parent { get; set; }



        private Kleur kleurValue;
        private double locatieXValue;
        private double locatieYValue;
        private static int tagConst =0;
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
            sb.Append($"{Kleur.ToString()}|");
            sb.Append($"{X.ToString()}|{Y.ToString()}");
            //sb.Length--;
            return sb.ToString();
        }
    }
}
