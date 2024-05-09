using Klir.TechChallenge.Catalog.Domain;

namespace Klir.TechChallenge.Catalog.Application.Services
{
    public interface IProductAppService
    {
        Task<IEnumerable<Product>> GetAllAsync();
    }
}
