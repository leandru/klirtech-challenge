namespace Klir.TechChallenge.Sales.Application.Dtos
{
    public record CartCheckoutResult( IEnumerable<CartCheckoutItem> Items, decimal Total, decimal discount, decimal TotalWithDiscount);

}
