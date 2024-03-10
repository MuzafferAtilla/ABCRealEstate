using System;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Entity.EntityTypeConfigurations
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(m => m.ProductId);

            builder.Property(m => m.ProductId)
                    .HasColumnType("int")
                    .IsRequired()
                    .UseHiLo("product_hilo");

            builder.Property(m => m.ProductName)
                    .HasColumnType("varchar(100)");

            builder.Property(m => m.Description)
                    .HasColumnType("varchar(100)");

            builder.Property(m => m.Price)
                    .HasColumnType("decimal(5,2)");

            builder.Property(m => m.ProductAge)
                    .HasColumnType("int");

            builder.Property(m => m.RoomType)
                    .HasColumnType("varchar(10)");

            builder.Property(m => m.SaleType)
                    .HasColumnType("varchar(20)");

            builder.Property(m => m.ProductArea)
                    .HasColumnType("int");
             
        }
    }
}

