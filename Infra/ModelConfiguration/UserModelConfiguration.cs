using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infra.ModelConfiguration
{
    public class UserModelConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.Property(u => u.Id).ValueGeneratedOnAdd().HasColumnName("id");

            builder.Property(x => x.Name).IsRequired().HasMaxLength(255).HasColumnName("name");
            builder.Property(x => x.Email).HasMaxLength(64).HasColumnName("email");
            builder.Property(x => x.Gender).IsRequired().HasColumnName("gender");
        }
    }
}
