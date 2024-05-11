using Klir.TechChallenge.Sales.Application.Dtos;
using Klir.TechChallenge.Sales.Domain.Entities;
using Klir.TechChallenge.Sales.Domain.Interfaces;

namespace Klir.TechChallenge.Sales.Application
{
    public class CartAppService: ICartAppService
    {
        private readonly ICartRepository _cartRepository;

        public CartAppService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<bool> Exists(Guid cartId)
        {
            return await _cartRepository.Exists(cartId);
        }

        public async Task<Cart> GetAsync(Guid cartId)
        {
            return await _cartRepository.GetAsync(cartId);
        }
       
        public async Task AddItem(CartAddItemViewModel item)
        {   
            var cart = await _cartRepository.GetAsync(item.cartId);

            if (cart is null) { 
                cart = new Cart( item.cartId );
                await _cartRepository.CreateAsync(cart);
            }

            var cartItem = cart.Items.FirstOrDefault( it => it.ProductId == item.ProductId );

            if(cartItem is not null)
            {
                cart.SetQuantity(item.ProductId, cartItem.Quantity + 1);
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

        public async Task RemoveItem(CartItem item)
        {
            _cartRepository.RemoveItem(item);
            await _cartRepository.CommitAsync();
        }

        public async Task UpdateItem(CartItem item)
        {
            _cartRepository.UpdateItem(item);      
            await _cartRepository.CommitAsync();
        }

        public async Task<CartCheckoutResult> CalculateTotal(Guid cartId)
        {
            var cart = await _cartRepository.GetAsync(cartId);

            var listCheckoutItem = new List<CartCheckoutItem>();

            foreach (var item in cart.Items)
            {
                var finalPrice = item.TotalWithDiscount();
                
                var promotionApplied = item.Total() - item.TotalWithDiscount() > 0 ? item.PromotionName() : string.Empty;

                var checkoutResultItem = new CartCheckoutItem(item.ProductId, item.ProductName, item.Quantity, item.Price, finalPrice, promotionApplied);
                listCheckoutItem.Add(checkoutResultItem);
            }

            var discount = cart.Total() - cart.TotalWithDiscount();
            var checkoutResult = new CartCheckoutResult(listCheckoutItem, cart.Total(), discount, cart.TotalWithDiscount());

            return checkoutResult;
        }


    }
}
