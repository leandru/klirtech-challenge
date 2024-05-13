using Klir.TechChallenge.Sales.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Sales.Domain.Interfaces
{
    public interface IProductPromotionRepository
    {
        Task<ProductPromotion> GetProductPromotionAsync(int productId);
    }
}
