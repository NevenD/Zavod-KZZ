using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Core.ViewModels
{
    public class SpatialPlannersPieChartVM
    {
        public List<string> SpatialPlannersName { get; set; }
        public List<long> SpatiaPlansCountByPlanner { get; set; }
    }
}
