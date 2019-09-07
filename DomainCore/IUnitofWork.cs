using System.Threading.Tasks;
using DataModel;

namespace DomainCore
{
    public interface IUnitOfWork
    {
        Task Commit();

        ApplicationContext Context { get; }
    }
}
