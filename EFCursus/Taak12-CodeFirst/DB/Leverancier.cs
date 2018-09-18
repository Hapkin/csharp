using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taak12_CodeFirst.DB
{
    [Table("Leverancier")]
    public class Leverancier
    {
        [Key]
        public int LeverancierID { get; set; }

        public string Naam { get; set; }
        public virtual ICollection<Artikel> Artikels { get; set; } // (3)
    }
}
