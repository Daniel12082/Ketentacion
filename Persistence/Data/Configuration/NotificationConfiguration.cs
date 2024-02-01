using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;  

namespace Persistence.Data.Configuration
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(n => n.Id);
            builder.ToTable("notification");
            builder.Property(n => n.Id).ValueGeneratedOnAdd();
            builder.Property(n => n.Message).IsRequired();
            builder.Property(n => n.Description).IsRequired().HasColumnType("VarChar(255)");
        }
    }
}