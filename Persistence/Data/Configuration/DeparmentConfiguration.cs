using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class DeparmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.Id);
            builder.ToTable("department");
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.HasOne(c => c.IdCountryFkNavigation).WithMany(d => d.departments).HasForeignKey(d => d.CountryId);
        }
    }
}