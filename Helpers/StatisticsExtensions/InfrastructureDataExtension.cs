using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;
using ZAVOD_KZZ.Core.ViewModels;

namespace ZAVOD_KZZ.Helpers.StatisticsExtensions
{
    public class InfrastructureDataExtension
    {
       public static InfrastructureGraphChartVM GetSumByRoadCategory(IEnumerable<Road> roads, ICollection<int> includedCategoryIDs)
        {
            var filteredRoadCategories = roads.Where(x => !includedCategoryIDs.Contains(x.RoadCategoryID));
            var groupedData = filteredRoadCategories.GroupBy(x => x.RoadCategory.Name)
                .OrderBy(g => g.Key)
                .Select(g => new
                {
                    CategoryName = g.Key,
                    CategoryInKm = Math.Round(g.Sum(x => x.SpatialNewslength),2)
                }).ToList();

            var horizontalChartData = new InfrastructureGraphChartVM();

            horizontalChartData.InfrastructureCategory = new List<string>();
            horizontalChartData.InfrastructureCategoryCount = new List<decimal>();


            foreach (var data in groupedData)
            {
                horizontalChartData.InfrastructureCategory.Add(data.CategoryName);
                horizontalChartData.InfrastructureCategoryCount.Add(data.CategoryInKm);
            }

            return horizontalChartData;
        }

        public static InfrastructureGraphChartVM GetSumByRailoadCategory(IEnumerable<Railroad> railroads, ICollection<int> includedCategoryIDs)
        {
            var filteredRailroadCategories = railroads.Where(x => !includedCategoryIDs.Contains(x.RailroadCategoryID));
            var groupedData = filteredRailroadCategories.GroupBy(x => x.RailroadCategory.Name)
                .OrderBy(g => g.Key)
                .Select(g => new
                {
                    CategoryName = g.Key,
                    CategoryInKm = Math.Round(g.Sum(x => x.Lenght), 2)
                }).ToList();

            var horizontalChartData = new InfrastructureGraphChartVM();

            horizontalChartData.InfrastructureCategory = new List<string>();
            horizontalChartData.InfrastructureCategoryCount = new List<decimal>();


            foreach (var data in groupedData)
            {
                horizontalChartData.InfrastructureCategory.Add(data.CategoryName);
                horizontalChartData.InfrastructureCategoryCount.Add(data.CategoryInKm);
            }

            return horizontalChartData;
        }
        private static string GetColorForChartData(string categoryName)
        {
            
            string color ="green";

            switch (categoryName)
            {
                case "Nerazvrstana":
                    color = "blue";
                    break;
                case "Lokalna":
                    color = "orange";
                    break;
                case "Županijska":
                     color = "#39b54a";
                    break;
                case "Državna":
                    color = "red";
                    break;
                case "Brza":
                    color = "darkred";
                    break;
                case "Autocesta":
                    color = "yellow";
                    break;
                default:
                    color = "green";
                    break;
            }

            return color;
        }

       public static List<InfrastructureStackedChartVM> GetRoadDataForStackedChart(IEnumerable<RoadLocalGovernment> roadsLocalGovernment, ICollection<int> includedCategoryIDs)
       {
            var filteredRoadCategories = roadsLocalGovernment.Where(x => includedCategoryIDs.Contains(x.Road.RoadCategoryID));
            var groupedData = filteredRoadCategories.GroupBy(x => x.Road.RoadCategory.Name)
                .OrderBy(g => g.Key)
                .Select(g => new
                {
                    CategoryName = g.Key,
                    CategoryInKm = Math.Round(g.Sum(x => x.RoadLength), 2)
                }).ToList();


            var stackedChartData = new List<InfrastructureStackedChartVM>();


            foreach (var data in groupedData)
            {

                var dataSet = new InfrastructureStackedChartVM();
                dataSet.label = data.CategoryName;
                dataSet.data = new decimal[] { data.CategoryInKm };
                dataSet.backgroundColor = GetColorForChartData(data.CategoryName);

                stackedChartData.Add(dataSet);
            }

            return stackedChartData;

       }

