using Klir.TechChallenge.Catalog.Data;
using Klir.TechChallenge.Catalog.Domain;
using Klir.TechChallenge.Sales.Data;

namespace Klir.TechChallenge.Web.API
{
    public static class ConfigExtensions
    {
        public static void UseSeedData(this WebApplication app)
        {
            var scope = app.Services.CreateScope();
            var catalogContext = scope.ServiceProvider.GetService<CatalogContext>();
            
            Product[] products = [new Product(1, "Product A", 20),
                                    new Product(2, "Product B", 4),
                                    new Product(3, "Product C", 2),
                                    new Product(4, "Product C", 4)];
            
            catalogContext?.Products.AddRange(products);
            catalogContext?.SaveChanges();

            var salesContext = scope.ServiceProvider.GetService<SalesContext>();

        }
    }
}
