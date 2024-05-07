using Klir.TechChallenge.Catalog.Domain;
using Xunit;

namespace Klir.TechChallenge.Catalog.Tests
{
    public class BuyOneGetOneFreePromotionTests
    {
        [Theory]
        [InlineData(4, 1, 4)]  
        [InlineData(4, 2, 4)]  
        [InlineData(4, 3, 8)] 
        [InlineData(4, 4, 8)] 
        [InlineData(4, 5, 12)] 
        [InlineData(4, 6, 12)] 
        public void BuyOneGetOneFreePromotion_AppliesCorrectly(int price, int quantity, int expectedTotalPrice)
        {
            var promotion = new BuyOneGetOneFreePromotion();

            var totalPrice = promotion.Apply(price, quantity);

            Assert.Equal(expectedTotalPrice, totalPrice);
        }


    }
}
