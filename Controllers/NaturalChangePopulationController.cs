using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using ZAVOD_KZZ.Core.Models;
using ZAVOD_KZZ.Core.ViewModels.Population;
using ZAVOD_KZZ.Data.Repositories;
using ZAVOD_KZZ.Helpers.Extensions;
using ZAVOD_KZZ.Helpers.StatisticsExtensions;
using ZAVOD_KZZ.Helpers.Translations;

namespace ZAVOD_KZZ.Controllers
{
    [Authorize]
    public class NaturalChangePopulationController : Controller
    {
        private readonly ILocalGovernmentAdministrationRepository _localGovernmentAdministrationRepository;
        private readonly INaturalChangePopulationRepository _naturalChangePopulationRepository;
        private readonly IHostingEnvironment _hostingEnvironment;

        public NaturalChangePopulationController(
            ILocalGovernmentAdministrationRepository localGovernmentAdministrationRepository,
            INaturalChangePopulationRepository naturalChangePopulation,
            IHostingEnvironment hostingEnvironment
            )
        {
            _localGovernmentAdministrationRepository = localGovernmentAdministrationRepository;
            _naturalChangePopulationRepository = naturalChangePopulation;
            _hostingEnvironment = hostingEnvironment;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var naturalChange = new NaturalChangeVM();
            naturalChange.LocalGovernmentAdministrations = await _localGovernmentAdministrationRepository.GetAll();
            naturalChange.NaturalChangePopulation = await _naturalChangePopulationRepository.GetAllNaturalChangePopulation();
            naturalChange.NaturalChangeByYear = PopulationDataExtension.GetNaturalChangeGroupedByYear(naturalChange.NaturalChangePopulation);
            naturalChange.NaturalChangeGraphData = PopulationDataExtension.GetPopulationChangeLineChartData(naturalChange.NaturalChangePopulation);
            naturalChange.NaturalChangePopulationByLocalAdministration = PopulationDataExtension.FilterNaturalChangeByRecentYear(naturalChange.NaturalChangePopulation);

            return View(naturalChange);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReadExcelData(IFormFile file)
        {

            string fileExtension = Path.GetExtension(file?.FileName);

            try
            {
                if (fileExtension == ".xls" || fileExtension == ".xlsx" || fileExtension == ".csv")
                {

                    var rootFolder = Path.Combine(_hostingEnvironment.WebRootPath, "upload");

                    if (!Directory.Exists(rootFolder))
                    {
                        Directory.CreateDirectory(rootFolder);
                    }

                    var fileName = file.FileName;
                    var filePath = Path.Combine(rootFolder, fileName);
                    var fileLocation = new FileInfo(filePath);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    using (ExcelPackage package = new ExcelPackage(fileLocation))
                    {

                        ExcelWorksheet workSheet = package.Workbook.Worksheets.FirstOrDefault();
                        int totalRows = workSheet.Dimension.Rows;

                        var populationChange = new List<NaturalChangePopulation>();

                        for (int i = 2; i <= totalRows; i++)
                        {
                            var name = workSheet.Cells[i, 1].Value != null ? StringHelpers.RemoveDash(workSheet.Cells[i, 1].Value.ToString().TrimStart()): string.Empty;
                            var year = int.TryParse(workSheet.Cells[i, 2].Value.ToString(), out _) ? int.Parse(workSheet.Cells[i, 2].Value.ToString()) : 0;
                            var localGovernment = await _localGovernmentAdministrationRepository.FindLocalGovernmentByName(name);


                            // chech if entry exists for that jls name and year
                            var naturalChange = await _naturalChangePopulationRepository.FindByLocalGovernmentNameAndYear(name, year);

                            if (naturalChange == null && year != 0 && localGovernment != null)
                            {
                                populationChange.Add(new NaturalChangePopulation
                                {
                                    LocalGovernmentAdministrationID = localGovernment.Id,
                                    Year = year,
                                    LiveBirth = int.TryParse(workSheet.Cells[i, 3].Value.ToString(), out _) ? int.Parse(workSheet.Cells[i, 3].Value.ToString()) : 0,
                                    StillBirth = int.TryParse(workSheet.Cells[i, 4].Value.ToString(), out _) ? int.Parse(workSheet.Cells[i, 4].Value.ToString()) : 0,
                                    Death = int.TryParse(workSheet.Cells[i, 5].Value.ToString(), out _) ? int.Parse(workSheet.Cells[i, 5].Value.ToString()) : 0,
                                    InfantDeath = int.TryParse(workSheet.Cells[i, 6].Value.ToString(), out _) ? int.Parse(workSheet.Cells[i, 6].Value.ToString()) : 0
                                });
                            }
                        }

                        foreach (var population in populationChange)
                        {
                            await _naturalChangePopulationRepository.Create(population);
                        }
                    }

                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Create()
        {
            var naturalChange = new CreateNaturalChangeVM
            {
                Years = Enumerable.Range(1989, DateTime.Now.Year - 1989 + 1).OrderByDescending(x => x),
                LocalGovernmentAdministrations = await _localGovernmentAdministrationRepository.GetAllLocalGovernments()

            };
            return View(naturalChange);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateNaturalChangeVM naturalChange)
        {
            naturalChange.LocalGovernmentAdministrations = await _localGovernmentAdministrationRepository.GetAllLocalGovernments();
            naturalChange.Years = Enumerable.Range(1989, DateTime.Now.Year - 1989 + 1).OrderByDescending(x => x);

            var nameLocalGovernment = await _localGovernmentAdministrationRepository.FindLocalGovernmentById(naturalChange.NaturalChangePopulation.LocalGovernmentAdministrationID);
            var localGovernment = await _localGovernmentAdministrationRepository.FindLocalGovernmentByName(nameLocalGovernment.Name);
            var naturalChangeSave = await _naturalChangePopulationRepository.FindByLocalGovernmentNameAndYear(nameLocalGovernment.Name, naturalChange.NaturalChangePopulation.Year);

            // chech if entry exists for that jls name and year
            if (ModelState.IsValid && naturalChangeSave == null && localGovernment != null)
            {
                await _naturalChangePopulationRepository.Create(naturalChange.NaturalChangePopulation);
                return Json(new  { Year = naturalChange.NaturalChangePopulation.Year, LocalGovernmentName = localGovernment.Name });
            }
            naturalChange.ErrorMsg = TranslationsLabels.ErrorMessageNaturalChangeAdd;
            return Json(new { Error = naturalChange.ErrorMsg });
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var naturalChangeById = await _naturalChangePopulationRepository.NaturalChangeByLocalGovernmentId((int)id);

            if (id == null || naturalChangeById == null)
            {
                return NotFound();
            }
            var editNaturalChange = new CreateNaturalChangeVM
            {
                Years = Enumerable.Range(1989, DateTime.Now.Year - 1989 + 1).ToList(),
                LocalGovernmentAdministrations = await _localGovernmentAdministrationRepository.GetAllLocalGovernments(),
                NaturalChangePopulation = naturalChangeById
               
            };
            return View(editNaturalChange);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateNaturalChangeVM naturalChange)
        {
  
            if (ModelState.IsValid)
            {
                await _naturalChangePopulationRepository.Update(naturalChange.NaturalChangePopulation);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Edit), "NaturalChangePopulation", new { id = naturalChange.NaturalChangePopulation.Id });
        }


        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var naturalChange = new NaturalChangeVM();
            naturalChange.LocalGovernmentAdministration = await _localGovernmentAdministrationRepository.FindById(id);
            naturalChange.NaturalChangePopulation = await _naturalChangePopulationRepository.GetNaturalChangeByLocalGovernmentId(id);
            naturalChange.NaturalChangeByYear = PopulationDataExtension.GetNaturalChangeGroupedByYear(naturalChange.NaturalChangePopulation);
            naturalChange.NaturalChangeGraphData = PopulationDataExtension.GetPopulationChangeLineChartData(naturalChange.NaturalChangePopulation);


            if (naturalChange.NaturalChangePopulation == null)
            {
                return NotFound();
            }
            return PartialView("_NaturalChangeDetails", naturalChange);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteNaturalChange(int id)
        {

            var naturalChange = await _naturalChangePopulationRepository.FindById(id);
            if (naturalChange == null)
            {
                return NotFound();
            }

            await _naturalChangePopulationRepository.Delete(naturalChange.Id);
            return Ok();
        }
    }
}