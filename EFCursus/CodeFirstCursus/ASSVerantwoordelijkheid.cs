using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstCursus
{
    [Table("ASSVerantwoordelijkheden")]
    public class ASSVerantwoordelijkheid
    {
        public int ASSVerantwoordelijkheidId { get; set; }
        public string Naam { get; set; }
        public virtual ICollection<ASSInstructeur> ASSInstructeurs { get; set; }

        
    }
}
