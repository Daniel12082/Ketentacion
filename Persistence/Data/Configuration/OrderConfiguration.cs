using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable("order");
            builder.Property(o => o.Id).IsRequired();
            builder.Property(o => o. amount).IsRequired().HasColumnType("decimal(18,2)");
            builder.HasOne(m => m.PaymentMethod).WithMany(o => o.Orders).HasForeignKey(m => m.PaymentMethodId);
        }
    }
}