using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Test.DB;

namespace MVC_Test.Models
{
    public class VerhurenVM
    {
        public Genre hetGenre { get; set; }
        public List<Genre> lGenres { get; set; }
        public List<Film> lFilms { get; set; }
    }
}