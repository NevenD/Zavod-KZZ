using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Core.ViewModels
{
    public class SpatialPlanDocumentViewVM
    {
        public IEnumerable<LocalGovernmentAdministration> LocalGovernmentAdministrations { get; set; }
        public IEnumerable<SpatialPlanDocument> SpatialPlanDocuments { get; set; }
        public IEnumerable<Regulation> Regulations { get; set; }
    }
}
