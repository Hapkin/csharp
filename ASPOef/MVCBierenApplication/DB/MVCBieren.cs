namespace MVCBierenApplication.DB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;


    public partial class MVCBieren : DbContext
    {
        public MVCBieren()
            : base("name=MVCBieren")
        {
        }

        public virtual DbSet<Bier> Bieren { get; set; }
        public virtual DbSet<Brouwer> Brouwers { get; set; }
        public virtual DbSet<Soort> Soorten { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brouwer>()
                .HasMany(e => e.Bieren)
                .WithRequired(e => e.Brouwers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Soort>()
                .HasMany(e => e.Bieren)
                .WithRequired(e => e.Soorten)
                .WillCascadeOnDelete(false);
        }
    }
}
