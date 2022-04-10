using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZAVOD_KZZ.Core.ViewModels.GIS;
using Newtonsoft.Json;
using ZAVOD_KZZ.Helpers.GIS.Culture;
using ZAVOD_KZZ.Services.Azure.Interfaces;
using ZAVOD_KZZ.Services.Azure.Helpers;
using ZAVOD_KZZ.Helpers.GIS.Traffic;
using System.Collections.Generic;
using ZAVOD_KZZ.Helpers.GIS;

namespace ZAVOD_KZZ.Controllers
{
    [AllowAnonymous]
    public class MapsController : Controller
    {
        private readonly IBlobService _blobService;
        public MapsController( IBlobService blobService)
        {
            _blobService = blobService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Culture()
        {
            var cultureVM = new CultureVM();

            try
            {
                var json = await _blobService.GetBlobGeoJSON(AzureStorageHelpers.StorageFileName.CultureFileJSON);
                cultureVM.CultureGeoJSON = JsonConvert.DeserializeObject<CultureGeoJSON>(json);
          
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
         

            return View(cultureVM);
        }

        public async Task<IActionResult> Traffic()
        {
            var traffic = new TrafficVM();

            
            var railJSON = await _blobService.GetBlobGeoJSON(AzureStorageHelpers.StorageFileName.RailJSON);
            var roadJSON = await _blobService.GetBlobGeoJSON(AzureStorageHelpers.StorageFileName.RoadJSON);
            var plannedRoadJSON = await _blobService.GetBlobGeoJSON(AzureStorageHelpers.StorageFileName.RoadPlannedJSON);


            traffic.Railroad = JsonConvert.DeserializeObject<RailGeoJSON>(railJSON);
            traffic.Road = JsonConvert.DeserializeObject<RoadGeoJSON>(roadJSON);
            traffic.PlannedRoad = JsonConvert.DeserializeObject<PlannedRoadGeoJSON>(plannedRoadJSON);


            var layerNames = new Dictionary<string, string>
            {
                { "sortedRoad", "Javne razvrstane ceste" },
                { "plannedRoad", "Planirane razvrstane ceste" },
                { "railroad", "Željeznice" }
            };

            traffic.MapLayers = MapHelpers.GetDataForGraphChart(layerNames);

            return View(traffic);
        }
    }
}