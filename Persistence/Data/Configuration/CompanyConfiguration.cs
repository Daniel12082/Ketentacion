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
                .HasColumnType("bigint")
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(c => c.Phone)
                .HasColumnName("phone")
                .HasColumnType("varchar(20)")
                .IsRequired();
            builder.HasOne(a => a.Address).WithMany(c => c.Companies).HasForeignKey(a => a.AddressId);
        }
    }
}
