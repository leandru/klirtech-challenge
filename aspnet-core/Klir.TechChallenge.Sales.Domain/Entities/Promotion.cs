using System.Collections;
using System.Collections.Generic;

namespace Klir.TechChallenge.Sales.Domain.Entities
{
    public class Promotion
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int PromotionTypeId { get; private set; }
        public int RequiredQuantity { get; private set; }
        public int? FreeQuantity { get; private set; }
        public decimal? TargetPrice { get; private set; }

        /* EF Relations */
        public virtual PromotionType PromotionType { get; private set; }

        public Promotion(int id, string name, PromotionType promotionType, int requiredQuantity, int? freeQuantity, decimal? targetPrice)
        {
            Id = id;
            Name = name;
            RequiredQuantity = requiredQuantity;
            FreeQuantity = freeQuantity;
            TargetPrice = targetPrice;

            PromotionType = promotionType;
            PromotionTypeId = promotionType.Id;
        }

        public Promotion(int id, string name, PromotionType promotionType, int requiredQuantity, decimal targetPrice):this(id, name, promotionType, requiredQuantity,null, targetPrice)
        {
        }

        public Promotion(int id, string name, PromotionType promotionType, int requiredQuantity, int freeQuantity) : this(id, name, promotionType, requiredQuantity, freeQuantity, null)
        {
        }


        public Promotion(int id, string name, int promotionTypeId, int requiredQuantity, int? freeQuantity, decimal? targetPrice)
        {
            Id = id;
            Name = name;
            RequiredQuantity = requiredQuantity;
            FreeQuantity = freeQuantity;
            TargetPrice = targetPrice;
            PromotionTypeId = promotionTypeId;
        }

        public decimal GetPriceWithDiscount(int quantity, decimal price)
        {
            return PromotionType.CalculateFinalPrice(quantity, price, RequiredQuantity, FreeQuantity, TargetPrice);
        }




    }
}
