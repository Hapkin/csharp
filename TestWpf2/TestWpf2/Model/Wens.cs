using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TestWPF2.Model
{
    public class Wens
    {
        public Wens()
        {
            this.Text = "Begintext";
            this.Size = 15;
        }
        private string textValue;
        private int sizeValue;
        private FontFamily fontValue;


        public string Text
        {
            get { return textValue; }
            set { textValue = value; }
        }
        

        public FontFamily Font
        {
            get { return fontValue; }
            set {
                fontValue = value;
            }
        }

        

        public int Size
        {
            get { return sizeValue; }
            set {
                if (value >= 10 && value <= 40)
                    sizeValue = value;
            }
        }
        

        
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Wens:");
            if(Text!=null)
                sb.AppendLine($"Text:{Text.ToString()}");
            else
                sb.AppendLine($"Text:null");
            if (Font!=null)
                sb.AppendLine($"Font:{Font.ToString()}");
            else
                sb.AppendLine($"Font:null");
            if (Size!=0)
                sb.AppendLine($"Size:{Size.ToString()}");
            else
                sb.AppendLine($"Size:null");
            return sb.ToString();
        }


    }
}
