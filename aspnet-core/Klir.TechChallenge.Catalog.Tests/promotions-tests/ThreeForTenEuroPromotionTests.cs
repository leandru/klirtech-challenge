using Klir.TechChallenge.Catalog.Domain;
using Xunit;

namespace Klir.TechChallenge.Catalog.Tests.promotions_tests
{
    public class ThreeForTenEuroPromotionTests
    {
        [Theory]
        [InlineData(4, 1, 4)]
        [InlineData(4, 2, 8)]
        [InlineData(4, 3, 10)]
        [InlineData(4, 4, 14)]
        [InlineData(4, 5, 18)]
        [InlineData(4, 6, 20)]
        public void ThreeForTenEuroPromotionTests_AppliesCorrectly(int price, int quantity, int expectedTotalPrice)
        {
            var promotion = new ThreeForTenEuroPromotion();

            var totalPrice = promotion.Apply(price, quantity);

            Assert.Equal(expectedTotalPrice, totalPrice);
        }
    }
}
