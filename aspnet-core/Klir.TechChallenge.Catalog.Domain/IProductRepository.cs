using System.Collections.Generic;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Catalog.Domain
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();

        Task<Product> GetByIdAsync(int id);
    }
}
