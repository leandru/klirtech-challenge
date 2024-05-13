using System.Collections.Generic;

namespace Klir.TechChallenge.Sales.Domain.Entities
{
    public class ProductPromotion
    {
        public ProductPromotion( int productId, int? promotionId)
        {
            ProductId = productId;
            PromotionId = promotionId;
        }

        public int ProductId { get; private set; }
        public int? PromotionId { get; private set; }
        public virtual Promotion Promotion { get; private set; }

    }
}
