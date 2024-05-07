namespace Klir.TechChallenge.Catalog.Domain
{
    public class PricingCalculatorService : IPricingCalculatorService
    {
        public decimal CalculateTotal(Product product, int quantity, IPromotion promotionStrategy = null)
        {
            var price = product.Price;
            if (promotionStrategy != null)
            {
                return promotionStrategy.Apply(price, quantity);
            }
            return price * quantity;
        }
    }
}
