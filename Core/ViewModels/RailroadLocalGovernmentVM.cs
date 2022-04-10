using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Core.ViewModels
{
    public class RailroadLocalGovernmentVM
    {
        public IEnumerable<Railroad> Railroads { get; set; }

        public IEnumerable<LocalGovernmentAdministration> LocalGovernmentAdministrations { get; set; }

        public RailroadLocalGovernment RailroadLocalGovernment { get; set; }
    }
}
