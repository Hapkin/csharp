using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstCursus
{
    [Table("ASSInstructeurs")] // using System.ComponentModel.DataAnnotations.Schema;
    public class ASSInstructeur
    {
        //public int Id { get; set; }
        [Key] // using System.ComponentModel.DataAnnotations;
        public int InstructeurNr { get; set; }
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }
        [Column("maandwedde")] // using System.ComponentModel.DataAnnotations.Schema;
        public decimal Wedde { get; set; }
        [Column(TypeName = "date")]
        public DateTime InDienst { get; set; }
        public bool? HeeftRijbewijs { get; set; }
        //public bool HeeftRijbewijs { get; set; }
        public Adres Adres { get; set; }


        // -----------
        // Associaties
        // -----------
        public virtual ASSCampus Campus { get; set; } // (1)
        public int ASSCampusId { get; set; } // (2)
        public virtual ICollection<ASSVerantwoordelijkheid> ASSVerantwoordelijkheden { get; set; } // using System.Collections.Generic;



        public void Opslag(decimal percentage)
        {
            Wedde *= (1M + percentage / 100M);
        }
    }
}
