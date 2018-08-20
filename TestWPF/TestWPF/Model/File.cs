using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF.Model
{
    public class File
    {

        private string pathValue;
        

        public string Path
        {
            get {
                return pathValue;
            }
            set {
                pathValue = value; }
        }


        public Kaart MijnKaart { get; set; }

    }
}
