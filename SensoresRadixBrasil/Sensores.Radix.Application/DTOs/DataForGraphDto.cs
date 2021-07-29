using Sensores.Radix.Application.DTOs.ReactChartJs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sensores.Radix.Application.DTOs
{
    public class DataForGraphDto
    {
        public string[] labels { get; set; }
        public IEnumerable<Dataset> datasets { get; set; }
    }
}
