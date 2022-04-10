using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Core.ViewModels.Reports
{
    public class RailroadsReportVM
    {
        public IEnumerable<RailroadCategory> RailroadCategories { get; set; }
        public IEnumerable<LocalGovernmentAdministration> LocalGovernmentAdministrations { get; set; }
    }
}
