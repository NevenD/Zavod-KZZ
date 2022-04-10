using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Core.ViewModels
{
    public class InfrastructureStackedChartVM
    {
        public string label { get; set; }
        public string backgroundColor { get; set; }
        public decimal[] data { get; set; }
    }
}
