using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("invoice");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Property(i => i.Date).IsRequired().HasColumnType("date");
            builder.HasOne(O => O.Order).WithMany(I => I.Invoices).HasForeignKey(I => I.OrderId);
            builder.HasOne(s => s.Supplier).WithMany(i => i.Invoices).HasForeignKey(i => i.SupplierId);
        }
    }
}