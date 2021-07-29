using System;
using System.Collections.Generic;
using System.Text;

namespace Sensores.Radix.Application.DTOs.ReactChartJs
{
    public class Dataset
    {
        public string label { get; set; }
        public double[] data { get; set; }
        public string[] borderColor { get; set; }
        public bool fill { get; set; }

    }
}
