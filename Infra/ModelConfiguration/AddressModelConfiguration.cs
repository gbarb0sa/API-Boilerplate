using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.ModelConfiguration
{
    public class AddressModelConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("addresses");

            builder.Property(u => u.Id).ValueGeneratedOnAdd().HasColumnName("id");

            builder.Property(x => x.Street).IsRequired().HasMaxLength(255).HasColumnName("street");
            builder.Property(x => x.City).HasMaxLength(64).HasColumnName("city");
            builder.Property(x => x.ZipCode).IsRequired().HasColumnName("zipcode");
            builder.Property(x => x.UserId).IsRequired().HasColumnName("userId");

            //Relationship
            builder.HasOne(a => a.User)
                .WithMany(u => u.Addresses)
                .HasForeignKey(a => a.UserId);
        }
    }
}
