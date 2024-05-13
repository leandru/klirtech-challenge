using Klir.TechChallenge.Catalog.Data;
using Klir.TechChallenge.Catalog.Domain;
using Klir.TechChallenge.Sales.Data;
using Klir.TechChallenge.Sales.Domain.Entities;

namespace Klir.TechChallenge.Web.API
{
    public static class ConfigExtensions
    {
        public static void UseSeededData(this WebApplication app)
        {
            var scope = app.Services.CreateScope();
            var catalogContext = scope.ServiceProvider.GetService<CatalogContext>();
            
            Product[] products = [new Product(1, "Product A", 20),
                                    new Product(2, "Product B", 4),
                                    new Product(3, "Product C", 2),
                                    new Product(4, "Product D", 4)];
            
            catalogContext?.Products.AddRange(products);
            catalogContext?.SaveChanges();

            var salesContext = scope.ServiceProvider.GetService<SalesContext>();

            var promotionType1 = new BuyXGetYFreePromotionType(1, "BuyXGetYFree");
            var promotionType2 = new BuyXGetYPricePromotionType(2, "BuyXGetYPrice");
            PromotionType[] promotionsTypes = [promotionType1, promotionType2];

            var promotion = new Promotion(1, "Buy 1 Get 1 Free", promotionType1, 1, 1);
            var promotion2 = new Promotion(2, "3 for 10 Euro", promotionType2, 3, 10m);
            Promotion[] promotions = [promotion, promotion2];

            ProductPromotion[] productPromotions = [new ProductPromotion(1,1, 1), new ProductPromotion(2,2, 2), new ProductPromotion(3,4, 2)];

            salesContext?.PromotionTypes.AddRange(promotionsTypes);

            salesContext?.Promotion.AddRange(promotions);

            salesContext?.ProductsPromotions.AddRange(productPromotions);

            salesContext?.SaveChanges();

        }
    }
}
