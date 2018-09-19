using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taak12_CodeFirst.DB
{
    [Table("Artikelgroep")]
    public class Artikelgroep
    {
        [Key]
        public int ArtikelgroepId { get; set; }
        public string Naam { get; set; }


        public ICollection<Artikel> Artikels { get; set; }
    }
}
