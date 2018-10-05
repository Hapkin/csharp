using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Voorbeeld3.Models
{
    public enum Geslacht
    {
        Man,
        Vrouw
    }
    public class Persoon
    {
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime InDienst { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.00}")]
        public decimal Wedde { get; set; }
        public int ID { get; set; }
        public string Voornaam { get; set; }
        [StringLength(255, ErrorMessage = "Max. {1} tekens voor {0}")]
        public string Familienaam { get; set; }
        
        [Display(Name = "Wachtwoord")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Het wachtwoord bevat min. {2}, max. {1} tekens")]
        public string Paswoord { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Verleden(ErrorMessage = "Geboortedatum moet in het verleden liggen")] // => 
        public DateTime Geboren { get; set; }
        public bool Gehuwd { get; set; }
        [DataType(DataType.MultilineText)]
        public string Opmerkingen { get; set; }
        public Geslacht Geslacht { get; set; }
        public Adres Adres { get; set; }

        [RegularExpression(@"\d{3}-\d{7}-\d{2}", ErrorMessage = "Rekeningnummer verkeerd")]
        public string rekeningNummer { get; set; }

        [Compare("Paswoord", ErrorMessage = "{0} verschilt van {1}")]
        public string HerhaalPaswoord { get; set; }

        [OnevenTussenTweeGrenzen(1, 5, ErrorMessage ="Enkel oneven scores tussen {1} en {2} !")]
        public int Score { get; set; }
    }
}