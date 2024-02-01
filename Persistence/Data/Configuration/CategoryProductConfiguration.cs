using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class CategoryProductConfiguration : IEntityTypeConfiguration<CategoryProduct>
    {
        public void Configure(EntityTypeBuilder<CategoryProduct> builder)
        {
            builder.ToTable("category_product");

            builder.Property(ci => ci.Id)
                .IsRequired();

            builder.Property(ci => ci.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(255)");
        }
    }
}