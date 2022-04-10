using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Helpers.Enums;

namespace ZAVOD_KZZ.Core.Models
{
    public class RoadLocalGovernment:BaseEntity
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Potrebno je odabrati jedinicu lokalne samouprave")]
        public int LocalGovernmentAdministrationID { get; set; }
        public LocalGovernmentAdministration LocalGovernmentAdministration { get; set; }

        [Required(ErrorMessage = "Potrebno je odabrati cestu")]
        public int RoadID { get; set; }
        public Road Road { get; set; }

        [Required(ErrorMessage = "Potrebno je upisati duljinu cestu")]
        public decimal RoadLength { get; set; }
    }
}
