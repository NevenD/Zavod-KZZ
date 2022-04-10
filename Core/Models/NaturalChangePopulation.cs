using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Core.Models
{
    public class NaturalChangePopulation : BaseEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Potrebno je odabrati godinu")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Potrebno je upisati broj rođenih")]
        public int LiveBirth { get; set; }
        public int? StillBirth { get; set; }
        public int? InfantDeath { get; set; }

        [Required(ErrorMessage = "Potrebno je upisati broj umrlih")]
        public int Death { get; set; }

        [Required(ErrorMessage = "Potrebno je odabrati jedinicu lokalne samouprave")]
        public int LocalGovernmentAdministrationID { get; set; }
        public LocalGovernmentAdministration LocalGovernmentAdministration { get; set; }


        // Prirodni priraast
        public int NaturalIncrease => LiveBirth - Death;

        // Ukupno rođeni
        public int TotalBirth
        {
            get
            {
                if (StillBirth.HasValue)
                {
                    return LiveBirth + StillBirth.Value;
                }
                return LiveBirth + 0;
            }
        }

        // Ukupno umrli
        public int TotalDeathBirth
        {
            get
            {
                if (InfantDeath.HasValue)
                {
                    return Death + InfantDeath.Value;
                }
                return Death + 0;
            }
        }
        // Vitalni index
        public decimal VitalIndex => Math.Round(((decimal)LiveBirth / (decimal)Death) * 100,3);

        // Stopa nataliteta prema zadnjem popisu
        public decimal BirthRate 
        {
            get {

                if (LocalGovernmentAdministration != null && LocalGovernmentAdministration.Population2021.HasValue &&  LocalGovernmentAdministration.Population2021 != 0)
                {
                    return Math.Round(((decimal)LiveBirth / (decimal)LocalGovernmentAdministration.Population2021) * 1000, 3);
                }
                
                return (LocalGovernmentAdministration != null &&  LocalGovernmentAdministration.Population2011.HasValue &&  LocalGovernmentAdministration.Population2011 != 0) ?
                        Math.Round(((decimal)LiveBirth / (decimal)LocalGovernmentAdministration.Population2011) * 1000, 3) : 0;
            }
        }

        // Stopa mortaliteta prema zadnjem popisu
        public decimal DeathRate
        {
            get
            {
                if (LocalGovernmentAdministration != null && LocalGovernmentAdministration.Population2021.HasValue  &&  LocalGovernmentAdministration.Population2021 != 0)
                {
                    return Math.Round(((decimal)Death / (decimal)LocalGovernmentAdministration.Population2021) * 1000, 3);
                }

                return (LocalGovernmentAdministration != null && LocalGovernmentAdministration.Population2011.HasValue && LocalGovernmentAdministration.Population2011 != 0) ?
                        Math.Round(((decimal)Death / (decimal)LocalGovernmentAdministration.Population2011) * 1000, 3) : 0;
            }
        }

    }
}
