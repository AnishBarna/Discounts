using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Discount.Models;

namespace Discount.Data
{
    public partial class DiscountContext : DbContext
    {
        public DiscountContext()
        {
        }

        public DiscountContext(DbContextOptions<DiscountContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductCity> ProductCities { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server = localhost ; Port = 5432 ; Database = Discounts ; User Id = postgres ; Password = root ;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.CityId).ValueGeneratedNever();

                entity.Property(e => e.CityName)
                    .HasColumnType("character varying")
                    .HasColumnName("CityName");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.DiscountedProductId)
                    .HasName("Product_pkey");

                entity.ToTable("Product");

                entity.Property(e => e.ProductId).ValueGeneratedOnAdd();

                entity.Property(e => e.ProductName).HasMaxLength(50);
            });

            modelBuilder.Entity<ProductCity>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Product_City");

                entity.Property(e => e.CityCityId).HasColumnName("City_CityId");

                entity.Property(e => e.ProductDiscountedProductId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Product_DiscountedProductId");

                entity.HasOne(d => d.CityCity)
                    .WithMany()
                    .HasForeignKey(d => d.CityCityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Product_City_City_CityId_fkey");

                entity.HasOne(d => d.ProductDiscountedProduct)
                    .WithMany()
                    .HasForeignKey(d => d.ProductDiscountedProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Product_City_Product_DiscountedProductId_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
