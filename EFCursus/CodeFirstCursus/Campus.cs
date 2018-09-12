using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstCursus
{
    [Table("Campussen")] // using System.ComponentModel.DataAnnotations.Schema;
    public class Campus
    {
        public int CampusId { get; set; }
        [Required]
        public string Naam { get; set; }
    }
}
