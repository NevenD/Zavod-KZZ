using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Core.ViewModels
{
    public class RegulationsVM
    {
        public IEnumerable<Regulation> Regulations { get; set; }

        public RegulationsGraphChartVM RegulationsGraphChartVM { get; set; }

    }
}
