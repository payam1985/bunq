using System.Threading.Tasks;
using DataModel;
using DomainCore;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }


        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public ApplicationContext Context => _context ?? 
                    new ApplicationContext(new DbContextOptions<ApplicationContext>());
    }
}
