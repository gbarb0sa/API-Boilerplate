using Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Web.Extension
{
    public static class EntityExtension
    {
        public static IServiceCollection AddEntityConfiguration(
            this IServiceCollection services,
            string defaultConnection)
        {
            services.AddEntityFrameworkNpgsql().AddDbContext<AppDbContext>(options =>
                options
                    .UseNpgsql(defaultConnection, options =>
                        options.MigrationsHistoryTable("__EFMigrationsHistory", "public"))
            );

            return services;
        }
    }
}