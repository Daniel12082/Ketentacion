using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("client");

            builder.Property(ci => ci.Id)
                .IsRequired();

            builder.Property(ci => ci.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(255)");
            builder.Property(ci => ci.LastName)
                .HasColumnName("last_name")
                .HasColumnType("varchar(255)");

            builder.Property(ci => ci.Document)
                .HasColumnName("identification")
                .HasColumnType("varchar(255)");

            builder.Property(ci => ci.BirthDate)
                .HasColumnName("birth_date")
                .HasColumnType("date");

            builder.Property(ci => ci.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(255)");

            builder.Property(ci => ci.Phone)
                .HasColumnName("phone")
                .HasColumnType("varchar(255)");

            builder.Property(ci => ci.Address)
                .HasColumnName("address")
                .HasColumnType("varchar(255)");
        }
    }
}