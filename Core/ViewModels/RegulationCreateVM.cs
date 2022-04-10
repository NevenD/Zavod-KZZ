using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Core.ViewModels
{
    public class RegulationCreateVM
    {
        public IEnumerable<RegulationType> RegulationTypes { get; set; }

        public Regulation Regulation { get; set; }

    }
}
