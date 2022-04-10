using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Core.Models.ManyToMany
{
    public class SettlementLocalGovernment
    {
        public int Id { get; set; }

        public int SettlementID { get; set; }
        public LocalGovernmentSettlement Settlement { get; set; }

        public int LocalGovernmentAdministrationID { get; set; }
        public LocalGovernmentAdministration LocalGovernment { get; set; }
    }
}
