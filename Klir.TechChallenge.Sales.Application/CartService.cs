using Klir.TechChallenge.Sales.Application.ViewModels;
using Klir.TechChallenge.Sales.Domain.Entities;
using Klir.TechChallenge.Sales.Domain.Interfaces;

namespace Klir.TechChallenge.Sales.Application
{
    public class CartService: ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<CartCheckoutResult> CalculateTotal(Guid cartId)
        {
            var cart = await _cartRepository.GetAsync(cartId);

            if (cart is null)
                return default!;

            var listCheckoutItem = new List<CartCheckoutItem>();

            foreach (var item in cart.Items)
            {
                var finalPrice = item.ItemTotalPriceWithDiscount();
                var promotionName = item.PromotionName();

                var checkoutResultItem = new CartCheckoutItem(item.ProductId, item.ProductName, item.Quantity, item.Price, finalPrice, promotionName);
                listCheckoutItem.Add(checkoutResultItem);
            }

            var checkoutResult = new CartCheckoutResult(listCheckoutItem, cart.Total());

            return checkoutResult;
        }

        public async Task AddItem(CartItemViewModel item)
        {   
            var cart = await _cartRepository.GetAsync(item.CartId);

            if (cart is null) 
                cart = await _cartRepository.CreateAsync( new Cart( Guid.NewGuid() ) );

            if( cart.Contains(item.ProductId) ){
                cart.SetQuantity(item.ProductId, item.Quantity);
                _cartRepository.UpdateItem(cart.Items.First(it => it.ProductId == item.ProductId));
            }
            else { 
                var newItem = new CartItem(item.ProductId, item.ProductName, item.Price, item.Quantity);
                cart.AddItem(newItem);
                var addedItem = cart.Items.First(it => it.ProductId == item.ProductId);
                await _cartRepository.AddItemAsync(newItem);  
            }
            await _cartRepository.CommitAsync();
        }

        public async Task RemoveItem(CartItemViewModel item)
        {
            var cart = await _cartRepository.GetAsync(item.CartId);

            if( cart is not null)
            {
                var cartItem = cart.Items.FirstOrDefault(it => it.ProductId == item.ProductId);
                _cartRepository.RemoveItem(cartItem);
            }
        }
    }
}
