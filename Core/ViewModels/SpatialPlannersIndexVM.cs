using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Core.ViewModels
{
    public class SpatialPlannersIndexVM
    {
        public IEnumerable<SpatialPlanner> SpatialPlanners { get; set; }

        public SpatialPlannersPieChartVM PieChartData { get; set; }
  

    }
}
