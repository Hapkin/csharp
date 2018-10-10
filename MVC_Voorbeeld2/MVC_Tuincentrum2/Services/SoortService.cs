using MVC_Tuincentrum2.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Tuincentrum2.Services
{
    public class SoortService
    {
        public List<Soorten> FindByBeginNaam(string beginNaam)
        {
            using (var db = new EFTuincentrum())
            {
                var query = from soort in db.Soorten
                            where soort.Soort.StartsWith(beginNaam)
                            orderby soort.Soort
                            select soort;
                var soorten = query.ToList();
                return soorten;
            }
        }
    }
}