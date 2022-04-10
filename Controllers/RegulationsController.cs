using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZAVOD_KZZ.Core.Models;
using ZAVOD_KZZ.Core.ViewModels;
using ZAVOD_KZZ.Data;
using ZAVOD_KZZ.Data.Repositories;
using ZAVOD_KZZ.Helpers.StatisticsExtensions;

namespace ZAVOD_KZZ.Controllers
{
    [Authorize]
    public class RegulationsController : Controller
    {
        private readonly IRegulationTypeRepository _regulationTypeRepository;
        private readonly IRegulationRepository _regulationRepository;

        public RegulationsController(
            IRegulationTypeRepository regulationTypeRepository,
            IRegulationRepository regulationRepository
            )
        {
            _regulationTypeRepository = regulationTypeRepository;
            _regulationRepository = regulationRepository;
        }

        // GET: Regulations
        public async Task<IActionResult> Index()
        {
            var regulations = new RegulationsVM();
            regulations.Regulations = await _regulationRepository.GetAllRegulations();
            regulations.RegulationsGraphChartVM = RegulationsDataGraphExtension.GetDataForGraphChart(regulations.Regulations);
            return View(regulations);
        }

        public async Task<IActionResult> Create()
        {
            var regulations = new RegulationCreateVM { RegulationTypes = await _regulationTypeRepository.GetAll()
                .ContinueWith(x => x.Result.OrderBy(y => y.Name)) };
            return View(regulations);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegulationCreateVM regulations)
        {
            regulations.RegulationTypes = await _regulationTypeRepository.GetAll();
            if (ModelState.IsValid)
            {
                await _regulationRepository.Create(regulations.Regulation);
                return RedirectToAction(nameof(Index));

            }
            return View(regulations);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var regulation = await _regulationRepository.FindById((int)id);

            if (id == null || regulation == null)
            {
                return NotFound();
            }
            var regulationVM = new RegulationCreateVM { RegulationTypes = await _regulationTypeRepository.GetAll(), Regulation = regulation };
            return View(regulationVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RegulationCreateVM regulationVM)
        {
            regulationVM.RegulationTypes = await _regulationTypeRepository.GetAll();
            if (ModelState.IsValid)
            {
                await _regulationRepository.Update(regulationVM.Regulation);
                return RedirectToAction(nameof(Index));
            }

            return View(regulationVM);
        }


        public async Task<IActionResult> Details(int id)
        {
            var vmModel = new RegulationCreateVM();
            vmModel.Regulation = await _regulationRepository.FindRegulationById(id);

            if (vmModel.Regulation == null)
            {
                return NotFound();
            }
            return PartialView("_RegulationDetails", vmModel);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRegulation(int id)
        {
            var regulation = await _regulationRepository.FindById(id);
            if (regulation == null)
            {
                return NotFound();
            }

            await _regulationRepository.Delete(regulation.Id);
            return Ok();
        }

        public async Task<IActionResult> ArchiveRegulations(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regulation = await _regulationRepository.FindById((int)id);

            if (regulation != null)
            {
                regulation.DateArchived = DateTime.Now.ToLocalTime();
                await _regulationRepository.Update(regulation);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }

        }

        public async Task<IActionResult> UnArchiveRegulations(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regulation = await _regulationRepository.FindById((int)id);

            if (regulation != null)
            {
                regulation.DateArchived = null;
                await _regulationRepository.Update(regulation);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }

        }
    }
}
