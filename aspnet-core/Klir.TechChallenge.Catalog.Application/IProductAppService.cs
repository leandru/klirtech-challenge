using Klir.TechChallenge.Catalog.Domain;

namespace Klir.TechChallenge.Catalog.Application
{
    public interface IProductAppService
    {
        Task<IEnumerable<Product>> GetAllAsync();

        Task<Product> GetAsync(int id);
    }
}
