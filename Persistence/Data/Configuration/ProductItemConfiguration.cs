using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ProductItemConfiguration : IEntityTypeConfiguration<ProductItem>
    {
        public void Configure(EntityTypeBuilder<ProductItem> builder)
        {
            builder.HasKey(e => e.Id);
            builder.ToTable("product_item");
            builder.Property(e => e.Id).IsRequired();
            builder.Property(q => q.QuantityItem).IsRequired().HasColumnType("int");
            builder.HasOne(p => p.Product).WithMany(p => p.ProductItems).HasForeignKey(p => p.ProductId);
        }
    }
}