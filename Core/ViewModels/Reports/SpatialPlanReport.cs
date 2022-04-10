using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Core.ViewModels.Reports
{
    public class SpatialPlanReport
    {
        public int? LocalGovernmentReportId { get; set; }
        public int? SpatialPlanLevelReportId { get; set; }
        public int? MeasureSpatialReportId { get; set; }
        public int? SpatialPlannersReportId { get; set; }
        public int? PlanStatusReportId { get; set; }
        public int? YearsReportId { get; set; }
    }
}
