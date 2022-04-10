using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Core.ViewModels.Population
{
    public class NaturalChangeByYearVM
    {
        public int Year { get; set; }
        public int LiveBirths { get; set; }
        public int DeathBirths { get; set; }
        public int TotalBirths { get; set; }
        public int Death { get; set; }
        public int InfantDeath { get; set; }
        public int TotalDeath { get; set; }
        public int NaturalChange { get; set; }
        public decimal VitalIndex { get; set; }
    }
}
