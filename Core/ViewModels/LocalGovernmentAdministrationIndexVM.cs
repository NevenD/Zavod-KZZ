using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Core.ViewModels
{
    public class LocalGovernmentIndexVM
    {
        public IEnumerable<LocalGovernmentAdministration> LocalGovernmentAdministrations { get; set; }
        public IEnumerable<CommunityType> CommunityTypes { get; set; }
        public IEnumerable<LocalGovernmentAdministration> LocalGovernmentList { get; set; }
        public IEnumerable<LocalGovernmentSettlement> Settlements { get; set; }

    }
}
