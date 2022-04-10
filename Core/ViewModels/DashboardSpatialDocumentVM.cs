using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Core.ViewModels
{
    public class DashboardSpatialPlansTableVM
    {
        public IEnumerable<SpatialPlanDocument> SpatialPlanDocuments { get; set; }
        public IEnumerable<SpatialPlanDocument> IncompletePlans { get; set; }
        public IEnumerable<SpatialPlanAdditionalDocument> SpatialPlanAdditionalDocuments { get; set; }
        public IEnumerable<SpatialPlanDocument> Archived { get; set; }
        public IEnumerable<SpatialPlanDocument> PlansWithoutDocuments { get; set; }
        public IEnumerable<SpatialPlanDocument> SpatialPlansUndelivered { get; set; }
        public IEnumerable<SpatialPlanDocument> PlansFromActualYear { get; set; }
        public int TotalPlans { get; set; }
        public int ValidPlans { get; set; }
        public int InProgressPlans { get; set; }
        public int PlansChanged { get; set; }
        public int PlansAfter2014 { get; set; }
        public int PlansInvalid { get; set; }
 


    }
}
