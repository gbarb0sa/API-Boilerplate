using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.ModelConfiguration
{
    public class InformationModelConfiguration : IEntityTypeConfiguration<Information>
    {
        public void Configure(EntityTypeBuilder<Information> builder)
        {
            builder.ToTable("informations");

            builder.Property(u => u.Id).ValueGeneratedOnAdd().HasColumnName("id");

            builder.Property(x => x.Bio).IsRequired().HasMaxLength(255).HasColumnName("bio");
            builder.Property(x => x.Website).HasMaxLength(255).HasColumnName("website");
            builder.Property(x => x.UserId).HasColumnName("userId");
        }
    }
}
