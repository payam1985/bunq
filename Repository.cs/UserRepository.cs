using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel;
using DomainCore;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        

        public UserRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> Create(User user)
        {
            _unitOfWork.Context.Users.Add(user);
            await _unitOfWork.Commit();
            return user;
        }

        public async Task<User> Find(long id) => await _unitOfWork.Context.Users.FindAsync(id);

        public Task<IEnumerable<User>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(long id)
        {
            throw new NotImplementedException();
        }
    }

}
