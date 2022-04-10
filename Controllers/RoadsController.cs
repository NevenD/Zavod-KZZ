using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ZAVOD_KZZ.Core.Dtos;
using ZAVOD_KZZ.Core.Models;
using ZAVOD_KZZ.Core.ViewModels;
using ZAVOD_KZZ.Data.Repositories;
using ZAVOD_KZZ.Helpers.Enums;
using ZAVOD_KZZ.Helpers.StatisticsExtensions;

namespace ZAVOD_KZZ.Controllers
{
    [Authorize]
    public class RoadsController : Controller
    {
        #region DI
        private readonly IRoadsRepository _roadsRepository;
        private readonly IRoadsCategoryRepository _roadsCategoryRepository;
        private readonly ILocalGovernmentAdministrationRepository _localGovernmentAdministrationRepository;
        private readonly IRegulationRepository _regulationRepository;
        private readonly IRoadsGeometryRepository _roadsGeometryRepository;
        private readonly IMapper _mapper;

        public RoadsController(
            IMapper mapper,
            IRoadsRepository roadsRepository,
            IRoadsCategoryRepository roadsCategoryRepository,
            ILocalGovernmentAdministrationRepository localGovernmentAdministrationRepository,
            IRegulationRepository regulationRepository,
            IRoadsGeometryRepository roadsGeometryRepository
            )
        {
            _mapper = mapper;
            _roadsRepository = roadsRepository;
            _roadsCategoryRepository = roadsCategoryRepository;
            _localGovernmentAdministrationRepository = localGovernmentAdministrationRepository;
            _regulationRepository = regulationRepository;
            _roadsGeometryRepository = roadsGeometryRepository;
        }
        #endregion
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var roadsVM = new RoadsVM();

            var unsortedCategory = new List<int> 
            { 
                (int)Enums.RoadCategory.UNSORTED,
                (int)Enums.RoadCategory.PLANNED,
            };

            var sortedCategory = new List<int>
            {
                (int)Enums.RoadCategory.HIGHWAY,
                (int)Enums.RoadCategory.SPEED,
                (int)Enums.RoadCategory.COUNTY,
                (int)Enums.RoadCategory.STATE,
                (int)Enums.RoadCategory.LOCAL,
            };

            roadsVM.Roads = await _roadsRepository.GetAllRoads();
            roadsVM.LocalGovernmentAdministrations = await _localGovernmentAdministrationRepository.GetAllLocalGovernments();
            roadsVM.SpatialNewslengthTotalSum = roadsVM.Roads.Where(x => !unsortedCategory.Contains(x.RoadCategoryID)).Sum(x => x.SpatialNewslength);
            roadsVM.DigitalOrthophotoLengthTotalSum = (decimal)roadsVM.Roads.Where(x => !unsortedCategory.Contains(x.RoadCategoryID)).Sum(x => x.DigitalOrthophotoLength);
            roadsVM.SortedRoadsGraphChart = InfrastructureDataExtension.GetSumByRoadCategory(roadsVM.Roads, unsortedCategory);
            roadsVM.UnSortedRoadsGraphChart = InfrastructureDataExtension.GetSumByRoadCategory(roadsVM.Roads, sortedCategory);
            roadsVM.Regulations = await _regulationRepository.GetAllRegulations().ContinueWith(x => x.Result.Where(y => y.IsSortedRoadRegulation == true).ToList());
            return View(roadsVM);
        }

        public async Task<IActionResult> Create()
        {
            var roadsVM = new RoadsVM { RoadCategories = await _roadsCategoryRepository.GetAll(), RoadGeometries = await _roadsGeometryRepository.GetAllRoadGeometry() };
            return View(roadsVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoadsVM roadsVM)
        {
            roadsVM.RoadCategories = await _roadsCategoryRepository.GetAll();
            if (ModelState.IsValid)
            {
               
                await _roadsRepository.Create(roadsVM.Road);
                if (!string.IsNullOrEmpty(roadsVM.CoordinatesUnprojected))
                {

                    var roadGeometry = new RoadGeometry
                    {
                        RoadID = roadsVM.Road.Id,
                        GeoJSON = roadsVM.GeojsonFormat,
                        WKT = roadsVM.WKTFormat,
                        CoordinatesUnprojected = roadsVM.CoordinatesUnprojected
                    };
                    await _roadsGeometryRepository.Create(roadGeometry);
                }

                var roadVectors = await _roadsGeometryRepository.GetAllRoadGeometry();

                var roadsDTO = _mapper.Map<IEnumerable<RoadGeometryDTO>>(roadVectors);
                return Json(new { RoadCode = roadsVM.Road.Code, RoadVectors = roadsDTO });
             

            }
            return Json(new { Error = "Došlo je do greške"});

        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var road = await _roadsRepository.GetRoadWithGeometryById((int)id);

            if (id == null || road == null)
            {
                return NotFound();
            }

            var roadGeometries = await _roadsGeometryRepository.GetAllRoadGeometry().ContinueWith(x => x.Result.Where(y => y.RoadID != road.Id).ToList());
            var roadsVM = new RoadsVM { RoadCategories = await _roadsCategoryRepository.GetAll(), Road = road, RoadGeometries = roadGeometries };
            return View(roadsVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RoadsVM roadsVM)
        {
            roadsVM.RoadCategories = await _roadsCategoryRepository.GetAll();
            if (ModelState.IsValid)
            {
                await _roadsRepository.Update(roadsVM.Road);
                if (!string.IsNullOrEmpty(roadsVM.CoordinatesUnprojected))
                {
                    var roadGeometryEdit = await _roadsGeometryRepository.GetRoadGeometrybyRoadId(roadsVM.Road.Id);

                    if (roadGeometryEdit != null)
                    {

                        roadGeometryEdit.GeoJSON = roadsVM.GeojsonFormat;
                        roadGeometryEdit.WKT = roadsVM.WKTFormat;
                        roadGeometryEdit.CoordinatesUnprojected = roadsVM.CoordinatesUnprojected;

                        await _roadsGeometryRepository.Update(roadGeometryEdit);
                    } else
                    {
                        var roadGeometry = new RoadGeometry
                        {
                            RoadID = roadsVM.Road.Id,
                            GeoJSON = roadsVM.GeojsonFormat,
                            WKT = roadsVM.WKTFormat,
                            CoordinatesUnprojected = roadsVM.CoordinatesUnprojected
                        };
                        await _roadsGeometryRepository.Create(roadGeometry);
                    }
                }
                return Json(new { RoadCode = roadsVM.Road.Code});
            }
            return Json(new { Error = "Došlo je do greške" });
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteRoad(int id)
        {

            var road = await _roadsRepository.FindById(id);
            if (road == null)
            {
                return NotFound();
            }

            await _roadsRepository.Delete(road.Id);
            return Ok();
        }
    }
}