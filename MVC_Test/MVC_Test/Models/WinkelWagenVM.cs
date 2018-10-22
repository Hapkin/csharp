using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Test.DB;

namespace MVC_Test.Models
{
    public class WinkelWagenVM
    {


        public List<Film> lFilms { get; set; }
        public Klant klant { get; set; }
    }
}