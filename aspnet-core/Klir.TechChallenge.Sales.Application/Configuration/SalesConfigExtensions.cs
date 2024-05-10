using Klir.TechChallenge.Sales.Data;
using Klir.TechChallenge.Sales.Data.Repositories;
using Klir.TechChallenge.Sales.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Klir.TechChallenge.Sales.Application.Configuration
{
    public static class SalesConfigExtensions
    {
        public static void AddSalesServices(this IServiceCollection services)
        {

            services.AddDbContext<SalesContext>(opt => opt.UseInMemoryDatabase("SalesDB"));

            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<ICartAppService, CartAppService>();



        }
    }
}
