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


        public DbSet<Land> Landen { get; set; }

        //verschillende types van erven
        public DbSet<TPHCursus> TPHCursussen { get; set; }
        public DbSet<TPTCursus> TPTCursussen { get; set; }
        public DbSet<TPCCursus> TPCCursussen { get; set; }


        public DbSet<ASSInstructeur> ASSInstructeurs { get; set; }
        public DbSet<ASSCampus> ASSCampussen { get; set; }
        public DbSet<ASSVerantwoordelijkheid> ASSVerantwoordelijkheden { get; set; }
        public DbSet<ASSCursist> ASSCursisten { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder) // (3)
        {
            modelBuilder.Entity<TPHKlassikaleCursus>().Map(m => m.Requires("Soort").HasValue("K")); // (4)
            modelBuilder.Entity<TPHZelfstudieCursus>().Map(m => m.Requires("Soort").HasValue("Z"));


            modelBuilder.Entity<TPCKlassikaleCursus>().Map(m => m.MapInheritedProperties());
            modelBuilder.Entity<TPCZelfstudieCursus>().Map(m => m.MapInheritedProperties());

            modelBuilder.Entity<ASSInstructeur>() // (6)
                .HasMany(i => i.ASSVerantwoordelijkheden) // (7)
                .WithMany(v => v.ASSInstructeurs ) // (8)
                .Map(c => c.ToTable("ASSInstructeursVerantwoordelijkheden") // (9)
                .MapLeftKey("VerantwoordelijkheidID") //(10)
                .MapRightKey("InstructeurNr")); //(11)
        }
    }
}
