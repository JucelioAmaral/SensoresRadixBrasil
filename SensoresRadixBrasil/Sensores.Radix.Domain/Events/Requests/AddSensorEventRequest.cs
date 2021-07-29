using System;
using System.Collections.Generic;
using System.Text;

namespace Sensores.Radix.Domain.Events.Requests
{
    public class AddSensorEventRequest : BaseSensorEventRequest
    {
        public AddSensorEventRequest(Guid id, long timestamp, string tag, string valor)
        {
            Id = id;
            Timestamp = timestamp;
            Tag = tag;
            Valor = valor;
        }
    }
}
