using Core.Entities;
using Infra.ModelConfiguration;
using Microsoft.EntityFrameworkCore;


namespace Infra
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
          : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Information> Informations { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("public");

            builder.ApplyConfiguration(new UserModelConfiguration());
            builder.ApplyConfiguration(new AddressModelConfiguration());
            builder.ApplyConfiguration(new InformationModelConfiguration());
            builder.ApplyConfiguration(new RoleModelConfiguration());
            builder.ApplyConfiguration(new UserRoleModelConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

    }
}
