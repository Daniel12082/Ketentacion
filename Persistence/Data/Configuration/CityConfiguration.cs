using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(ci => ci.Id);
            builder.ToTable("city");
            builder.Property(ci => ci.Id)
                .IsRequired();
            builder.Property(ci => ci.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(255)");
            builder.HasOne(d => d.Deparment).WithMany(c => c.Cities).HasForeignKey(c => c.DeparmentId);
        }
    }
}