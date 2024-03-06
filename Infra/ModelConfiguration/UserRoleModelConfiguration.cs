using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.ModelConfiguration
{
    public class UserRoleModelConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("user_roles");

            builder.HasKey(ur => new { ur.UserId, ur.RoleId });

            builder.Property(x => x.RoleId).HasColumnName("roleId");
            builder.Property(x => x.UserId).HasColumnName("userId");

            //Relationship
            builder.HasOne(ur => ur.User)
                .WithMany(u => u.Roles)
                .HasForeignKey(ur => ur.UserId);

            builder.HasOne(ur => ur.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(ur => ur.RoleId);
        }
    }
}
