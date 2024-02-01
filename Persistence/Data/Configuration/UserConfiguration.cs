using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        {
            builder.ToTable("user");

            builder.Property(p => p.Id)
            .IsRequired();

            builder.Property(p => p.Name)
            .HasColumnName("name")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(p => p.LastName)
            .HasColumnName("lastName")
            .HasColumnType("varchar")
            .HasMaxLength(60)
            .IsRequired();

            builder.Property(p => p.Phone)
            .HasColumnName("phone")
            .HasMaxLength(12)
            .IsRequired();

            builder.Property(p => p.DateEntry)
            .HasColumnName("dateEntry")
            .HasColumnType("date")
            .HasMaxLength(12)
            .IsRequired();

            builder.Property(p => p.DateDeparture)
            .HasColumnName("dateDeparture")
            .HasColumnType("date")
            .HasMaxLength(12);

            builder.Property(p => p.Username)
            .HasColumnName("username")
            .HasColumnType("varchar")
            .HasMaxLength(50);


            builder.Property(p => p.Password)
           .HasColumnName("password")
           .HasColumnType("varchar")
           .HasMaxLength(255)
           .IsRequired();

            builder.Property(p => p.Email)
            .HasColumnName("email")
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

            builder.HasOne(p => p.Address)
              .WithMany(a => a.Users)
              .HasForeignKey(u => u.IdAddress);

            builder
           .HasMany(p => p.Rols)
           .WithMany(r => r.Users)
           .UsingEntity<UserRol>(

               j => j
               .HasOne(pt => pt.Rol)
               .WithMany(t => t.UsersRols)
               .HasForeignKey(ut => ut.RolId),

               j => j
               .HasOne(et => et.User)
               .WithMany(et => et.UsersRols)
               .HasForeignKey(el => el.UserId),

               j =>
               {
                   j.ToTable("userRol");
                   j.HasKey(t => new { t.UserId, t.RolId });

               });

            builder.HasOne(p => p.Company)
              .WithOne(c => c.User)
              .HasForeignKey<User>(u => u.IdCompany);


            builder.HasMany(p => p.RefreshTokens)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);


        }

    }
}