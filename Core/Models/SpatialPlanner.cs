using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace ZAVOD_KZZ.Core.Models
{
    public class SpatialPlanner : BaseEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Potrebno je unesti naziv!")]
        public string Name { get; set; }
        public string Location { get; set; }
        public string  Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string WebAdress { get; set; }

        public ICollection<SpatialPlanDocument> SpatialPlanDocuments { get; set; }
    }
}
