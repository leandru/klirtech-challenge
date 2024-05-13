using Klir.TechChallenge.Sales.Domain.Entities;
using Klir.TechChallenge.Sales.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Klir.TechChallenge.Sales.Data.Repositories
{
    public class ProductPromotionRepository : IProductPromotionRepository
    {
        private readonly SalesContext _salesContext;

        public ProductPromotionRepository(SalesContext salesContext)
        {
            _salesContext = salesContext;
        }

        public async Task<ProductPromotion?> GetProductPromotionAsync(int productId)
        {
            return await _salesContext.ProductsPromotions.FindAsync(productId);
        }
    }
}
