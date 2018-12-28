namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class VkladsDb : DbContext
    {
        public VkladsDb()
            : base("name=dbConnection")
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Vklad> Vklads { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
               .Property(e => e.FIO)
               .IsFixedLength();

            modelBuilder.Entity<Client>()
              .Property(e => e.passport)
              .IsFixedLength();


            modelBuilder.Entity<Order>()
                .HasMany(e => e.Phones)
                .WithMany(e => e.Orders)
                .Map(m => m.ToTable("VkladClient").MapLeftKey("ClientId").MapRightKey("VkladId"));

            modelBuilder.Entity<Vklad>()
                .Property(e => e.balansce)
                .IsFixedLength();
            
        }
    }
}
