using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Helpers.Extensions
{
    public static class StringHelpers
    {
        public static string RemoveDash(string input)
        {
            return input?.Replace("-", " ");
        }
    }
}
