using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ZAVOD_KZZ.Core.Models
{
    public class OfficialDocumentZara :BaseEntity
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Potrebno unesti naziv dokumenta")]
        public string Name { get; set; }
        public string ShortName { get; set; }


        [Required(ErrorMessage = "Potrebno odabrati vrstu dokumenta")]
        public int DocumentTypeZaraId { get; set; }
        public DocumentTypeZara DocumentTypeZara { get; set; }

        [Required(ErrorMessage = "Potrebno je odabrati Službeni Glasnik")]
        public int OfficalSpatialNewsId { get; set; }
        public OfficalSpatialNews OfficalSpatialNews { get; set; }

        [Required(ErrorMessage = "Potrebno je unesti broj Glasnika")]
        public string OfficialSpatialNewsNumber { get; set; }
        public string OfficialSpatialNewsNumberUrl { get; set; }

        [Required(ErrorMessage = "Potrebno je odabrati status dokumenta")]
        public int DocumentStatusZaraId { get; set; }
        public DocumentStatusZara DocumentStatusZara { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DocumentEffectiveDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DocumentIneffectiveDate { get; set; }
        public string DocumentRemark { get; set; }

        public string UniqueName => string.Format("{0}_{1}", Math.Abs(Guid.NewGuid().GetHashCode()).ToString(), Id.ToString());



    }
}
