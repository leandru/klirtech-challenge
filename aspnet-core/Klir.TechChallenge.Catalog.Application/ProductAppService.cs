using Klir.TechChallenge.Catalog.Domain;

namespace Klir.TechChallenge.Catalog.Application
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductRepository _productRepository;

        public ProductAppService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }
    }
}
