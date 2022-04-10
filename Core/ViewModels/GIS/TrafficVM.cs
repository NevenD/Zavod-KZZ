using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Helpers.GIS;
using ZAVOD_KZZ.Helpers.GIS.Traffic;

namespace ZAVOD_KZZ.Core.ViewModels.GIS
{
    public class TrafficVM
    {
        public RailGeoJSON Railroad { get; set; }
        public RoadGeoJSON Road { get; set; }
        public PlannedRoadGeoJSON PlannedRoad { get; set; }

        public IEnumerable<MapLayer> MapLayers { get; set; }

    }
}
