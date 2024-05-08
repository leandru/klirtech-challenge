using Klir.TechChallenge.Sales.Domain.Entities;
using Xunit;

namespace Klir.TechChallenge.Sales.Tests
{
    public class PromotionTests
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
            var promotionType = new BuyXGetYFreePromotionType(1, "Buy X Quantity and Get N Free");

            var promotion = new Promotion(1, "Buy 1 Get 1 Free", promotionType, 1, 1);

            var totalPrice = promotion.GetFinalPrice(quantity, price);

            Assert.Equal(expectedTotalPrice, totalPrice);
        }

        [Theory]
        [InlineData(10, 1, 10)]
        [InlineData(10, 2, 20)]
        [InlineData(10, 3, 20)]
        [InlineData(10, 4, 30)]
        [InlineData(10, 5, 40)]
        [InlineData(10, 6, 40)]
        public void BuyTwoGetOneFreePromotion_AppliesCorrectly(int price, int quantity, int expectedTotalPrice)
        {
            var promotionType = new BuyXGetYFreePromotionType(1, "Buy X Quantity and Get N Free");

            var promotion = new Promotion(1, "Buy 2 Get 1 Free", promotionType, 2, 1);

            var totalPrice = promotion.GetFinalPrice(quantity, price);

            Assert.Equal(expectedTotalPrice, totalPrice);
        }

        [Theory]
        [InlineData(4, 1, 4)]
        [InlineData(4, 2, 8)]
        [InlineData(4, 3, 10)]
        [InlineData(4, 4, 14)]
        [InlineData(4, 5, 18)]
        [InlineData(4, 6, 20)]
        public void BuyThreeForTenPromotionTests_AppliesCorrectly(int price, int quantity, int expectedTotalPrice)
        {
            var promotionType = new BuyXGetYPricePromotionType(2, "Buy X Quantity and Get N Price");

            var promotion = new Promotion(1, "Buy 3 for 10 Euro ", promotionType, 3, 10m);

            var totalPrice = promotion.GetFinalPrice(quantity, price);

            Assert.Equal(expectedTotalPrice, totalPrice);
        }

        [Theory]
        [InlineData(8, 1, 8)]
        [InlineData(8, 2, 16)]
        [InlineData(8, 3, 20)]
        [InlineData(8, 4, 28)]
        [InlineData(8, 5, 36)]
        [InlineData(8, 6, 40)]
        public void BuyThreeForTwentyPromotionTests_AppliesCorrectly(int price, int quantity, int expectedTotalPrice)
        {
            var promotionType = new BuyXGetYPricePromotionType(2, "Buy X Quantity and Get N Price");

            var promotion = new Promotion(1, "Buy 3 for 20 Euro ", promotionType, 3, 20m);

            var totalPrice = promotion.GetFinalPrice(quantity, price);

            Assert.Equal(expectedTotalPrice, totalPrice);
        }

    }
}
