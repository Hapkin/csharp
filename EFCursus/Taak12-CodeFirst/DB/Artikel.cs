using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taak12_CodeFirst.DB
{
    //[Table("Artikel")]
    public abstract class Artikel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // autonummering on
        public Guid ArtikelId { get; set; }

        
        public string Naam { get; set; }

        public virtual ICollection<Leverancier> Leveranciers { get; set; } // (3)

        public int? ArtikelgroepId { get; set; }
    }
}
