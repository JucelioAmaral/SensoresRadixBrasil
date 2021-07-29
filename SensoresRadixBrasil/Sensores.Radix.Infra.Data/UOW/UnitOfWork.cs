using Sensores.Radix.Domain.Core.Interfaces.Repositories;
using Sensores.Radix.Infra.Data.DbContexts;
using System.Threading.Tasks;

namespace Sensores.Radix.Infra.Data.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SensorEventContext _DBContext;
        public UnitOfWork(SensorEventContext DBContext)
        {
            _DBContext = DBContext;
        }
        public async Task<bool> Commit()
        {
            return await _DBContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> RollBack()
        {
            //deixar o garbage colector remover a 
            return await Task.FromResult(true);
        }
    }
}
