using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ZAVOD_KZZ.Core.Models;
using ZAVOD_KZZ.Core.ViewModels;
using ZAVOD_KZZ.Data;
using ZAVOD_KZZ.Data.Repositories;
using ZAVOD_KZZ.Helpers.StatisticsExtensions;

namespace ZAVOD_KZZ.Controllers
{

    [Authorize]
    public class SpatialPlannersController : Controller
    {

        private readonly ISpatialPlannerRepository _spatialPlannerRepository;
        private readonly ISpatialPlanDocumentRepository _spatialPlanDocumentRepository;

        public SpatialPlannersController(ISpatialPlannerRepository spatialPlanerRepository, ISpatialPlanDocumentRepository spatialPlanDocumentRepository)
        {
            _spatialPlannerRepository = spatialPlanerRepository;
            _spatialPlanDocumentRepository = spatialPlanDocumentRepository;
        }

        public async Task<IActionResult> Index()
        {
            var vmModel = new SpatialPlannersIndexVM();
            vmModel.SpatialPlanners = await _spatialPlannerRepository.GetAllSpatialPlannersWithSpatialDocuments();
            vmModel.PieChartData = SpatialPlannersDataExtension.GetDataForPieChart(vmModel.SpatialPlanners);
            return View(vmModel);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vmModel = new SpatialPlannersDetailsVM();
            vmModel.SpatialPlanner = await _spatialPlannerRepository.SingleOrDefault(x => x.Id == id);
            vmModel.SpatialPlanDocuments = await _spatialPlanDocumentRepository.GetSpatialDocumentsBySpatialPlannersId((int)id);

            if (vmModel.SpatialPlanner == null)
            {
                return NotFound();
            }
            return PartialView("_Details", vmModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpatialPlanner spatialPlanner)
        {
            if (ModelState.IsValid)
            {
                await _spatialPlannerRepository.Create(spatialPlanner);  
                return RedirectToAction(nameof(Index));
            }
            return View(spatialPlanner);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spatialPlanner = await _spatialPlannerRepository.FindById((int)id);
            if (spatialPlanner == null)
            {
                return NotFound();
            }
            return View(spatialPlanner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SpatialPlanner spatialPlanner)
        {
            if (ModelState.IsValid)
            {
                await _spatialPlannerRepository.Update(spatialPlanner);
                return RedirectToAction(nameof(Index));
            }

            return View(spatialPlanner);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteSpatialPlanners(int id)
        {

            var spatialPlanner = await _spatialPlannerRepository.FindById(id);
            if (spatialPlanner == null)
            {
                return NotFound();
            }

            await _spatialPlannerRepository.Delete(id);
            return Ok();
        }

     
    }
}
