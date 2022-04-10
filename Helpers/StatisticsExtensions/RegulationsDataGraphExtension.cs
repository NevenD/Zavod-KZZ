using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;
using ZAVOD_KZZ.Core.ViewModels;

namespace ZAVOD_KZZ.Helpers.StatisticsExtensions
{
    public class RegulationsDataGraphExtension
    {
        public static RegulationsGraphChartVM GetDataForGraphChart(IEnumerable<Regulation> regulations)
        {

            var horizontalChartData = new RegulationsGraphChartVM();
            horizontalChartData.RegulationsTypes = new List<string>();
            horizontalChartData.RegulationsTypesCount = new List<long>();


            var groupedData = regulations.SelectMany(x => new[] { x.RegulationType })
               .GroupBy(dt => new { dt.Name })
               .OrderBy(g => g.Key.Name)
               .Select(g => new
               {
                   g.Key.Name,
                   Count = g.Count()
               }).ToList();


            foreach (var data in groupedData)
            {
                horizontalChartData.RegulationsTypes.Add(data.Name);
                horizontalChartData.RegulationsTypesCount.Add(data.Count);
            }


            return horizontalChartData;
        }
    }
}
