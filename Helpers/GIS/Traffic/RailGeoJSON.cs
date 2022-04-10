using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Helpers.GIS.Traffic
{
    public class RailGeoJSON
    {
        public RailCrs crs { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public List<RailFeature> features { get; set; }
    }
    public class RailFeature
    {
        public string type { get; set; }

        [JsonProperty("properties")]
        public RailProperties Properties { get; set; }
        public RailGeometry geometry { get; set; }
    }

    public class RailGeometry
    {
        [JsonProperty("coordinates")]
        public List<List<List<double>>> Coordinates { get; set; }
        public string type { get; set; }
    }


    public class RailProperties
    {

        [JsonProperty("OZNAKA")]
        public string RailCode { get; set; }

        [JsonProperty("PUNI_NAZIV")]
        public string Description { get; set; }

        [JsonProperty("SKR_NAZIV")]
        public string ShortDescription { get; set; }

        [JsonProperty("KATEGORIJA")]
        public string Category { get; set; }

        [JsonProperty("ODLUKA")]
        public string Document { get; set; }

        [JsonProperty("DULJ_NN")]
        public string OfficialLenght { get; set; }

        [JsonProperty("DULJ_KZZ")]
        public string CountyLenght { get; set; }

        [JsonProperty("KORIDOR")]
        public string Coridor { get; set; }

        [JsonProperty("NAPOMENA")]
        public string Remark { get; set; }

        

    }

    public class RailCrs
    {
        public string type { get; set; }
        public RailCrsProperties properties { get; set; }

    }

    public  class RailCrsProperties
    {
        public string name { get; set; }
    }
}
