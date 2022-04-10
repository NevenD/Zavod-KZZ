using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Core.Dtos
{
    public class RoadDTO
    {
        public RoadCategoryDTO RoadCategory { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal? DigitalOrthophotoLength { get; set; }
        public decimal SpatialNewslength { get; set; }
        public DateTime? ReconstructionDate { get; set; }
        public string ReconstructionDescription { get; set; }
    }
}
