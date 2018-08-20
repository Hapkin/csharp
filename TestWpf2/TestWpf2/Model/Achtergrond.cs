using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace TestWPF2.Model
{
    public class Achtergrond
    {
        public Achtergrond(string naam, BitmapImage img)
        {
            this.Naam = naam;
            this.Img = img;
        }
        private string naamValue;

        public string Naam
        {
            get { return naamValue; }
            set { naamValue = value; }
        }

        private BitmapImage imgValue;

        public BitmapImage Img
        {
            get { return imgValue; }
            set { imgValue = value; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Achtergrond: {Naam.ToString()}");
            return sb.ToString();
        }
    }
}
