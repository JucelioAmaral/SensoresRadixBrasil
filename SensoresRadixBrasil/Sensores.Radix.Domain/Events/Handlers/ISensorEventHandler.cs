using Sensores.Radix.Domain.Entity;
using Sensores.Radix.Domain.Events.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace Sensores.Radix.Domain.Events.Handlers
{
    public interface ISensorEventHandler
    {
        Task<SensorEvent> Handle(AddSensorEventRequest request, CancellationToken cancellationToken);
    }
}
