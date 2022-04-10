using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Helpers.Enums;
namespace ZAVOD_KZZ.Helpers.Extensions
{
    public class RoadExtension
    {

        public static string GetRoadCategoryStyle(int categoryId)
        {
            string style;
            switch (categoryId)
            {
                case (int)Enums.Enums.RoadCategory.PLANNED:
                    style = "color: blue;";
                    break;
                case (int)Enums.Enums.RoadCategory.UNSORTED:
                    style = "color: purple;";
                    break;
                case (int)Enums.Enums.RoadCategory.LOCAL:
                    style = "color: darkorange;";
                    break;
                case (int)Enums.Enums.RoadCategory.COUNTY:
                    style = "color: green;";
                    break;
                case (int)Enums.Enums.RoadCategory.STATE:
                    style = "color: darkred;";
                    break;
                case (int)Enums.Enums.RoadCategory.SPEED:
                    style = "color: red;";
                    break;
                default:
                    style = "color: pink;";
                    break;
            }

            return style;
        }
    }
}
