using System.Threading.Tasks;

namespace Sensores.Radix.Domain.Core.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
        Task<bool> RollBack();
    }
}
