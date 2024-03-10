using System;
using Entity.Concrete;
using Entity.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Contexts
{
	public class AbcContext : DbContext
	{
        public AbcContext(DbContextOptions<AbcContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());

            modelBuilder.HasSequence<int>("product_hilo")
            .StartsAt(100).IncrementsBy(1);
        }
    }
}

