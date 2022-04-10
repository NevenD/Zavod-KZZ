using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models.ManyToMany;


namespace ZAVOD_KZZ.Core.Models
{
    public class LocalGovernmentSettlement
    {
        public LocalGovernmentSettlement()
        {
            SettlementLocalGovernments = new HashSet<SettlementLocalGovernment>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public int CodeNumber { get; set; }

        public int LocalGovernmentAdministrationID { get; set; }

        [ForeignKey(nameof(LocalGovernmentAdministrationID))]
        public LocalGovernmentAdministration LocalGovernmentAdministrations { get; set; }

        public ICollection<SettlementLocalGovernment> SettlementLocalGovernments { get; set; }
    }
}
