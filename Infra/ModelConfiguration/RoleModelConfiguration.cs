using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.ModelConfiguration
{
    public class RoleModelConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("roles");

            builder.Property(u => u.Id).ValueGeneratedOnAdd().HasColumnName("id");

            builder.Property(x => x.Name).IsRequired().HasMaxLength(255).HasColumnName("name");

        }
    }
}
