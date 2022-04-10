using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Helpers.StatisticsExtensions
{
    public class TotalPercentage
    {
        public static decimal GetTotalPercentageValue(decimal currentValue, decimal maxValue)
        {
            if (currentValue != 0)
            {
                return Math.Round(((currentValue / maxValue) * 100),3);
            }

            return 0;
        }
    }
}
