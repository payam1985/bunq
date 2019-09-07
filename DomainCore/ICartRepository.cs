using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel;

namespace DomainCore
{
    public interface ICartRepository
    {
        Task<Cart> GetCart(long id);

        Task<IEnumerable<Cart>> GetUserCarts(long userId);

        Task<Cart> Create(Cart cart);

        Task<Cart> Update(Cart cart);

        Task<int> Delete(long id);
    }
}
