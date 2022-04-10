using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Helpers.GIS
{
    public class MapHelpers
    {
        public static IEnumerable<MapLayer> GetDataForGraphChart(Dictionary<string, string> layers)
        {

            var mapLayers = new List<MapLayer>();


            foreach (var item in layers)
            {
                var layer = new MapLayer
                {
                    LayerName = string.Format("{0}", item.Value),
                    LayerId = string.Format("{0}_id", item.Key.ToLower()),
                    SliderId = string.Format("{0}_slider", item.Key.ToLower()),
                };

                mapLayers.Add(layer);
            }


            return mapLayers;
        }
    }
}
