using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Voorbeeld3.Models
{
    public class OpslagViewModel
    {
        //text voor het label bij het invulveld
        [Display(Name = "Van wedde:")]
        [Required(ErrorMessage = "Van wedde is een verplicht veld")]
        public decimal? VanWedde { get; set; }
        [Required(ErrorMessage = "Tot wedde is een verplicht veld")]
        [Display(Name = "Tot wedde:")]
        public decimal? TotWedde { get; set; }
        [Display(Name = "Percentage:")]
        [Required(ErrorMessage = "Percentage is een verplicht veld")]
        [Range(0, 100, ErrorMessage = "De minimum- en maximumwaarden voor percentage zijn :{1} en {2}")]
        public decimal? Percentage { get; set; }


    }
}