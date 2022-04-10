using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Core.ViewModels
{
    public class SpatialPlansDocumentLineChartVM
    {
        public List<string> SpatialPlanYear { get; set; }
        public List<int> SpatialPlansCountPerYear { get; set; }
    }
}
