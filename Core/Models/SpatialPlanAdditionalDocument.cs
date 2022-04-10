using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Core.Models
{
    public class SpatialPlanAdditionalDocument : BaseEntity
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string UniqueFileName { get; set; }
        public string FileExtension { get; set; }
        public double FileSizeInMb { get; set; }

        public int SpatialPlanDocumentId { get; set; }
        public SpatialPlanDocument SpatialPlanDocument { get; set; }
    }
}
