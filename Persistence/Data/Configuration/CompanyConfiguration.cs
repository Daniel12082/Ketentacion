using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("company");

            builder.Property(c => c.Id)
                .IsRequired();

            builder.Property(c => c.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(c => c.Nit)
                .HasColumnName("nit")
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(c => c.Phone)
                .HasColumnName("phone")
                .IsRequired();

            builder.Property(c => c.AddressId)
                .HasColumnName("address_id")
                .IsRequired();

            builder.HasOne(c => c.Address)
                .WithMany() // Ajusta según tus necesidades
                .HasForeignKey(c => c.AddressId)
                .OnDelete(DeleteBehavior.Restrict); // O ajusta según tus necesidades

            // builder.HasOne(c => c.User)
            //     .WithOne(u => u.Company)
            //     .HasForeignKey<Company>(c => c.User)
            //     .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
