using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFComboboxtest
{
    public class Films
    {

        public Films(int nr , string naam, Genres genre)
        {
            FilmNr = nr;
            Naam = naam;
            Genre = genre;
        }
        public int FilmNr { get; set; }
        public string Naam { get; set; }
        public Genres Genre { get; set; }

    }
}
