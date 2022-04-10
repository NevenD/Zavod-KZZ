using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Core.ViewModels.Population
{
    public class NaturalChangeDataSetVM
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("fill")]
        public bool Fill => false;

        [JsonProperty("backgroundColor")]
        public string BackgroundColor => "#fff";

        [JsonProperty("borderColor")]
        public string BorderColor { get; set; }

        [JsonProperty("borderWidth")]
        public int BorderWidth => 1;

        [JsonProperty("pointRadius")]
        public int PointRadius => 6;

        [JsonProperty("pointHoverRadius")]
        public int PointHoverRadius => 8;

        [JsonProperty("pointBorderColor")]
        public string PointBorderColor { get; set; }

        [JsonProperty("pointBackgroundColor")]
        public string PointBackgroundColor { get; set; }

        [JsonProperty("borderDash")]
        public int[] BorderDash { get; set; }

        [JsonProperty("data")]
        public int[] Data { get; set; }
    }
}
