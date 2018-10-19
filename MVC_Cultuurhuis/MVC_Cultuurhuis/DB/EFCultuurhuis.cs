namespace MVC_Cultuurhuis.DB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EFCultuurhuis : DbContext
    {
        public EFCultuurhuis()
            : base("name=EFCultuurhuis")
        {
        }

        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Klant> Klanten { get; set; }
        public virtual DbSet<Reservatie> Reservaties { get; set; }
        public virtual DbSet<Voorstelling> Voorstellingen { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                .HasMany(e => e.Voorstellingen)
                .WithRequired(e => e.Genres)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Klant>()
                .HasMany(e => e.Reservaties)
                .WithRequired(e => e.Klanten)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Voorstelling>()
                .Property(e => e.Prijs)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Voorstelling>()
                .HasMany(e => e.Reservaties)
                .WithRequired(e => e.Voorstellingen)
                .WillCascadeOnDelete(false);
        }
    }
}
