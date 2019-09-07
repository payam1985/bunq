using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DomainCore
{
    public interface IUserRepository
    {
        Task<User> Create(User user);

        Task<User> Find(long id);

        Task<IEnumerable<User>> GetUsers();

        Task<User> Update(User entity);

        Task<int> Delete(long id);
    }
}
