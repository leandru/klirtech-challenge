using System.Collections.Generic;

namespace Klir.TechChallenge.Sales.Domain.Entities
{
    public class ProductPromotion
    {
        public ProductPromotion(int id, int productId, int? promotionId)
        {
            Id = id;
            ProductId = productId;
            PromotionId = promotionId;
        }

        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int? PromotionId { get; private set; }
        public virtual Promotion Promotion { get; private set; }

    }
}
