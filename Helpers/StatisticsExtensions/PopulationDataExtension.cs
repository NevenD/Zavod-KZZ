using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;
using ZAVOD_KZZ.Core.ViewModels.Population;

namespace ZAVOD_KZZ.Helpers.StatisticsExtensions
{
    public  class PopulationDataExtension
    {
        public static IEnumerable<long> GetPopulationValues(LocalGovernmentAdministration localGovernmentAdministration)
        {
            var populationData = new List<long>();

            var pop01 = (localGovernmentAdministration.Population2001.HasValue) ? (long)localGovernmentAdministration.Population2001 : 0;
            var pop11 = (localGovernmentAdministration.Population2011.HasValue) ? (long)localGovernmentAdministration.Population2011 : 0;
            var pop21 = (localGovernmentAdministration.Population2021.HasValue) ? (long)localGovernmentAdministration.Population2021 : 0;

            populationData.Add(pop01);
            populationData.Add(pop11);
            populationData.Add(pop21);


            return populationData;

        }



        public static IEnumerable<NaturalChangeByYearVM> GetNaturalChangeGroupedByYear(IEnumerable<NaturalChangePopulation> naturalChange)
        {
           
            var groupedData = naturalChange.GroupBy(x => x.Year)
                .OrderBy(g => g.Key)
                .Select(g => new
                {
                    Year = g.Key,
                    LiveBirths = g.Sum(x => x.LiveBirth),
                    DeathBirths = g.Sum(x => x.Death),
                    TotalBirths = g.Sum(x => x.LiveBirth) + g.Sum(x => x.StillBirth),
                    Death = g.Sum(x => x.Death),
                    InfantDeath = g.Sum(x => x.InfantDeath),
                    TotalDeath = g.Sum(x => x.Death) + g.Sum(x => x.InfantDeath),
                    NaturalChange = g.Sum(x => x.LiveBirth) - g.Sum(x => x.Death),
                    VitalIndex = Math.Round(((decimal)g.Sum(x => x.LiveBirth) / (decimal)g.Sum(x => x.Death) *100),3)
                }).ToList();


            var naturalChangeList = new List<NaturalChangeByYearVM>();

            foreach (var data in groupedData)
            {
                var naturalChangeData = new NaturalChangeByYearVM
                {
                    Year = data.Year,
                    LiveBirths = data.LiveBirths,
                    DeathBirths = data.DeathBirths,
                    TotalBirths = (int)data.TotalBirths,
                    Death = data.Death,
                    InfantDeath = (int)data.InfantDeath,
                    TotalDeath = (int)data.TotalDeath,
                    NaturalChange = data.NaturalChange,
                    VitalIndex = data.VitalIndex
                };
                naturalChangeList.Add(naturalChangeData);

            }

            return naturalChangeList;

        }

        public static IEnumerable<NaturalChangePopulation> FilterNaturalChangeByRecentYear(IEnumerable<NaturalChangePopulation> naturalChange)
        {
            var maxYear = naturalChange.Any() ? naturalChange.Select(x => x.Year).Max() : 0;
            var filteredData = naturalChange.Where(x => x.Year == maxYear).ToList();
            return filteredData;
        }

        public static NaturalChangeGraphVM GetPopulationChangeLineChartData(IEnumerable<NaturalChangePopulation> naturalChange)
        {
            var groupedData = naturalChange.GroupBy(x => x.Year)
              .OrderBy(g => g.Key)
              .Select(g => new
              {
                  Year = g.Key.ToString(),
                  LiveBirths = g.Sum(x => x.LiveBirth),
                  Death = g.Sum(x => x.Death),
              }).ToList();


            var lineChartData = new NaturalChangeGraphVM();
            lineChartData.NaturalChangeDataSets = new List<NaturalChangeDataSetVM>();

            var labels = new List<string>();

            var dataPerYearDeath = new List<int>();

            foreach (var data in groupedData)
            {
                labels.Add(data.Year);
            }

            // fetched label years
            lineChartData.Labels = labels.ToArray();

            // create LiveBirths dataset
            var naturalDataBirths = new NaturalChangeDataSetVM();
            var dataPerYearBorn = new List<int>();
            foreach (var born in groupedData)
            {
                dataPerYearBorn.Add(born.LiveBirths);
            }
            naturalDataBirths.Label = "Rođeni";
            naturalDataBirths.BorderColor = "orange";
            naturalDataBirths.PointBackgroundColor = "orange";
            naturalDataBirths.PointBorderColor = "orange";

            naturalDataBirths.BorderDash = new int[] { 0, 0 };
            naturalDataBirths.Data = dataPerYearBorn.ToArray();

            lineChartData.NaturalChangeDataSets.Add(naturalDataBirths);


            // create LiveBirths dataset
            var naturalDataDeaths = new NaturalChangeDataSetVM();
            var dataPerYeaDeath = new List<int>();
            foreach (var death in groupedData)
            {
                dataPerYeaDeath.Add(death.Death);
            }
            naturalDataDeaths.Label = "Umrli";
            naturalDataDeaths.BorderColor = "red";
            naturalDataDeaths.PointBackgroundColor = "red";
            naturalDataDeaths.PointBorderColor = "red";
            naturalDataDeaths.BorderDash = new int[] { 6, 6};
            naturalDataDeaths.Data = dataPerYeaDeath.ToArray();
            lineChartData.NaturalChangeDataSets.Add(naturalDataDeaths);


            return lineChartData;
        }
    }
}
