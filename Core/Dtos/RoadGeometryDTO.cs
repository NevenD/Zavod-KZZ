using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Core.Dtos
{
    public class RoadGeometryDTO
    {
        public string CoordinatesUnprojected { get; set; }
        public string GeoJSON { get; set; }
        public string WKT { get; set; }
        public RoadDTO Road { get; set; }

    }
}
