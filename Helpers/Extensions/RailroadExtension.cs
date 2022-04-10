using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Helpers.Extensions
{
    public class RailroadExtension
    {
        public static string GetRailroadCategoryStyle(int categoryId)
        {
            string style;
            switch (categoryId)
            {
                case (int)Enums.Enums.RailroadCategory.PLANNED:
                    style = "color: #2196f3;";
                    break;
                case (int)Enums.Enums.RailroadCategory.REGIONAL:
                    style = "color: #4dac26;";
                    break;
                case (int)Enums.Enums.RailroadCategory.LOCAL:
                    style = "color: #8bc34a;";
                    break;
                default:
                    style = "color: #f44336;";
                    break;
            }

            return style;
        }
    }
}
