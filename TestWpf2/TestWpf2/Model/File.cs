using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF2.Model
{
    public class File
    {
        public File()
        {
            
        }

        private string pathValue;
        

        public string SavePath
        {
            get {
                if (pathValue != null)
                    return pathValue;
                else
                    return "Nieuwe";
            }
            set {
                pathValue = value; }
        }


        public Kaart MijnKaart { get; set; }

    }
}