        public static List<InfrastructureStackedChartVM> GetRailroadDataForStackedChart(IEnumerable<RailroadLocalGovernment> railroadsLocalGovernment, ICollection<int> includedCategoryIDs)
        {
            var filteredRoadCategories = railroadsLocalGovernment.Where(x => includedCategoryIDs.Contains(x.Railroad.RailroadCategoryID));
            var groupedData = filteredRoadCategories.GroupBy(x => x.Railroad.RailroadCategory.Name)
                .OrderBy(g => g.Key)
                .Select(g => new
                {
                    CategoryName = g.Key,
                    CategoryInKm = Math.Round(g.Sum(x => x.RailroadLength), 2)
                }).ToList();


            var stackedChartData = new List<InfrastructureStackedChartVM>();


            foreach (var data in groupedData)
            {

                var dataSet = new InfrastructureStackedChartVM();
                dataSet.label = data.CategoryName;
                dataSet.data = new decimal[] { data.CategoryInKm };
                dataSet.backgroundColor = GetColorForChartData(data.CategoryName);

                stackedChartData.Add(dataSet);
            }

            return stackedChartData;

        }

        public static string GetRoadDensityByCategoryId(IEnumerable<RoadLocalGovernment> roadsLocalGovernment, int categoryId, decimal? surfaceArea)
        {
            var value = "0 km/km\u00b2";

            if (surfaceArea.HasValue)
            {
                var sumLength = roadsLocalGovernment.Where(x => x.Road.RoadCategoryID == categoryId).Sum(x => x.RoadLength);
                value = string.Format("{0} km/km\u00b2", Math.Round((sumLength / (decimal)surfaceArea), 3));
            }

            return value;
        }

        public static string GetRailroadDensityByCategoryId(IEnumerable<RailroadLocalGovernment> railroadsLocalGovernment, int categoryId, decimal? surfaceArea)
        {
            var value = "0 km/km\u00b2";

            if (surfaceArea.HasValue)
            {
                var sumLength = railroadsLocalGovernment.Where(x => x.Railroad.RailroadCategoryID == categoryId).Sum(x => x.RailroadLength);
                value = string.Format("{0} km/km\u00b2", Math.Round((sumLength / (decimal)surfaceArea), 3));
            }

            return value;
        }

        public static Dictionary<string,string> GetRoadTotalPercentageLengthByCategoryId(IEnumerable<RoadLocalGovernment> roadsLocalGovernment, List<int> sortedCategories, int categoryId)
        {
            var totalValue =new Dictionary<string, string>();

            var totalLenghtInKm = roadsLocalGovernment.Where(x => sortedCategories.Contains(x.Road.RoadCategoryID)).Sum(x => x.RoadLength);

            var categoryLenght = roadsLocalGovernment.Where(x => x.Road.RoadCategory.Id == categoryId).Sum(x => x.RoadLength);
            var categoryFormatLenght = string.Format("{0} km", categoryLenght);

            var percentageValue =  TotalPercentage.GetTotalPercentageValue(categoryLenght, totalLenghtInKm);
            var percentageFormatTotal = string.Format("{0} %", percentageValue);

            totalValue.Add(categoryFormatLenght, percentageFormatTotal);

            return totalValue;
        }

        public static Dictionary<string, string> GetRailroadTotalPercentageLengthByCategoryId(IEnumerable<RailroadLocalGovernment> railroadsLocalGovernment, List<int> sortedCategories, int categoryId)
        {
            var totalValue = new Dictionary<string, string>();

            var totalLenghtInKm = railroadsLocalGovernment.Where(x => sortedCategories.Contains(x.Railroad.RailroadCategoryID)).Sum(x => x.RailroadLength);

            var categoryLenght = railroadsLocalGovernment.Where(x => x.Railroad.RailroadCategory.Id == categoryId).Sum(x => x.RailroadLength);
            var categoryFormatLenght = string.Format("{0} km", categoryLenght);

            var percentageValue = TotalPercentage.GetTotalPercentageValue(categoryLenght, totalLenghtInKm);
            var percentageFormatTotal = string.Format("{0} %", percentageValue);

            totalValue.Add(categoryFormatLenght, percentageFormatTotal);

            return totalValue;
        }
    }
}
