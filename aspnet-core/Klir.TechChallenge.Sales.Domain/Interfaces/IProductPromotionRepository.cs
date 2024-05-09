using Klir.TechChallenge.Catalog.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Sales.Domain.Interfaces
{
    public interface IProductPromotionRepository
    {
        Task<IEnumerable<ProductPromotion>> GetProductPromotionAsync(int[] productId);
    }
}
