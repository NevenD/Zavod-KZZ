using System.Collections.Generic;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Core.ViewModels
{
    public class RoadsLocalGovernmentDetailsVM
    {
        public LocalGovernmentAdministration LocalGovernmentAdministration { get; set; }
        public IEnumerable<RoadLocalGovernment> RoadsLocalGovernment { get; set; }

        public IEnumerable<InfrastructureStackedChartVM> RoadsForStackedChart { get;  set; }
        public Dictionary<string,string> HighwayRoadTotal { get; set; }
        public Dictionary<string, string> SpeedRoadTotal { get; set; }
        public Dictionary<string, string> StateRoadTotal { get; set; }
        public Dictionary<string, string> CountyRoadTotal { get; set; }
        public Dictionary<string, string> LocalRoadTotal { get; set; }


        public string PlannedRoadDensity { get; set; }
      
        public string UnSortedRoadDensity { get; set; }
  
        public string LocalRoadDensity { get; set; }

        public string CountyRoadDensity { get; set; }

        public string StateRoadDensity { get; set; }

        public string SpeedRoadDensity { get; set; }

        public string HighwayRoadDensity { get; set; }

    }
}
