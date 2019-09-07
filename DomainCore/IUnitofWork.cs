using System.Threading.Tasks;
using DataModel;

namespace DomainCore
{
    public interface IUnitOfWork
    {
        Task<int> Commit();

        ApplicationContext Context { get; }
    }
}
