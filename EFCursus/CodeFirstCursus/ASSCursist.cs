using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstCursus
{
    [Table("ASSCursisten")]
    public class ASSCursist
    {
        [Key]
        public int ASSCursistId { get; set; }
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }
        public virtual ICollection<ASSCursist> Beschermelingen { get; set; } // (1)


        [InverseProperty("Beschermelingen")] // (2)
        [ForeignKey("MentorId")]
        public virtual ASSCursist Mentor { get; set; } // (3)
        public int? MentorId { get; set; }
    }
}
