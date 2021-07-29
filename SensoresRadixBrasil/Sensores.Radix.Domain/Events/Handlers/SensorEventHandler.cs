using MediatR;
using Sensores.Radix.Domain.Core.Interfaces.Repositories;
using Sensores.Radix.Domain.Entity;
using Sensores.Radix.Domain.Events.Repository;
using Sensores.Radix.Domain.Events.Requests;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Sensores.Radix.Domain.Events.Handlers
{
    public class SensorEventHandler : IRequestHandler<AddSensorEventRequest, SensorEvent>
    {
        private readonly ISensorEventRepository _sensorEventRepository;
        private readonly IUnitOfWork _uow;
        public SensorEventHandler(ISensorEventRepository sensorEventRepository, IUnitOfWork uow)
        {
            _sensorEventRepository = sensorEventRepository;
            _uow = uow;

        }
        public async Task<SensorEvent> Handle(AddSensorEventRequest request, CancellationToken cancellationToken)
        {
            var obj = new SensorEvent(
                request.Id,
                request.Timestamp,
                request.Valor,
                Regex.Match(request.Tag, @"\.([^.]+$)").Groups[1].Value,
                Regex.Match(request.Tag, @"([^\.]+)\.").Groups[1].Value,
                Regex.Match(request.Tag, @"\.([^\.]+)\.").Groups[1].Value);

            if (!obj.IsValid()) return await Task.FromResult(obj);

            _sensorEventRepository.Add(obj);
            if (_uow.Commit().Result)
                return await Task.FromResult(obj);

            return null;
        }
    }

}
