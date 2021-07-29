using System.Collections.Generic;
using System.Threading.Tasks;
using Sensores.Radix.Application.DTOs;
using Sensores.Radix.Domain.Entity;

namespace Sensores.Radix.Application.Interfaces
{
    public interface ISensorEventService
    {
        Task<IEnumerable<SensorEventDto>> GetAll();
        Task<SensorEventDto> AddSensorEvent(SensorEventDto sensorEventDto);
        Task<DataForGraphDto> GetAllForGraph();

    }
}
