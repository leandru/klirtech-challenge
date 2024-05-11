using System.Collections.Generic;

namespace Klir.TechChallenge.Sales.Domain.Entities
{
    public class ProductPromotion
    {
        public ProductPromotion(int productId, int? promotionId)
        {
            ProductId = productId;
            PromotionId = promotionId;
        }

        public int ProductId { get; set; }
        public int? PromotionId { get; set; }
        public virtual Promotion Promotion { get; set; }
    }
}
