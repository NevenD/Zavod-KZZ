using System.Collections.Generic;
using System.Linq;
using ZAVOD_KZZ.Core.Models;
using ZAVOD_KZZ.Core.ViewModels;

namespace ZAVOD_KZZ.Helpers.StatisticsExtensions
{
    public class SpatialDocumentGraphDataExtension
    {

        public static SpatialPlansDocumentLineChartVM GetDataForLineChart(IEnumerable<SpatialPlanDocument> spatialDocuments)
        {
            //https://stackoverflow.com/questions/41282053/groupby-multiple-date-properties-by-month-and-year-in-linq
            //https://stackoverflow.com/questions/7285714/linq-with-groupby-and-count/7285770
            var groupedData = spatialDocuments.SelectMany(x => new[] { x.SpatialPlanEnactmentDate }.Where(date => date != null).Select(dt => dt.Value))
                .GroupBy(dt => new { dt.Year })
                .OrderBy(g => g.Key.Year)
                .Select(g => new
                {
                    g.Key.Year,
                    Count = g.Count()
                }).ToList();


            var lineChartData = new SpatialPlansDocumentLineChartVM();

            lineChartData.SpatialPlanYear = new List<string>();
            lineChartData.SpatialPlansCountPerYear = new List<int>();


            foreach (var data in groupedData)
            {
                lineChartData.SpatialPlanYear.Add(data.Year.ToString());
                lineChartData.SpatialPlansCountPerYear.Add(data.Count);

            }


            return lineChartData;

        }

        public static SpatialPlansLevelChartVM GetDataForPlanLevelChart(IEnumerable<SpatialPlanDocument> spatialDocuments)
        {
            var horizontalChartData = new SpatialPlansLevelChartVM();
            horizontalChartData.SpatialPlansCategory = new List<string>();
            horizontalChartData.SpatialPlansCount = new List<long>();


            var groupedData = spatialDocuments.SelectMany(x => new[] { x.SpatialPlanLevel })
               .GroupBy(dt => new { dt.ShortName })
               .OrderBy(g => g.Key.ShortName)
               .Select(g => new
               {
                   g.Key.ShortName,
                   Count = g.Count()
               }).ToList();


            foreach (var data in groupedData)
            {
                horizontalChartData.SpatialPlansCategory.Add(data.ShortName);
                horizontalChartData.SpatialPlansCount.Add(data.Count);
            }


            return horizontalChartData;
        }

        public static SpatialPlansLocalAdministrationChartVM GetDataForPlanLocalAdministrationChart(IEnumerable<SpatialPlanDocument> spatialDocuments)
        {
            var spatialPlansLocal = new SpatialPlansLocalAdministrationChartVM();
            spatialPlansLocal.LocalAdministrationName = new List<string>();
            spatialPlansLocal.SpatialPlansCount = new List<long>();


            var groupedData = spatialDocuments.Where(st => st.SpatialPlanStatus.Id == (int)Enums.Enums.SpatialPlanStatus.VALID).SelectMany(x => new[] { x.LocalGovernmentAdministration })
               .GroupBy(dt => new { dt.Name })
               .OrderBy(g => g.Key.Name)
               .Select(g => new
               {
                   g.Key.Name,
                   Count = g.Count()
               }).ToList();


            foreach (var data in groupedData)
            {
                spatialPlansLocal.LocalAdministrationName.Add(data.Name);
                spatialPlansLocal.SpatialPlansCount.Add(data.Count);
            }


            return spatialPlansLocal;
        }
    }
}
