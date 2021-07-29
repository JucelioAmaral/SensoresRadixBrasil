using MediatR;
using Sensores.Radix.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sensores.Radix.Domain.Events.Requests
{
    public class BaseSensorEventRequest : IRequest<SensorEvent>
    {
        public Guid Id { get; set; }
        public long Timestamp { get; set; }
        public string Tag { get; set; }
        public string Valor { get; set; }
        public BaseSensorEventRequest() { }
        public BaseSensorEventRequest(Guid id, long timestamp, string tag, string valor)
        {
            Id = id;
            Timestamp = timestamp;
            Tag = tag;
            Valor = valor;
        }
    }
}
