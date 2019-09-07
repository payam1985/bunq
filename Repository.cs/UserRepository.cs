using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel;
using DomainCore;
using Microsoft.EntityFrameworkCore;

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

        public async Task<User> FindUser(long id) => await _unitOfWork.Context.Users.FindAsync(id);

        public async Task<IEnumerable<User>> GetUsers() => await _unitOfWork.Context.Users.ToListAsync();

        public async Task<User> GetUser(long id) => await _unitOfWork.Context.Users.FindAsync(id);

        public async Task<User> Update(User entity)
        {
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            await _unitOfWork.Commit();
        }

        public async Task<int> Delete(long id)
        {
            var user = await FindUser(id);
            return user == null ? 0 : await DeleteUser(user);
        }

        private async Task<int> DeleteUser(User user)
        {
            if (_unitOfWork.Context.Entry(user).State == EntityState.Detached)
                _unitOfWork.Context.Users.Attach(user);
            _unitOfWork.Context.Users.Remove(user);
            await _unitOfWork.Commit();
            return 1;
        }
    }

}
