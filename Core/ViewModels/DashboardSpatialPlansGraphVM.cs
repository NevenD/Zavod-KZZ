using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Core.ViewModels
{
    public class DashboardSpatialPlansGraphVM
    {
        public SpatialPlansLevelChartVM SpatialPlansLevelChartVM { get; set; }
        public SpatialPlansLocalAdministrationChartVM SpatialPlansLocalAdministrationChartVM { get; set; }
        public SpatialPlansDocumentLineChartVM PlansPerYearLineChart { get; set; }

    }
}
