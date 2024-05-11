namespace Klir.TechChallenge.Sales.Application.Dtos
{
    public record CartViewModel( Guid Id, 
                                 IEnumerable<CartItemViewModelResult> Items,
                                 decimal Total);

}
