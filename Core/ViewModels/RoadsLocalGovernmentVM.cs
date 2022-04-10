using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Core.ViewModels
{
    public class RoadsLocalGovernmentVM
    {
        public IEnumerable<Road> Roads { get; set; }

        public IEnumerable<LocalGovernmentAdministration> LocalGovernmentAdministrations { get; set; }

        public RoadLocalGovernment RoadLocalGovernment { get; set; }
    }
}
