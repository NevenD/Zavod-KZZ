using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Core.Models
{
    public class Railroad : BaseEntity
    {

        private string _codeUpper;


        public int Id { get; set; }

        [Required(ErrorMessage = "Potrebno je upisati oznaku željeznice")]
        public string Code
        {
            get { return _codeUpper; }
            set { _codeUpper = value.ToUpper(); }
        }

        [Required(ErrorMessage = "Potrebno je odabrati kategoriju željeznice")]
        public int RailroadCategoryID { get; set; }
        public RailroadCategory RailroadCategory { get; set; }

        [Required(ErrorMessage = "Potrebno je upisati naziv željeznice")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Potrebno je upisati skraćeni naziv željeznice")]
        public string ShortName { get; set; }

        [Required(ErrorMessage = "Potrebno je upisati građevinsku duljinu")]
        public decimal ConstructionLength { get; set; }

        [Required(ErrorMessage = "Potrebno je upisati broj kolodvora")]
        public int TrainStationNumber { get; set; }

        [Required(ErrorMessage = "Potrebno je upisati broj stajališta")]
        public int TrainPositionNumber { get; set; }

        [Required(ErrorMessage = "Potrebno je upisati duljinu u KZŽ")]
        public decimal Lenght { get; set; }
        public DateTime? ReconstructionDateStart { get; set; }
        public DateTime? ReconstructionDateEnd { get; set; }

        public decimal? ReconstructionLenght { get; set; }
        public string Remark { get; set; }
    }
}
