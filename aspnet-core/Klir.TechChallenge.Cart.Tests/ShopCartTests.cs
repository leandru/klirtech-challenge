using Klir.TechChallenge.Sales.Domain;
using Klir.TechChallenge.Sales.Domain.Entities;
using Xunit;

namespace Klir.TechChallenge.Cart.Tests
{
    public class ShopCartTests
    {
        private ShopCart _cart;

        public ShopCartTests()
        {
            _cart = new ShopCart();
        }

        [Fact]
        public void AddItem_AddsItemToCart_WhenItemDoesNotExist()
        {
            var itemToAdd = new ShopCartItem { ProductId = 1, Quantity = 1 };

            _cart.AddItem(itemToAdd);

            Assert.Contains(itemToAdd, _cart.Itens);
        }

        [Fact]
        public void AddItem_IncrementsQuantity_WhenItemExists()
        {

            var existingItem = new ShopCartItem { ProductId = 1, Quantity = 1 };
            _cart.AddItem(existingItem);
            var itemToAdd = new ShopCartItem { ProductId = 1, Quantity = 1 };

            _cart.AddItem(itemToAdd);

            Assert.Equal(2, existingItem.Quantity);
        }

        [Fact]
        public void RemoveItem_RemovesItemFromCart()
        {
            var item1 = new ShopCartItem { ProductId = 2, Quantity = 3 };
            var item2= new ShopCartItem { ProductId = 1, Quantity = 1 };
            _cart.AddItem(item1);

            _cart.AddItem(item2);

            _cart.RemoveItem(item1);

            Assert.Equal(1, _cart.Itens.Count);
        }
    }
}
