using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstCursus
{
    class EFCFContext : DbContext // (1)
    {
        public DbSet<Instructeur> Instructeurs { get; set; } // (2)
        public DbSet<Campus> Campussen { get; set; }
    }
}
