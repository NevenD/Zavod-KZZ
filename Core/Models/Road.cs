using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ZAVOD_KZZ.Helpers.Enums;

namespace ZAVOD_KZZ.Core.Models
{
    public class Road : BaseEntity
    {

        private string _codeUpper;

        public int Id { get; set; }

        [Required(ErrorMessage = "Potrebno je upisati oznaku ceste")]
        public string Code {
            get {return _codeUpper; }
            set { _codeUpper = value.ToUpper(); }
        }

        [Required(ErrorMessage = "Potrebno je odabrati kategoriju ceste")]
        public int RoadCategoryID { get; set; }
        public RoadCategory RoadCategory { get; set; }

        [Required(ErrorMessage = "Potrebno je upisati opis ceste")]
        public string Description { get; set; }

        public decimal? DigitalOrthophotoLength { get; set; }

        [Required(ErrorMessage = "Potrebno je upisati dužinu ceste")]
        [RegularExpression(@"^(?:[1-9][0-9]{0,10}|(?![0-9.]{12})(?:0\,[0-9]*[1-9][0-9]*|[1-9][0-9]*\,[0-9]+))$", ErrorMessage = "Potrebno je upisati točan format s decimalnim zarezom")]
        public decimal SpatialNewslength { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ReconstructionDate { get; set; }
        public string ReconstructionDescription { get; set; }

        public IEnumerable<RoadGeometry> Geometries { get; set; }
    }
}
