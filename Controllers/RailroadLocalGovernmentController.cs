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
    public class RailroadLocalGovernmentController : Controller
    {

        private readonly IRailroadsRepository _railroadsRepository;
        private readonly IRailroadCategoryRepository _railroadCategoryRepository;
        private readonly ILocalGovernmentAdministrationRepository _localGovernmentAdministrationRepository;
        private readonly IRailroadLocalGovermentRepository _railroadLocalGovermentRepository;

        public RailroadLocalGovernmentController(
            IRailroadsRepository railroadsRepository,
            IRailroadCategoryRepository railroadCategoryRepository,
            ILocalGovernmentAdministrationRepository localGovernmentAdministrationRepository,
            IRailroadLocalGovermentRepository railroadLocalGovermentRepository
            )
        {
            _railroadsRepository = railroadsRepository;
            _railroadCategoryRepository = railroadCategoryRepository;
            _localGovernmentAdministrationRepository = localGovernmentAdministrationRepository;
            _railroadLocalGovermentRepository = railroadLocalGovermentRepository;
        }
        public async Task<IActionResult> Create()
        {
            var railroads = new RailroadLocalGovernmentVM
            {
                Railroads = await _railroadsRepository.GetAll(),
                LocalGovernmentAdministrations = await _localGovernmentAdministrationRepository.GetAll()
            };
            return View(railroads);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RailroadLocalGovernmentVM railroadsVM)
        {
            if (ModelState.IsValid)
            {
                await _railroadLocalGovermentRepository.Create(railroadsVM.RailroadLocalGovernment);
                return Ok();
            }
            return View(railroadsVM);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var railroadLocalGovernment = await _railroadLocalGovermentRepository.FindById((int)id);

            if (id == null || railroadLocalGovernment == null)
            {
                return NotFound();
            }
            var railroadsVM = new RailroadLocalGovernmentVM
            {
                RailroadLocalGovernment = railroadLocalGovernment,
                Railroads = await _railroadsRepository.GetAll(),
                LocalGovernmentAdministrations = await _localGovernmentAdministrationRepository.GetAll()
            };
            return View(railroadsVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RailroadLocalGovernmentVM railroadsVM)
        {
            if (ModelState.IsValid)
            {
                await _railroadLocalGovermentRepository.Update(railroadsVM.RailroadLocalGovernment);
                return RedirectToAction(nameof(Details), new { id = railroadsVM.RailroadLocalGovernment.LocalGovernmentAdministrationID });
            }

            return View(railroadsVM);
        }


        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var vmModel = new RailroadsLocalGovernmentDetailsVM();
            vmModel.LocalGovernmentAdministration = await _localGovernmentAdministrationRepository.SingleOrDefault(x => x.Id == id);
            vmModel.RailroadsLocalGovernment = await _railroadLocalGovermentRepository.GetRailroadsInLocalGovernmentById(id);

            var sortedCategory = new List<int>
            {
                (int)Enums.RailroadCategory.LOCAL,
                (int)Enums.RailroadCategory.REGIONAL,
            };

            #region Railroad Density
            vmModel.PlannedRailroadDensity = InfrastructureDataExtension.GetRailroadDensityByCategoryId(vmModel.RailroadsLocalGovernment, (int)Enums.RailroadCategory.PLANNED, vmModel.LocalGovernmentAdministration.SurfaceArea);
            vmModel.LocalRailroadDensity = InfrastructureDataExtension.GetRailroadDensityByCategoryId(vmModel.RailroadsLocalGovernment, (int)Enums.RailroadCategory.LOCAL, vmModel.LocalGovernmentAdministration.SurfaceArea);
            vmModel.RegionalRailroadDensity = InfrastructureDataExtension.GetRailroadDensityByCategoryId(vmModel.RailroadsLocalGovernment, (int)Enums.RailroadCategory.REGIONAL, vmModel.LocalGovernmentAdministration.SurfaceArea);
            #endregion

            #region Railroad Total Sum By Category
            vmModel.RegionalRailroadTotal = InfrastructureDataExtension.GetRailroadTotalPercentageLengthByCategoryId(vmModel.RailroadsLocalGovernment, sortedCategory, (int)Enums.RailroadCategory.REGIONAL);
            vmModel.LocalRailroadTotal = InfrastructureDataExtension.GetRailroadTotalPercentageLengthByCategoryId(vmModel.RailroadsLocalGovernment, sortedCategory, (int)Enums.RailroadCategory.LOCAL);
            #endregion


            vmModel.RailroadsForStackedChart = InfrastructureDataExtension.GetRailroadDataForStackedChart(vmModel.RailroadsLocalGovernment, sortedCategory);
            if (vmModel.LocalGovernmentAdministration == null)
            {
                return NotFound();
            }
            return PartialView("_RailroadsLocalGovernmentDetails", vmModel);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRailoadLocalGovernment(int id)
        {

            var railroadLocalGovernment = await _railroadLocalGovermentRepository.FindById(id);
            if (railroadLocalGovernment == null)
            {
                return NotFound();
            }

            await _railroadLocalGovermentRepository.Delete(railroadLocalGovernment.Id);
            return Ok();
        }
    }
}