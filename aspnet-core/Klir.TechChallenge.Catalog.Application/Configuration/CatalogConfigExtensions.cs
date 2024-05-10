using Klir.TechChallenge.Catalog.Data.Repositories;
using Klir.TechChallenge.Catalog.Data;
using Klir.TechChallenge.Catalog.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Klir.TechChallenge.Catalog.Application.Configuration
{
    public static class CatalogConfigExtensions
    {
        public static void AddCatalogServices(this IServiceCollection services)
        {
            services.AddDbContext<CatalogContext>(opt => opt.UseInMemoryDatabase("CatalogDB"));

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductAppService, ProductAppService>();

        }
    }
}
