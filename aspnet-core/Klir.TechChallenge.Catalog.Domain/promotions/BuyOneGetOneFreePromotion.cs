namespace Klir.TechChallenge.Catalog.Domain
{
    public class BuyOneGetOneFreePromotion: IPromotion
    {
        public decimal Apply(decimal price, int quantity)
        {
            int eligibleQuantity = quantity / 2 + quantity % 2;
            return eligibleQuantity * price;
        }
    }
}
