using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taak12_CodeFirst
{

    /**
     * DB  = CFtaak12
     * 
     * */
    public class CFContext : DbContext 
    {


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*
             modelBuilder.Entity<TPHKlassikaleCursus>().Map(m => m.Requires("Soort").HasValue("K")); 
            modelBuilder.Entity<TPHZelfstudieCursus>().Map(m => m.Requires("Soort").HasValue("Z"));


            modelBuilder.Entity<TPCKlassikaleCursus>().Map(m => m.MapInheritedProperties());
            modelBuilder.Entity<TPCZelfstudieCursus>().Map(m => m.MapInheritedProperties());

            modelBuilder.Entity<ASSInstructeur>() 
                .HasMany(i => i.ASSVerantwoordelijkheden) 
                .WithMany(v => v.ASSInstructeurs) 
                .Map(c => c.ToTable("ASSInstructeursVerantwoordelijkheden") 
                .MapLeftKey("VerantwoordelijkheidID") 
                .MapRightKey("InstructeurNr")); 
                */
        }
    }
}
