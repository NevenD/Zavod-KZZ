using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZAVOD_KZZ.Core.ViewModels;
using ZAVOD_KZZ.Data.Repositories;
using ZAVOD_KZZ.Helpers.Enums;
using ZAVOD_KZZ.Helpers.StatisticsExtensions;

namespace ZAVOD_KZZ.Controllers
{
    [Authorize]
    public class RoadsLocalGovernmentController : Controller
    {
        private readonly IRoadsRepository _roadsRepository;
        private readonly IRoadsCategoryRepository _roadsCategoryRepository;
        private readonly ILocalGovernmentAdministrationRepository _localGovernmentAdministrationRepository;
        private readonly IRoadsLocalGovermentRepository _roadsLocalGovermentRepository;

        public RoadsLocalGovernmentController(
            IRoadsRepository roadsRepository,
            IRoadsCategoryRepository roadsCategoryRepository,
            ILocalGovernmentAdministrationRepository localGovernmentAdministrationRepository,
            IRoadsLocalGovermentRepository roadsLocalGovermentRepository
            )
        {
            _roadsRepository = roadsRepository;
            _roadsCategoryRepository = roadsCategoryRepository;
            _localGovernmentAdministrationRepository = localGovernmentAdministrationRepository;
            _roadsLocalGovermentRepository = roadsLocalGovermentRepository;
        }

        public async Task<IActionResult> Create()
        {
            var roadsVM = new RoadsLocalGovernmentVM { 
                Roads = await _roadsRepository.GetAll(),
                LocalGovernmentAdministrations = await _localGovernmentAdministrationRepository.GetAll()
            };
            return View(roadsVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoadsLocalGovernmentVM roadsVM)
        {
            if (ModelState.IsValid)
            {
                await _roadsLocalGovermentRepository.Create(roadsVM.RoadLocalGovernment);
                return Ok();
            }
            return View(roadsVM);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var roadLocalGovernment = await _roadsLocalGovermentRepository.FindById((int)id);

            if (id == null || roadLocalGovernment == null)
            {
                return NotFound();
            }
            var roadsVM  = new RoadsLocalGovernmentVM {
                RoadLocalGovernment= roadLocalGovernment,  
                Roads = await _roadsRepository.GetAll(), 
                LocalGovernmentAdministrations = await _localGovernmentAdministrationRepository.GetAll() };
            return View(roadsVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RoadsLocalGovernmentVM roadsVM)
        {
            if (ModelState.IsValid)
            {
                await _roadsLocalGovermentRepository.Update(roadsVM.RoadLocalGovernment);
                return RedirectToAction(nameof(Details), new { id= roadsVM.RoadLocalGovernment.LocalGovernmentAdministrationID });
            }

            return View(roadsVM);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var vmModel = new RoadsLocalGovernmentDetailsVM();
            vmModel.LocalGovernmentAdministration = await _localGovernmentAdministrationRepository.SingleOrDefault(x => x.Id == id);
            vmModel.RoadsLocalGovernment = await _roadsLocalGovermentRepository.GetRoadsInLocalGovernmentById(id);

            var sortedCategory = new List<int>
            {
                (int)Enums.RoadCategory.HIGHWAY,
                (int)Enums.RoadCategory.COUNTY,
                (int)Enums.RoadCategory.STATE,
                (int)Enums.RoadCategory.LOCAL,
            };

            #region Road Density
            vmModel.PlannedRoadDensity = InfrastructureDataExtension.GetRoadDensityByCategoryId(vmModel.RoadsLocalGovernment, (int)Enums.RoadCategory.PLANNED, vmModel.LocalGovernmentAdministration.SurfaceArea);
            vmModel.UnSortedRoadDensity = InfrastructureDataExtension.GetRoadDensityByCategoryId(vmModel.RoadsLocalGovernment, (int)Enums.RoadCategory.UNSORTED, vmModel.LocalGovernmentAdministration.SurfaceArea);
            vmModel.LocalRoadDensity = InfrastructureDataExtension.GetRoadDensityByCategoryId(vmModel.RoadsLocalGovernment, (int)Enums.RoadCategory.LOCAL, vmModel.LocalGovernmentAdministration.SurfaceArea);
            vmModel.CountyRoadDensity = InfrastructureDataExtension.GetRoadDensityByCategoryId(vmModel.RoadsLocalGovernment, (int)Enums.RoadCategory.COUNTY, vmModel.LocalGovernmentAdministration.SurfaceArea);
            vmModel.StateRoadDensity = InfrastructureDataExtension.GetRoadDensityByCategoryId(vmModel.RoadsLocalGovernment, (int)Enums.RoadCategory.STATE, vmModel.LocalGovernmentAdministration.SurfaceArea);
            vmModel.SpeedRoadDensity = InfrastructureDataExtension.GetRoadDensityByCategoryId(vmModel.RoadsLocalGovernment, (int)Enums.RoadCategory.SPEED, vmModel.LocalGovernmentAdministration.SurfaceArea);
            vmModel.HighwayRoadDensity = InfrastructureDataExtension.GetRoadDensityByCategoryId(vmModel.RoadsLocalGovernment, (int)Enums.RoadCategory.HIGHWAY, vmModel.LocalGovernmentAdministration.SurfaceArea);
            #endregion

            #region Road Total Sum By Category
            vmModel.HighwayRoadTotal = InfrastructureDataExtension.GetRoadTotalPercentageLengthByCategoryId(vmModel.RoadsLocalGovernment, sortedCategory, (int)Enums.RoadCategory.HIGHWAY);
            vmModel.StateRoadTotal = InfrastructureDataExtension.GetRoadTotalPercentageLengthByCategoryId(vmModel.RoadsLocalGovernment, sortedCategory, (int)Enums.RoadCategory.STATE);
            vmModel.CountyRoadTotal = InfrastructureDataExtension.GetRoadTotalPercentageLengthByCategoryId(vmModel.RoadsLocalGovernment, sortedCategory, (int)Enums.RoadCategory.COUNTY);
            vmModel.LocalRoadTotal = InfrastructureDataExtension.GetRoadTotalPercentageLengthByCategoryId(vmModel.RoadsLocalGovernment, sortedCategory, (int)Enums.RoadCategory.LOCAL);
            #endregion


            vmModel.RoadsForStackedChart = InfrastructureDataExtension.GetRoadDataForStackedChart(vmModel.RoadsLocalGovernment, sortedCategory);
            if (vmModel.LocalGovernmentAdministration == null)
            {
                return NotFound();
            }
            return PartialView("_RoadsLocalGovernmentDetails", vmModel);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRoadLocalGovernment(int id)
        {

            var roadLocalGovernment = await _roadsLocalGovermentRepository.FindById(id);
            if (roadLocalGovernment == null)
            {
                return NotFound();
            }

            await _roadsLocalGovermentRepository.Delete(roadLocalGovernment.Id);
            return Ok();
        }
    }
}