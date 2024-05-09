using Klir.TechChallenge.Sales.Application.ViewModels;
using Klir.TechChallenge.Sales.Domain.Entities;
using Klir.TechChallenge.Sales.Domain.Interfaces;

namespace Klir.TechChallenge.Sales.Application
{
    public class CheckoutService //: ICheckoutService
    {
        private readonly IProductPromotionRepository _productPromotionRepository;

        public CheckoutService(IProductPromotionRepository productPromotionRepository)
        {
            _productPromotionRepository = productPromotionRepository;
        }

        private CartCheckoutResult CalculateTotal(Cart cart)
        {
            var total = cart.Itens.Sum( it => it.TotalItem() );

            var discount = 0m;

            foreach (var item in cart.Itens)
            {
                var itemWithDiscount = item.ProductPromotion.Promotion.GetPriceWithDiscount(item.Quantity, item.Price);
                var discountOfItem = item.TotalItem() - itemWithDiscount;

                discount += discountOfItem;
            }

            return new CartCheckoutResult(total, discount); 


        }
    }
}
