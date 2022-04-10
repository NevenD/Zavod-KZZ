using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using ZAVOD_KZZ.Core.Models.ManyToMany;
using ZAVOD_KZZ.Helpers.Enums;

namespace ZAVOD_KZZ.Core.Models
{
    public class LocalGovernmentAdministration
    {
        public LocalGovernmentAdministration()
        {
            SettlementLocalGovernments = new HashSet<SettlementLocalGovernment>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Potrebno je unesti naziv jedinice lokalne samouprave")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Potrebno je unesti matični broj JLS!")]
        public int CodeNumber { get; set; }

        [RegularExpression(@"^[1-9]\d*(\,\d+)?$", ErrorMessage = "Potrebno je upisati točan format")]
        public decimal? SurfaceArea { get; set; }
        public long? Population2001 { get; set; }
        public long? Population2011 { get; set; }
        public long? Population2021 { get; set; }
        public string WebSiteUrl { get; set; }
        public bool IsAdministrativeCity { get; set; }

        [Required(ErrorMessage = "Potrebno je odabrati Tip naselja")]
        public int CommunityTypeID { get; set; }
        [ForeignKey(nameof(CommunityTypeID))]
        public CommunityType CommunityType { get; set; }

        public ICollection<SettlementLocalGovernment> SettlementLocalGovernments { get; set; }

        #region Population
        //population decrease for period from 2001 to 2011
        public decimal PopulationDecrease2011 =>
            (Population2001.HasValue && Population2011.HasValue) ?
            Math.Round((((decimal)Population2001.Value - (decimal)Population2011.Value) / (decimal)Population2001), 3) * 100 : 0;


        public int SettlementCount => (SettlementLocalGovernments == null) ? 0 : SettlementLocalGovernments.Count();


        public decimal SettlementDensity => Math.Round((SettlementCount / (decimal)Enums.SurfaceArea.SQUARE_KILOMETERS),3);


        //population decrease for period from 2011 to 2021
        public decimal PopulationDecrease2021 =>
           (Population2011.HasValue && Population2021.HasValue) ?
           Math.Round((((decimal)Population2011.Value - (decimal)Population2021.Value) / (decimal)Population2011),3) * 100 : 0;

        // population change index for period 2011-2001
        public decimal PopulationIndexChange2011 =>
           (Population2001.HasValue && Population2011.HasValue)
            ? Math.Round((decimal)Population2011.Value / (decimal)Population2001.Value, 3) * 100
            : 0;


        // population change index for period 2021-2011
        public decimal PopulationIndexChange2021 =>
        (Population2001.HasValue && Population2011.HasValue)
        ? Math.Round((decimal)Population2021.Value / (decimal)Population2011.Value,3) * 100
        : 0;
        #endregion

        #region PopulationDensity
        // population/surface 2001
        public decimal PopulationDensity2001 => 
            (Population2001.HasValue && SurfaceArea.HasValue ) 
            ? Math.Round((decimal)Population2001 / (decimal)SurfaceArea,3) : 0;

        // population/surface 2011
        public decimal PopulationDensity2011 =>
        (Population2001.HasValue  && SurfaceArea.HasValue ) 
            ? Math.Round((decimal)Population2011 / (decimal)SurfaceArea,3) : 0;

        // population/surface 2021
        public decimal PopulationDensity2021 =>
         (Population2001.HasValue && SurfaceArea.HasValue) 
          ? Math.Round((decimal)Population2021 / (decimal)SurfaceArea,3) : 0;

        #endregion
    }
}
