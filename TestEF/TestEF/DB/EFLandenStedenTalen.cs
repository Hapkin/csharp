namespace TestEF.DB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EFLandenStedenTalen : DbContext
    {
        public EFLandenStedenTalen()
            : base("name=EFLandenStedenTalen")
        {
        }

        public virtual DbSet<Landen> Landen { get; set; }
        public virtual DbSet<Steden> Steden { get; set; }
        public virtual DbSet<Talen> Talen { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Landen>()
                .HasMany(e => e.Steden)
                .WithRequired(e => e.Land)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Landen>()
                .HasMany(e => e.Talen)
                .WithMany(e => e.Landen)
                .Map(m => m.ToTable("LandenTalen").MapLeftKey("LandCode").MapRightKey("TaalCode"));
        }
    }
}
