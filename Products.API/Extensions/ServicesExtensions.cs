using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Products.API.Database;

namespace Products.API.Extensions
{
    internal static class ServicesExtensions
    {
        internal static IServiceCollection AddDatabaseService(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ProductContext>(builder =>
            {
                builder.UseNpgsql(config.GetConnectionString("Postgres.Product.API.Database.ConnectionString"));
            });

            return services;
        }


    }
}
