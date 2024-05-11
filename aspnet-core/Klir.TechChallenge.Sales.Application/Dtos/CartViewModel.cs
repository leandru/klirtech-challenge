namespace Klir.TechChallenge.Sales.Application.Dtos
{
    public class CartViewModel
    {
        public IEnumerable<CartItemViewModel> Items { get; set; } = Enumerable.Empty<CartItemViewModel>();
    }
}
