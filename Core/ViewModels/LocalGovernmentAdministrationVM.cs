using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Core.ViewModels
{
    public class LocalGovernmentAdministrationVM
    {
        public LocalGovernmentAdministration LocalGovernmentAdministration { get; set; }
        public IEnumerable<CommunityType> CommunityTypes { get; set; }
        public IEnumerable<LocalGovernmentSettlement> Settlements { get; set; }
        public IEnumerable<long> PopulationGraphData { get; set; } 
    }
}
