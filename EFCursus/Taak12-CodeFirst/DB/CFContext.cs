using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taak12_CodeFirst.DB
{

    /**
     * DB  = CFtaak12
     * connectionString= "Server=.\SQLEXPRESS;Database=CFtaak12; Trusted_Connection=true;"
     * */
    public class CFContext : DbContext 
    {

        public DbSet<Artikelgroep> Artikelgroepen { get; set; }
        public DbSet<Artikel> Artikels { get; set; }
        public DbSet<Leverancier> Leveranciers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodArtikel>().Map(m => m.MapInheritedProperties());
            modelBuilder.Entity<NonFoodArtikel>().Map(m => m.MapInheritedProperties());



            modelBuilder.Entity<Artikel>()
                .HasMany(i => i.Leveranciers)
                .WithMany(v => v.Artikels)
                .Map(c => c.ToTable("ArtikelsPerLeveranciers")
                .MapLeftKey("ArtikelId")
                .MapRightKey("LeverancierId"));

            /*modelBuilder.Entity<Artikel>()
                .HasOptional(i => i.Artikelgroep);
              */

        }
    }
}
