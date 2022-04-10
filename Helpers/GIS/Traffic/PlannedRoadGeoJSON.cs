using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Helpers.GIS.Traffic
{
    public class PlannedRoadGeoJSON
    {
        public PlannedRoadCrs crs { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public List<PlannedRoadFeature> features { get; set; }
    }

    public class PlannedRoadFeature
    {
        public string type { get; set; }

        [JsonProperty("properties")]
        public PlannedRoadProperties Properties { get; set; }
        public PlannedRoadGeometry geometry { get; set; }
    }

    public class PlannedRoadGeometry
    {

        [JsonProperty("coordinates")]
        public List<List<List<double>>> Coordinates { get; set; }
        public string type { get; set; }
    }

    public class PlannedRoadProperties
    {
        [JsonProperty("OZNAKA")]
        public string Code { get; set; }

        [JsonProperty("OPIS")]
        public string Description { get; set; }

        [JsonProperty("DULJ_PLAN")]
        public string PlannedLenght { get; set; }

        [JsonProperty("KORIDOR")]
        public string Coridor { get; set; }

        [JsonProperty("SIRINA")]
        public string Width { get; set; }

        [JsonProperty("IZVOR_PLAN")]
        public string DocumentSource { get; set; }

        [JsonProperty("NAPOMENA")]
        public string Remark { get; set; }

        [JsonProperty("KARTA")]
        public string Map { get; set; }

    }

    public class PlannedRoadCrs
    {
        public string type { get; set; }
        public PlannedRoadCrsProperties properties { get; set; }

    }

    public class PlannedRoadCrsProperties
    {
        public string name { get; set; }
    }
}
