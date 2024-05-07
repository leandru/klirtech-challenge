namespace Klir.TechChallenge.Catalog.Domain
{
    public class ThreeForTenEuroPromotion : IPromotion
    {
        public decimal Apply(decimal price, int quantity)
        {
            if (quantity < 3)
            {
                return price * quantity; 
            }

            int groupsOfThree = quantity / 3;
            int remainder = quantity % 3;

            return (groupsOfThree * 10) + (remainder * price);
        }
    }
}
