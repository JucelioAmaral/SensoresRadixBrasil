using Sensores.Radix.Domain.Core.Interfaces.Repositories;
using Sensores.Radix.Domain.Entity;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Sensores.Radix.Domain.Events.Repository
{
    public interface ISensorEventRepository : IRepository<SensorEvent>
    {
        Task<IEnumerable<SensorEvent>> GetAllNumericsEvents();
    }
}
