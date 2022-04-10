using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Core.ViewModels
{
    public class SpatialPlannersDetailsVM
    {

        public SpatialPlanner SpatialPlanner { get; set; }

        public IEnumerable<SpatialPlanDocument> SpatialPlanDocuments { get; set; }

    }
}
