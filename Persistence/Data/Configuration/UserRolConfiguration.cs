using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class UserRolConfiguration : IEntityTypeConfiguration<UserRol>
    {
        public void Configure(EntityTypeBuilder<UserRol> builder)
        {
            builder.HasKey(ur => ur.Id);
            builder.ToTable("user_rol");
            builder.Property(ur => ur.Id).IsRequired();
            builder.HasOne(u => u.User).WithMany(ur => ur.UsersRols).HasForeignKey(ur => ur.UserId);
            builder.HasOne(r => r.Rol).WithMany(ur => ur.UsersRols).HasForeignKey(ur => ur.RolId);
        }
    }
}