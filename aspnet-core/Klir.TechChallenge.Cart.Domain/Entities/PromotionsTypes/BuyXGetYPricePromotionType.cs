namespace Klir.TechChallenge.Sales.Domain.Entities
{
    public class BuyXGetYPricePromotionType : PromotionType
    {
        public BuyXGetYPricePromotionType(int id, string description) : base(id, description)
        {
        }


        public override decimal CalculateFinalPrice(int quantity, decimal price, int requiredQuantity, int? freeQuantity, decimal? targetPrice)
        {
            if (quantity < requiredQuantity)
            {
                return price * quantity;
            }

            int groupsOfRequiredQuantity = quantity / requiredQuantity;
            int remainder = quantity % requiredQuantity;

            return groupsOfRequiredQuantity * targetPrice.Value + remainder * price;
        }
    }
}
