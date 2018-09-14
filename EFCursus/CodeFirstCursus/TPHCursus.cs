using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstCursus
{
    [Table("TPHCursussen")]
    public abstract class TPHCursus
    {
        public int Id { get; set; }
        public string Naam { get; set; }
    }
}
