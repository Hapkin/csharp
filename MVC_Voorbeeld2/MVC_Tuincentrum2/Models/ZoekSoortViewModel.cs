using MVC_Tuincentrum2.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Tuincentrum2.Models
{
    public class ZoekSoortViewModel
    {
        [Display(Name = "Begin soortnaam:")]
        [Required(ErrorMessage = "Verplicht")]
        public string beginNaam { get; set; }
        public List<Soorten> Soorten { get; set; }
    }
}