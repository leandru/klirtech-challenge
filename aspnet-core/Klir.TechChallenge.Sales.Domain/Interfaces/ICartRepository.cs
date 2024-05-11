using Klir.TechChallenge.Sales.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Sales.Domain.Interfaces
{
    public interface ICartRepository
    {
        Task<bool> Exists(Guid id);    

        Task<Cart> GetAsync(Guid cartId);

        Task<Cart> CreateAsync(Cart cart);

        void Update(Cart cart);

        Task AddItemAsync( CartItem item);

        void RemoveItem ( CartItem item);

        void UpdateItem( CartItem item);

        Task CommitAsync();


    }
}
