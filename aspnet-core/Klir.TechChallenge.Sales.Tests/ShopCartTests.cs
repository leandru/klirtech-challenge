using Klir.TechChallenge.Sales.Domain.Entities;

namespace Klir.TechChallenge.Sales.Tests
{
    public class ShopCartTests
    {
        private Cart _cart;

        public ShopCartTests()
        {
            _cart = new Cart( Guid.NewGuid() );
        }

        [Fact]
        public void AddItem_AddsItemToCart_WhenItemDoesNotExist()
        {
            var itemToAdd = new CartItem(productId: 1, productName: "Product A", 10, 1, 1);

            _cart.AddItem(itemToAdd);

            Assert.Contains(itemToAdd, _cart.Items);
        }

        [Fact]
        public void RemoveItem_RemovesItemFromCart()
        {
            var item1 = new CartItem( productId: 1, productName: "Product A", 10, 1, 1);
            var item2= new CartItem( productId: 2, productName: "Product B", 10, 1, 2);
            _cart.AddItem(item1);

            _cart.AddItem(item2);

            _cart.RemoveItem(item1);

            Assert.Equal(1, _cart.Items.Count);
            
        }
    }
}
