using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstCursus
{
    [Table("ASSCampussen")] // using System.ComponentModel.DataAnnotations.Schema;
    public class ASSCampus
    {
        public int ASSCampusId { get; set; } // (2)
        [Required] // using System.ComponentModel.DataAnnotations;
        [StringLength(50)]
        public string Naam { get; set; }
        public Adres Adres { get; set; }

        public virtual ICollection<ASSInstructeur> ASSInstructeurs { get; set; } // (3)

    }
}

