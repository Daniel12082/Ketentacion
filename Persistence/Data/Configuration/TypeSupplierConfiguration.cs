using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class TypeSupplierConfiguration : IEntityTypeConfiguration<TypeSupplier>
    {
        public void Configure(EntityTypeBuilder<TypeSupplier> builder)
        {
            builder.HasKey(ts => ts.Id);
            builder.ToTable("type_supplier");
            builder.Property(ts => ts.Id).IsRequired();
            
        }
    }
}