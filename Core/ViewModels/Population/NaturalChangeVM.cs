using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Core.ViewModels.Population
{
    public class NaturalChangeVM
    {
        public LocalGovernmentAdministration LocalGovernmentAdministration { get; set; }
        public IEnumerable<NaturalChangePopulation> NaturalChangePopulation { get; set; }
        public IEnumerable<NaturalChangePopulation> NaturalChangePopulationByLocalAdministration { get; set; }
        public IEnumerable<LocalGovernmentAdministration> LocalGovernmentAdministrations { get; set; }
        public IEnumerable<NaturalChangeByYearVM> NaturalChangeByYear { get; set; }
        public NaturalChangeGraphVM NaturalChangeGraphData { get; set; }
        public IFormFile File { get; set; }
    }
}
