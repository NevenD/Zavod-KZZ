using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;
using ZAVOD_KZZ.Core.ViewModels.Population;
using ZAVOD_KZZ.Services.Azure.Models;

namespace ZAVOD_KZZ.Core.ViewModels
{
    public class DashboardIndexVM
    {
        public int TotalPlans { get; set; }
        public int ValidPlans { get; set; }
        public int RegulationsValidCount { get; set; }
        public int InfrastructureCount { get; set; }
        public int OfficialDocumentsZaraCount { get; set; }

        public long? DocumentsCount { get; set; }
        public double? DocumentsSize { get; set; }
        public decimal DocumentSizeProgress { get; set; }
        public IEnumerable<SpatialPlanDocument> SpatialPlanDocuments { get; set; }
        public IEnumerable<Road> Roads { get; set; }
        public IEnumerable<LocalGovernmentAdministration> LocalGovernmentAdministrations { get; set; }
        public IEnumerable<Road> LastAddedRoads { get; set; }
        public IEnumerable<Regulation> Regulations { get; set; }
        public IEnumerable<BlobInfoCustom> Blobs { get; set; }
        public IEnumerable<NaturalChangeByYearVM> NaturalChangeByYear { get; set; }

    }
}
