using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Core.ViewModels
{
    public class RailroadsVM
    {
        public IEnumerable<Railroad> Railroads { get; set; }
        public Railroad Railroad { get; set; }
        public IEnumerable<RailroadCategory> RailroadCategories { get; set; }
        public IEnumerable<Regulation> Regulations { get; set; }
        public IEnumerable<LocalGovernmentAdministration> LocalGovernmentAdministrations { get; set; }
        public decimal TotalSum { get; set; }

        public InfrastructureGraphChartVM SortedRailroadsGraphChart { get; set; }
        public InfrastructureGraphChartVM UnSortedRailroadsGraphChart { get; set; }

    }
}
