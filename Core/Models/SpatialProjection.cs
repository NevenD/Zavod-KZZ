using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Core.Models
{
    public class SpatialProjection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public string DescriptionOverview { get; set; }
        public string ShortName { get; set; }
        public string EpsgCode { get; set; }
        public string Description { get; set; }
    }
}
