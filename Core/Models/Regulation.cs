using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Core.Models
{
    public class Regulation : BaseEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Potrebno je unesti naziv dokumenta")]
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Potrebno je unesti broj dokumenta")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Potrebno je unesti poveznicu dokumenta")]
        public string Url { get; set; }
        public string Remark { get; set; }
        public bool IsSpatialDocumentRegulation { get; set; }
        public bool IsSortedRoadRegulation { get; set; }
        public bool IsRailRoadRegulation { get; set; }
        public bool IsUnSortedRoadRegulation { get; set; }
        public bool IsWaterSupplyRegulation { get; set; }
        public bool IsDrainageRegulation { get; set; }
        public bool IsGasRegulation { get; set; }
        public bool IsOtherRegulation { get; set; }
        public string RegulationRemarks { get; set; }
        public DateTime? RegulationPublicationDate { get; set; }
        public DateTime? RegulationEffectiveDate { get; set; }
        public DateTime? DateArchived { get; set; }

        [Required(ErrorMessage = "Potrebno je odabrati kategoriju dokumenta")]
        public int RegulationTypeID { get; set; }
        public RegulationType RegulationType { get; set; }

    }
}
