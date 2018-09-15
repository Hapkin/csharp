using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstCursus
{
    //[Table("TPCCursussen")]
    public abstract class TPCCursus
    {
        //public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // autonummering on
        public Guid Id { get; set; }
        public string Naam { get; set; }
    }
}
