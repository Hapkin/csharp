using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Test.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Zonder naam kan je niet inloggen.")]
        [StringLength(50, ErrorMessage = "Je {0} moet minstens {2} tekens lang zijn.", MinimumLength = 2)]
        public string Naam { get; set; }


        [Required(ErrorMessage = "Zonder postcode kunnen we je niet identificeren.")]
        [Range(1000, 9999, ErrorMessage = "Postcode moet tussen {1} en {2} liggen.")]
        public int Postcode { get; set; }
    }
}