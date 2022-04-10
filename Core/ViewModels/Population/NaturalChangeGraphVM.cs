using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Core.ViewModels.Population
{
    public class NaturalChangeGraphVM
    {

        [JsonProperty("label")]
        public string[] Labels { get; set; }

        [JsonProperty("datasets")]
        public List<NaturalChangeDataSetVM> NaturalChangeDataSets { get; set; }

    }
}
