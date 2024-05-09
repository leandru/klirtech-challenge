namespace Klir.TechChallenge.Sales.Domain.Entities
{
    public class BuyXGetYFreePromotionType : PromotionType
    {
  
        public BuyXGetYFreePromotionType(int id, string description) : base(id, description)
        {
        }

        public override decimal CalculateFinalPrice(int quantity, decimal price, int requiredQuantity, int? freeQuantity, decimal? targetPrice)
        {
            int fullSetsCount = quantity / (requiredQuantity + freeQuantity.Value);
            int remainingProducts = quantity % (requiredQuantity + freeQuantity.Value);

            decimal finalPrice = (fullSetsCount * requiredQuantity * price) + (remainingProducts * price);

            return finalPrice;           
        }
    }
}
