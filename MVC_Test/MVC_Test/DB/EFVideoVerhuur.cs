namespace MVC_Test.DB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using MVC_Test.DB;

    public partial class EFVideoVerhuur : DbContext
    {
        public EFVideoVerhuur()
            : base("name=EFVideoVerhuur")
        {
        }

        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Klant> Klanten { get; set; }
        public virtual DbSet<Verhuur> Verhuur { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>()
                .Property(e => e.Titel)
                .IsFixedLength();

            modelBuilder.Entity<Film>()
                .Property(e => e.Prijs)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Film>()
                .HasMany(e => e.Verhuur)
                .WithRequired(e => e.Films)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Genre>()
                .Property(e => e.GenreNaam)
                .IsUnicode(false);

            modelBuilder.Entity<Genre>()
                .HasMany(e => e.Films)
                .WithRequired(e => e.Genres)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Klant>()
                .Property(e => e.Naam)
                .IsUnicode(false);

            modelBuilder.Entity<Klant>()
                .Property(e => e.Voornaam)
                .IsUnicode(false);

            modelBuilder.Entity<Klant>()
                .Property(e => e.Straat_Nr)
                .IsUnicode(false);

            modelBuilder.Entity<Klant>()
                .Property(e => e.Gemeente)
                .IsUnicode(false);

            modelBuilder.Entity<Klant>()
                .Property(e => e.KlantStat)
                .IsUnicode(false);

            modelBuilder.Entity<Klant>()
                .HasMany(e => e.Verhuur)
                .WithRequired(e => e.Klanten)
                .WillCascadeOnDelete(false);
        }
    }
}
