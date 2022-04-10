using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Core.ViewModels
{
    public class SpatialPlanDocumentDetailsVM
    {
        public SpatialPlanDocument SpatialPlanDocument { get; set; }
        public string LocalAdministrationName { get; set; }
        public string SpatialPlanLevelName { get; set; }
        public string SpatialPlanRevision { get; set; }
        public string SpatialMeasure { get; set; }
        public string OfficialSpatialNewsName { get; set; }
        public string SpatialPlannerName { get; set; }
        public string SpatialProjectionName { get; set; }
        public string SpatialPlanDeliveryName { get; set; }
        public string SpuoPuoDocumentStatus { get; set; }
        public string SpatialPlanStatusName { get; set; }
        public string ConservationName { get; set; }

        public IEnumerable<SpatialPlanAdditionalDocument> SpatialPlanAdditionalDocuments { get; set; }


    }
}
