using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(s => s.Id);
            builder.ToTable("supplier");
            builder.Property(s => s.Id).IsRequired();
            builder.HasOne(t => t.TypeSupplier).WithMany(s => s.Suppliers).HasForeignKey(s => s.TypeSupplierId);
        }
    }
}