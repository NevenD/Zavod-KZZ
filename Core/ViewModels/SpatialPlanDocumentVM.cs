using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Core.ViewModels
{
    public class SpatialPlanDocumentVM
    {

        public SpatialPlanAdditionalDocument SpatialPlanGraphicDocument { get; set; }
        public SpatialPlanDocument SpatialPlanDocument { get; set; }
        public IEnumerable<SpatialPlanDocument> SpatialPlanDocuments { get; set; }

        public IEnumerable<LocalGovernmentAdministration> LocalGovernmentAdministrations { get; set; }
        public IEnumerable<SpatialPlanLevel> SpatialPlanLevels { get; set; }
        public IEnumerable<SpatialPlanRevision> SpatialPlanRevisions { get; set; }
        public IEnumerable<SpatialMeasure> SpatialMeasures { get; set; }
        public IEnumerable<OfficalSpatialNews> OfficalSpatialNews { get; set; }
        public IEnumerable<SpatialPlanner> SpatialPlanners { get; set; }
        public IEnumerable<SpatialProjection> SpatialProjections { get; set; }
        public IEnumerable<SpatialPlanDelivery> SpatialPlanDeliveries { get; set; }
        public IEnumerable<ConservationDocument> ConservationDocuments { get; set; }
        public IEnumerable<SpuoPuoDocument> SpuoPuoDocuments { get; set; }
        public IEnumerable<SpatialPlanStatus> SpatialPlanStatuses { get; set; }
        public List<IFormFile> Files { get; set; }
    }
}
