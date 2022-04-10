using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Core.Models
{
    public class RoadGeometry : BaseEntity 
    {
        public int Id { get; set; }

        /// <value>Koordinate pohranjane kao EPSG:4326 (npr. 17.45, 46.17)</value>
        public string CoordinatesUnprojected { get; set; }
        public string GeoJSON { get; set; }
        public string WKT { get; set; }
        public int RoadID { get; set; }
        public Road Road { get; set; }
    }
}
