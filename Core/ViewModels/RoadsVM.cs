using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Core.ViewModels
{
    public class RoadsVM
    {
        public IEnumerable<Road> Roads { get; set; }
        public Road Road { get; set; }
        public IEnumerable<LocalGovernmentAdministration> LocalGovernmentAdministrations { get; set; }
        public IEnumerable<Regulation> Regulations { get; set; }
        public decimal SpatialNewslengthTotalSum { get; set; }
        public decimal DigitalOrthophotoLengthTotalSum { get; set; }
        public decimal PlannedTotalSum { get; set; }
        public decimal UnsortedTotalSum { get; set; }
        public string CoordinatesUnprojected { get; set; }
        public string GeojsonFormat { get; set; }
        public string WKTFormat { get; set; }

        public IEnumerable<RoadGeometry> RoadGeometries { get; set; }

        public InfrastructureGraphChartVM SortedRoadsGraphChart { get; set; }
        public InfrastructureGraphChartVM UnSortedRoadsGraphChart { get; set; }

        public IEnumerable<RoadCategory> RoadCategories { get; set; }
    }
}
