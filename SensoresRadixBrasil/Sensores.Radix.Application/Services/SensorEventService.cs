using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Sensores.Radix.Application.DTOs;
using Sensores.Radix.Application.DTOs.ReactChartJs;
using Sensores.Radix.Application.Interfaces;
using Sensores.Radix.Domain.Events.Repository;
using Sensores.Radix.Domain.Events.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sensores.Radix.Application.Services
{
    public class SensorEventService : ISensorEventService
    {
        private readonly ISensorEventRepository _sensorEventRepository;
        public readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public SensorEventService(ISensorEventRepository sensorEventRepository, IMapper mapper, IMediator mediator)
        {
            _sensorEventRepository = sensorEventRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<SensorEventDto> AddSensorEvent(SensorEventDto sensorEventDto)
        {
            var sEvent = new AddSensorEventRequest(Guid.NewGuid(), sensorEventDto.Timestamp, sensorEventDto.Tag, sensorEventDto.Valor);
            var response = await _mediator.Send(sEvent);
            return _mapper.Map<SensorEventDto>(response);
        }
        public async Task<IEnumerable<SensorEventDto>> GetAll()
        {
            var events = await _sensorEventRepository.GetAll();
            return _mapper.Map<IEnumerable<SensorEventDto>>(events.OrderBy(x => x.Timestamp));
        }

        public async Task<DataForGraphDto> GetAllForGraph()
        {
            var data = await _sensorEventRepository.GetAllNumericsEvents();

            var labels = data.Select(x => new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(x.Timestamp).ToLocalTime().ToString("HH:mm:ss"))
                            .Select(z => z.ToString()).Distinct().ToArray();

            var random = new Random();
            var datasets = data.GroupBy(x => x.Tag)
                .Select(x => new Dataset()
                {
                    label = x.Key,
                    borderColor = new string[] { String.Format("#{0:X6}", random.Next(0x1000000)) },
                    fill = false,
                    data = data.Where(y => y.Tag == x.Key)
                            .Select(z => Convert.ToDouble(z.Valor)).ToArray()
                });

            var dataToGraph = new DataForGraphDto()
            {
                labels = labels,
                datasets = datasets
            };

            return dataToGraph;
        }
    }
}
