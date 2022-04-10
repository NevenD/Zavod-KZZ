using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Helpers.GIS.Traffic
{
    public class RoadGeoJSON
    {
        public RoadCrs crs { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public List<RoadFeature> features { get; set; }
    }

    public class RoadGeometry
    {
        [JsonProperty("coordinates")]
        public List<List<List<double>>> Coordinates { get; set; }
        public string type { get; set; }
    }

    public class RoadFeature
    {
        public string type { get; set; }


        [JsonProperty("properties")]
        public RoadProperties Properties { get; set; }
        public RoadGeometry geometry { get; set; }
    }

    public class RoadProperties
    {
      
        [JsonProperty("OZNAKA")]
        public string RoadCode { get; set; }

        [JsonProperty("OPIS")]
        public string Description { get; set; }

        [JsonProperty("KATEGORIJA")]
        public string Category { get; set; }

        [JsonProperty("DULJ_NN")]
        public string OfficialLenght { get; set; }

        [JsonProperty("DULJ_DOF")]
        public string DOFLenght { get; set; }

        [JsonProperty("KORIDOR")]
        public string Coridor { get; set; }

        [JsonProperty("SIRINA")]
        public string Width { get; set; }

        [JsonProperty("NAPOMENA")]
        public string Remark { get; set; }

        [JsonProperty("ODLUKA")]
        public string Document { get; set; }

    }

    public class RoadCrs
    {
        public string type { get; set; }
        public RoadCrsProperties properties { get; set; }

    }

    public class RoadCrsProperties
    {
        public string name { get; set; }
    }
}
