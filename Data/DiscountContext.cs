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
        public virtual DbSet<Key> Keys { get; set; } = null!;


    }

}