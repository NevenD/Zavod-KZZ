using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ZAVOD_KZZ.Helpers.Enums.Enums;

namespace ZAVOD_KZZ.Helpers.GIS.Culture
{
    public class CultureGeoJSON
    {
        public Crs crs { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public List<Feature> features { get; set; }
    }

    public class Geometry
    {
        public List<List<List<List<double>>>> coordinates { get; set; }
        public string type { get; set; }
    }

    public class Feature
    {
        public string type { get; set; }
        public Properties properties { get; set; }
        public Geometry geometry { get; set; }
    }

    public class Properties
    {
        [JsonProperty("OBJECTID")]
        public int Id { get; set; }

        [JsonProperty("oznaka")]
        public string Oznaka { get; set; }

        [JsonProperty("naziv")]
        public string Naziv { get; set; }

        [JsonProperty("vrsta_kult")]
        public string VrstaKulture { get; set; }

        [JsonProperty("pravni_sta")]
        public string PravniStatus { get; set; }

        [JsonProperty("klasfikaci")]
        public string Klasifikacija { get; set; }

        [JsonProperty("UNESCO")]
        public string UNESCO { get; set; }

        [JsonProperty("mjesto")]
        public string Mjesto { get; set; }

        [JsonProperty("adresa")]
        public string Adresa { get; set; }

        [JsonProperty("JLS")]
        public string JLS { get; set; }

        [JsonProperty("vrijeme")]
        public string Vrijeme { get; set; }

        [JsonProperty("Shape_Area")]
        public decimal Area { get; set; }
    }

    public class Crs
    {
        public string type { get; set; }
        public CrsProperties properties { get; set; }

    }

    public class CrsProperties
    {
        public string name { get; set; }
    }

}
