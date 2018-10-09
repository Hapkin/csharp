namespace MVC_Tuincentrum2.DB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EFTuincentrum : DbContext
    {
        public EFTuincentrum()
            : base("name=EFTuincentrum")
        {
        }

        public virtual DbSet<Leveranciers> Leveranciers { get; set; }
        public virtual DbSet<Planten> Planten { get; set; }
        public virtual DbSet<Soorten> Soorten { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Leveranciers>()
                .HasMany(e => e.Planten)
                .WithRequired(e => e.Leveranciers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Planten>()
                .Property(e => e.VerkoopPrijs)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Soorten>()
                .HasMany(e => e.Planten)
                .WithRequired(e => e.Soorten)
                .WillCascadeOnDelete(false);
        }
    }
}
