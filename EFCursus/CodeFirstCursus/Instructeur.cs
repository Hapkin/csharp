using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstCursus
{
    public class Instructeur // (1)
    {
        //public int Id { get; set; }
        [Key] // using System.ComponentModel.DataAnnotations;
        public int InstructeurNr { get; set; }
        public string Voornaam { get; set; } // (3)
        public string Familienaam { get; set; }
        [Column("maandwedde")]
        public decimal Wedde { get; set; }

        [Column(TypeName = "date")]
        public DateTime InDienst { get; set; }
        
        //EEN KOLOM INSTELLEN ALS NIET VERPLICHT IN TE VULLEN
        public bool? HeeftRijbewijs { get; set; }
        //public bool HeeftRijbewijs { get; set; }  
        public Adres Adres { get; set; }

        public void Opslag(decimal percentage)
        {
            Wedde *= (1M + percentage / 100M);
        }
    }
}
