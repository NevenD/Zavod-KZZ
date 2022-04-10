using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;
using ZAVOD_KZZ.Core.ViewModels;

namespace ZAVOD_KZZ.Helpers.StatisticsExtensions
{
    public class SpatialPlannersDataExtension
    {
        public static SpatialPlannersPieChartVM GetDataForPieChart(IEnumerable<SpatialPlanner> spatialPlanners)
        {
            var pieChartData = new SpatialPlannersPieChartVM();

            pieChartData.SpatialPlannersName = new List<string>();
            pieChartData.SpatiaPlansCountByPlanner = new List<long>();


            foreach (var planner in spatialPlanners)
            {
                if (planner.SpatialPlanDocuments.Count() > 0)
                {

                    pieChartData.SpatialPlannersName.Add(planner.Name);
                    pieChartData.SpatiaPlansCountByPlanner.Add(planner.SpatialPlanDocuments.Count);
                }
            }
  

            return pieChartData;

        }
    }
}
