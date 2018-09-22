using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFComboboxtest
{
    public class Genres
    {
        public Genres(int nr, string naam)
        {
            this.GenreNr = nr;
            this.Naam = naam;
        }

        public int GenreNr { get; set; }
        public string Naam { get; set; }
    }
}
