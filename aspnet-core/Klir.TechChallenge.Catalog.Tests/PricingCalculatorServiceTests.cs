using Klir.TechChallenge.Catalog.Domain;
using Xunit;

namespace Klir.TechChallenge.Catalog.Tests
{
    public class PricingCalculatorServiceTests
    {
        [Theory]
        [InlineData("Product A", 20, 3, 60)]   
        [InlineData("Product B", 10, 2, 20)]   
        [InlineData("Product C", 15, 4, 60)]  
        public void CalculateTotal_NoPromotion_ReturnsCorrectPrice(string productName, decimal price, int quantity, decimal expectedTotalPrice)
        {

            var productService = new PricingCalculatorService();
            var product = new Product(productName, price);

            var totalPrice = productService.CalculateTotal(product, quantity);

            Assert.Equal(expectedTotalPrice, totalPrice);
        }

        [Theory]
        [InlineData("Product A", 20, 4, 40)]    
        [InlineData("Product B", 10, 3, 20)]   
        [InlineData("Product C", 15, 6, 45)]    
        public void CalculateTotal_BuyOneGetOneFreePromotion_ReturnsCorrectPrice(string productName, decimal price, int quantity, decimal expectedTotalPrice)
        {
            var promotion = new BuyOneGetOneFreePromotion();
            var productService = new PricingCalculatorService();
            var product = new Product(productName, price);

            var totalPrice = productService.CalculateTotal(product, quantity, promotion);

            Assert.Equal(expectedTotalPrice, totalPrice);
        }


        [Theory]
        [InlineData("Product A", 5, 1, 5)]
        [InlineData("Product B", 5, 2, 10)]
        [InlineData("Product C", 5, 3, 10)]
        public void CalculateTotal_ThreeForTenEuroPromotion_ReturnsCorrectPrice(string productName, decimal price, int quantity, decimal expectedTotalPrice)
        {
            var promotion = new ThreeForTenEuroPromotion();
            var productService = new PricingCalculatorService();
            var product = new Product(productName, price);

            var totalPrice = productService.CalculateTotal(product, quantity, promotion);

            Assert.Equal(expectedTotalPrice, totalPrice);
        }
    }
}
