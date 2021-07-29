using System;
using System.Collections.Generic;
using System.Text;

namespace Sensores.Radix.Application.DTOs
{
    public class SensorEventDto
    {
        public Guid Id { get; set; }
        public long Timestamp { get; set; }
        public string Tag { get; set; }
        public string Valor { get; set; }
    }
}
