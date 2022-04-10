using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Core.Models
{
    public class RailroadLocalGovernment : BaseEntity
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Potrebno je odabrati jedinicu lokalne samouprave")]
        public int LocalGovernmentAdministrationID { get; set; }
        public LocalGovernmentAdministration LocalGovernmentAdministration { get; set; }

        [Required(ErrorMessage = "Potrebno je odabrati željeznicu")]
        public int RailroadID { get; set; }
        public Railroad Railroad { get; set; }

        [Required(ErrorMessage = "Potrebno je upisati duljinu željeznice")]
        public decimal RailroadLength { get; set; }
    }
}
