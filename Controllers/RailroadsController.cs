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
    public class RailroadsController : Controller
    {

        #region DI
        private readonly IRailroadsRepository _railroadsRepository;
        private readonly IRailroadCategoryRepository _railroadsCategoryRepository;
        private readonly ILocalGovernmentAdministrationRepository _localGovernmentAdministrationRepository;
        private readonly IRegulationRepository _regulationRepository;

        public RailroadsController(
            IRailroadsRepository railroadsRepository,
            IRailroadCategoryRepository railroadsCategoryRepository,
            ILocalGovernmentAdministrationRepository localGovernmentAdministrationRepository,
            IRegulationRepository regulationRepository
            )
        {
            _railroadsRepository = railroadsRepository;
            _railroadsCategoryRepository = railroadsCategoryRepository;
            _localGovernmentAdministrationRepository = localGovernmentAdministrationRepository;
            _regulationRepository = regulationRepository;
        }
        #endregion

        [AllowAnonymous]
        public async Task <IActionResult> Index()
        {
            var railsVM = new RailroadsVM();

            var unsortedCategory = new List<int>
            {
                (int)Enums.RailroadCategory.PLANNED,
                (int)Enums.RailroadCategory.ALL
            };

            var sortedCategory = new List<int>
            {
                (int)Enums.RailroadCategory.REGIONAL,
                (int)Enums.RailroadCategory.LOCAL
            };

            railsVM.Railroads = await _railroadsRepository.GetAllRailroads();
            railsVM.LocalGovernmentAdministrations = await _localGovernmentAdministrationRepository.GetAllLocalGovernments();
            railsVM.TotalSum = railsVM.Railroads.Where(x => !unsortedCategory.Contains(x.RailroadCategoryID)).Sum(x => x.Lenght);
            railsVM.Regulations = await _regulationRepository.GetAllRegulations().ContinueWith(x => x.Result.Where(y => y.IsRailRoadRegulation == true).ToList());
            railsVM.SortedRailroadsGraphChart = InfrastructureDataExtension.GetSumByRailoadCategory(railsVM.Railroads, unsortedCategory);
            railsVM.UnSortedRailroadsGraphChart = InfrastructureDataExtension.GetSumByRailoadCategory(railsVM.Railroads, sortedCategory);
            return View(railsVM);
        }

        public async Task<IActionResult> Create()
        {
            var railsVM = new RailroadsVM { RailroadCategories = await _railroadsCategoryRepository.GetAll() };
            return View(railsVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RailroadsVM railsVM)
        {
            railsVM.RailroadCategories = await _railroadsCategoryRepository.GetAll();
            if (ModelState.IsValid)
            {
                await _railroadsRepository.Create(railsVM.Railroad);
                return RedirectToAction(nameof(Index));
            }
            return View(railsVM);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var railroad = await _railroadsRepository.FindById((int)id);

            if (id == null || railroad == null)
            {
                return NotFound();
            }
            var railroadVM = new RailroadsVM { RailroadCategories = await _railroadsCategoryRepository.GetAll(), Railroad = railroad };
            return View(railroadVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RailroadsVM railsVM)
        {
            railsVM.RailroadCategories = await _railroadsCategoryRepository.GetAll();
            if (ModelState.IsValid)
            {
                await _railroadsRepository.Update(railsVM.Railroad);
                return RedirectToAction(nameof(Index));
            }
            return View(railsVM);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var vmModel = new RailroadsVM();
            vmModel.Railroad = await _railroadsRepository.FindRailroadById(id);

            if (vmModel.Railroad == null)
            {
                return NotFound();
            }
            return PartialView("_RailroadDetails", vmModel);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRailroad(int id)
        {

            var railroad = await _railroadsRepository.FindById(id);
            if (railroad == null)
            {
                return NotFound();
            }

            await _railroadsRepository.Delete(railroad.Id);
            return Ok();
        }
    }
}