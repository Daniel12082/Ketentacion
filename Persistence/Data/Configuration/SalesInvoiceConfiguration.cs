using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class SalesInvoiceConfiguration : IEntityTypeConfiguration<SalesInvoice>
    {
        public void Configure(EntityTypeBuilder<SalesInvoice> builder)
        {
            builder.HasKey(i => i.Id);
            builder.ToTable("sales_invoice");
            builder.Property(i => i.Id).IsRequired();
            builder.HasOne(o => o.Order).WithMany(i => i.SalesInvoices).HasForeignKey(i => i.OrderId);
            builder.HasOne(e => e.Employee).WithMany(i => i.SalesInvoices).HasForeignKey(i => i.EmployeeId);

        }
    }
}