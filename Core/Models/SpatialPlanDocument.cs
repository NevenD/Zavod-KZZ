using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Core.Models
{
    public class SpatialPlanDocument : BaseEntity
    {

        public SpatialPlanDocument()
        {
            SpatialPlanAdditionalDocuments = new HashSet<SpatialPlanAdditionalDocument>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Odaberite Jedinicu lokalne samouprave")]
        public int LocalGovernmentAdministrationId { get; set; }
        [ForeignKey(nameof(LocalGovernmentAdministrationId))]
        public LocalGovernmentAdministration LocalGovernmentAdministration { get; set; }

        [Required(ErrorMessage = "Odaberite razinu Plana")]
        public int SpatialPlanLevelId { get; set; }
        [ForeignKey(nameof(SpatialPlanLevelId))]
        public SpatialPlanLevel SpatialPlanLevel { get; set; }

        [Required(ErrorMessage = "Odaberite stanje Plana")]
        public int SpatialPlanRevisionId { get; set; }
        [ForeignKey(nameof(SpatialPlanRevisionId))]
        public SpatialPlanRevision SpatialPlanRevision { get; set; }

        [Required(ErrorMessage = "Potrebno je unesti naziv Plana")]
        public string Name { get; set; }
        public string FullName { get; set; }
        public string RevisionName { get; set; }


        [Required(ErrorMessage = "Potrebno je unesti ISPU kod")]
        [StringLength(25, MinimumLength = 20, ErrorMessage = "Moguće je unesti minimalno 20, a maksimalno 25 znakova!")]
        public string IspuName { get; set; }

        [Required(ErrorMessage = "Potrebno je odabrati mjerilo Plana")]
        public int SpatialMeasureId { get; set; }
        [ForeignKey(nameof(SpatialMeasureId))]
        public SpatialMeasure SpatialMeasure { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? SpatialPlanEnactmentDate { get; set; }

        [Required(ErrorMessage = "Potrebno je odabrati Službeni Glasnik")]
        public int OfficalSpatialNewsId { get; set; }
        [ForeignKey(nameof(OfficalSpatialNewsId))]
        public OfficalSpatialNews OfficalSpatialNews { get; set; }


        [Required(ErrorMessage = "Potrebno je unesti broj Glasnika")]
        public string OfficialSpatialNewsNumber { get; set; }

        public string OfficialSpatialNewsNumberUrl { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? SpatialPlanPublicationDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? SpatialPlanEffectiveDate { get; set; }
        public string OfficialSpatialNewsRemark { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? SpatialPlanAnnouncementDevelopDate { get; set; }
        public string SpatialPlanApprovalRemark { get; set; }


        [Required(ErrorMessage = "Potrebno je odabrati izrađivača")]
        public int SpatialPlannerId { get; set; }
        [ForeignKey(nameof(SpatialPlannerId))]
        public SpatialPlanner SpatialPlanner { get; set; }

        [Required(ErrorMessage = "Potrebno je odabrati projekciju")]
        public int SpatialProjectionId { get; set; }
        [ForeignKey(nameof(SpatialProjectionId))]
        public SpatialProjection SpatialProjection { get; set; }


        [Required(ErrorMessage = "Potrebno odabrati status dostave")]
        public int SpatialPlanDeliveryId { get; set; }
        [ForeignKey(nameof(SpatialPlanDeliveryId))]
        public SpatialPlanDelivery SpatialPlanDelivery { get; set; }


        [Required(ErrorMessage = "Potrebno odabrati status dokumenta")]
        public int ConservationDocumentId { get; set; }
        [ForeignKey(nameof(ConservationDocumentId))]
        public ConservationDocument ConservationDocument { get; set; }

        [Required(ErrorMessage = "Potrebno odabrati status dokumentacije")]
        public int SpuoPuoDocumentId { get; set; }
        [ForeignKey(nameof(SpuoPuoDocumentId))]
        public SpuoPuoDocument SpuoPuoDocument { get; set; }


        [Required(ErrorMessage = "Potrebno odabrati status Plana")]
        public int SpatialPlanStatusId { get; set; }
        public SpatialPlanStatus SpatialPlanStatus { get; set; }

        public string SpatialPlanDocumentationRemark { get; set; }

        public DateTime? DateArchived { get; set; }

        public ICollection<SpatialPlanAdditionalDocument> SpatialPlanAdditionalDocuments { get; set; }

    }
}
