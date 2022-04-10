using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Helpers.GIS.Culture;

namespace ZAVOD_KZZ.Core.ViewModels.GIS
{
    public class CultureVM
    {
        public string JSON { get; set; }
        public CultureGeoJSON CultureGeoJSON { get; set; }
    }
}
