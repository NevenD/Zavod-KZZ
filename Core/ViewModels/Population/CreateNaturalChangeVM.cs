using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Core.ViewModels.Population
{
    public class CreateNaturalChangeVM
    {
        public IEnumerable<int> Years { get; set; }
        public IEnumerable<LocalGovernmentAdministration> LocalGovernmentAdministrations { get; set; }
        public NaturalChangePopulation NaturalChangePopulation { get; set; }

        public string ErrorMsg { get; set; }
    }
}
