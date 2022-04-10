using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Core.ViewModels
{
    public class RailroadsLocalGovernmentDetailsVM
    {
        public LocalGovernmentAdministration LocalGovernmentAdministration { get; set; }
        public IEnumerable<RailroadLocalGovernment> RailroadsLocalGovernment { get; set; }

        public IEnumerable<InfrastructureStackedChartVM> RailroadsForStackedChart { get; set; }
        public Dictionary<string, string> LocalRailroadTotal { get; set; }
        public Dictionary<string, string> RegionalRailroadTotal { get; set; }
 
        public string PlannedRailroadDensity { get; set; }

        public string LocalRailroadDensity { get; set; }

        public string RegionalRailroadDensity { get; set; }


    }
}
