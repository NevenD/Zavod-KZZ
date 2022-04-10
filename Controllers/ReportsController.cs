using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using ZAVOD_KZZ.Core.ViewModels.Reports;
using ZAVOD_KZZ.Data.Repositories;
using ZAVOD_KZZ.Helpers.Reports;
using ZAVOD_KZZ.Helpers.Translations;
using ZAVOD_KZZ.Services.Azure.Helpers;
using ZAVOD_KZZ.Services.Azure.Interfaces;

namespace ZAVOD_KZZ.Controllers
{
    public class ReportsController : Controller
    {


        #region DI
        private readonly IRoadsRepository _roadsRepository;
        private readonly IRoadsCategoryRepository _roadsCategoryRepository;
        private readonly IRoadsLocalGovermentRepository _roadsLocalGovermentRepository;
        private readonly ILocalGovernmentAdministrationRepository _localGovernmentAdministrationRepository;
        private readonly ISpatialPlanDocumentRepository _spatialPlanDocumentRepository;
        private readonly ISpatialPlanLevelRepository _spatialPlanLevelRepository;
        private readonly ISpatialMeasureRepository _spatialMeasureRepository;
        private readonly ISpatialPlannerRepository _spatialPlannerRepository;
        private readonly ISpatialProjectionRepository _spatialProjectionRepository;
        private readonly ISpatialPlanDeliveryRepository _spatialPlanDeliveryRepository;
        private readonly IConservationDocumentRepository _conservationDocumentRepository;
        private readonly ISpuoPuoDocumentRepository _spuoPuoDocumentRepository;
        private readonly ISpatialPlanStatusRepository _spatialPlanStatusRepository;
        private readonly IRailroadsRepository _railroadsRepository;
        private readonly IRailroadCategoryRepository _railroadCategoryRepository;
        private readonly IRailroadLocalGovermentRepository _railroadLocalGovermentRepository;
        private readonly INaturalChangePopulationRepository _naturalChangePopulationRepository;
        private readonly IDocumentStatusZaraRepository _documentStatusZaraRepository;
        private readonly IOfficialDocumentZaraRepository _officialDocumentZaraRepository;
        private readonly IBlobService _blobService;
        public ReportsController(
            IRoadsRepository roadsRepository,
            IRoadsCategoryRepository roadsCategoryRepository,
            ILocalGovernmentAdministrationRepository localGovernmentAdministration,
            IRoadsLocalGovermentRepository roadsLocalGovermentRepository,
            ISpatialPlanDocumentRepository spatialPlanDocumentRepository,
            ILocalGovernmentAdministrationRepository localGovernmentAdministrationRepository,
            ISpatialPlanLevelRepository spatialPlanLevelRepository,
            ISpatialPlanRevisionRepository spatialPlanRevisionRepository,
            ISpatialMeasureRepository spatialMeasureRepository,
            IOfficialSpatialNewsNumberRepository officialSpatialNewsNumberRepository,
            ISpatialPlannerRepository spatialPlannerRepository,
            ISpatialProjectionRepository spatialProjectionRepository,
            ISpatialPlanDeliveryRepository spatialPlanDeliveryRepository,
            IConservationDocumentRepository conservationDocumentRepository,
            ISpuoPuoDocumentRepository spuoPuoDocumentRepository,
            ISpatialPlanStatusRepository spatialPlanStatusRepository,
            IRailroadsRepository railroadsRepository,
            IRailroadLocalGovermentRepository railroadLocalGovermentRepository,
            IRailroadCategoryRepository railroadCategoryRepository,
            INaturalChangePopulationRepository naturalChangePopulationRepository,
            IOfficialDocumentZaraRepository officialDocumentZaraRepository,
            IDocumentStatusZaraRepository documentStatusZaraRepository,
            IBlobService blobService
            )
        {
            _railroadsRepository = railroadsRepository;
            _localGovernmentAdministrationRepository = localGovernmentAdministration;
            _roadsRepository = roadsRepository;
            _spatialPlanDocumentRepository = spatialPlanDocumentRepository;
            _roadsCategoryRepository = roadsCategoryRepository;
            _roadsLocalGovermentRepository = roadsLocalGovermentRepository;
            _spatialPlanDocumentRepository = spatialPlanDocumentRepository;
            _localGovernmentAdministrationRepository = localGovernmentAdministrationRepository;
            _spatialPlanLevelRepository = spatialPlanLevelRepository;
            _spatialMeasureRepository = spatialMeasureRepository;
            _spatialPlannerRepository = spatialPlannerRepository;
            _spatialProjectionRepository = spatialProjectionRepository;
            _spatialPlanDeliveryRepository = spatialPlanDeliveryRepository;
            _conservationDocumentRepository = conservationDocumentRepository;
            _spuoPuoDocumentRepository = spuoPuoDocumentRepository;
            _spatialPlanStatusRepository = spatialPlanStatusRepository;
            _railroadCategoryRepository = railroadCategoryRepository;
            _railroadLocalGovermentRepository = railroadLocalGovermentRepository;
            _naturalChangePopulationRepository = naturalChangePopulationRepository;
            _officialDocumentZaraRepository = officialDocumentZaraRepository;
            _documentStatusZaraRepository = documentStatusZaraRepository;
            _blobService = blobService;
        }
        #endregion

        #region RoadsViews
        public async Task<IActionResult> RoadsReport()
        {
            var roadsReportVM = new RoadsReportVM();
            roadsReportVM.RoadCategories = await _roadsCategoryRepository.GetAll();
            return View(roadsReportVM);
        }


        public async Task<IActionResult> RoadsLocalGovernmentReport()
        {
            var roadsReportVM = new RoadsReportVM();
            roadsReportVM.RoadCategories = await _roadsCategoryRepository.GetAll();
            roadsReportVM.LocalGovernmentAdministrations = await _localGovernmentAdministrationRepository.GetAll();
            return View(roadsReportVM);
        }
        #endregion

        #region NaturalChangeView
        public async Task<IActionResult> NaturalChangeReport()
        {
            var naturalChange = new NaturalChangeReportVM
            {
                Years = Enumerable.Range(1989, DateTime.Now.Year - 1989 + 1).OrderByDescending(x => x),
                LocalGovernmentAdministrations = await _localGovernmentAdministrationRepository.GetAll()
            };
            return View(naturalChange);
        } 
        #endregion

        #region RailroadsViews
        public async Task<IActionResult> RailroadsReport()
        {
            var railroadsReportVM = new RailroadsReportVM();
            railroadsReportVM.RailroadCategories = await _railroadCategoryRepository.GetAll();
            return View(railroadsReportVM);
        }



        public async Task<IActionResult> RailroadsLocalGovernmentReport()
        {
            var railroadsReportVM = new RailroadsReportVM();
            railroadsReportVM.RailroadCategories = await _railroadCategoryRepository.GetAll();
            railroadsReportVM.LocalGovernmentAdministrations = await _localGovernmentAdministrationRepository.GetAll();
            return View(railroadsReportVM);
        }
        #endregion

        #region SpatialPlansViews
        public async Task<IActionResult> SpatialPlansReport()
        {
            var spatialDocument = new SpatialDocumentsReportVM();
            spatialDocument.SpatialPlanLevels = await _spatialPlanLevelRepository.GetAll();
            spatialDocument.LocalGovernmentAdministrations = await _localGovernmentAdministrationRepository.GetAll();
            spatialDocument.SpatialMeasures = await _spatialMeasureRepository.GetAll();
            spatialDocument.SpatialPlanners = await _spatialPlannerRepository.GetAll();
            spatialDocument.SpatialPlanStatuses = await _spatialPlanStatusRepository.GetAll();
            spatialDocument.Years = Enumerable.Range(1980, 100).OrderByDescending(x => x);


            return View(spatialDocument);
        }



        #endregion


        #region ZARAViews

        public async Task<IActionResult> OfficialDocumentZaraReport()
        {
            var naturalChange = new OfficialDocumentZaraViewReportVM
            {
                Years = Enumerable.Range(1989, DateTime.Now.Year - 1989 + 1).OrderByDescending(x => x),
                DocumentStatusZara = await _documentStatusZaraRepository.GetAll()
            };
            return View(naturalChange);
        } 
        #endregion



        #region RoadsReports
        [HttpGet]
        public async Task<IActionResult> GetRoads(int categoryId)
        {
            var roads = await _roadsRepository.GetRoadsByCategoryId(categoryId);
            var documentName = string.Format("Ceste-KZZ_{0}.xlsx", DateTime.Now.ToShortDateString());
            var reportResult = ReportHelper.RoadsReport(roads);

            return File(reportResult, "application/vnd.ms-excel", documentName);
        }

        [HttpGet]
        public async Task<IActionResult> GetRoadsByLocalGovernment(int categoryId, int localGovernmentId)
        {
            var roadsByLocalGovernment = await _roadsLocalGovermentRepository.GetRoadsInLocalGovernmentByRoadCategoryId(categoryId, localGovernmentId);
            var localGovernment = await _localGovernmentAdministrationRepository.FindLocalGovernmentById(localGovernmentId)
                .ContinueWith(x => x.Result == null ? TranslationsLabels.All : x.Result.Name);

            var documentName = string.Format("Ceste-KZZ-{0}_{1}.xlsx", localGovernment, DateTime.Now.ToShortDateString());
            var reportResult = ReportHelper.RoadsByLocalGovernmentReport(roadsByLocalGovernment);

            return File(reportResult, "application/vnd.ms-excel", documentName);
        }
        #endregion

        #region SpatialPlansReports
        public async Task<IActionResult> GetSpatialPlans(SpatialPlanReport spatialPlanReport)
        {
            var localGovernment = await _localGovernmentAdministrationRepository.FindLocalGovernmentById(spatialPlanReport.LocalGovernmentReportId)
                .ContinueWith(x => x.Result == null ? TranslationsLabels.All : x.Result.Name);

            var spatialPlans = await _spatialPlanDocumentRepository.GetSpatialPlansByReportParameters(spatialPlanReport);
            var reportResult = ReportHelper.SpatialPlansReport(spatialPlans);

            var documentName = string.Format("Prostorni_planovi-KZZ-{0}_{1}.xlsx", localGovernment, DateTime.Now.ToShortDateString());
            return File(reportResult, "application/vnd.ms-excel", documentName);
        }
        #endregion

        #region RailroadsReports

        [HttpGet]
        public async Task<IActionResult> GetRailoads(int railroadCategoryId)
        {
            var railroads = await _railroadsRepository.GetRailroadsByCategoryId(railroadCategoryId);
            var documentName = string.Format("Željeznica-KZZ_{0}.xlsx", DateTime.Now.ToShortDateString());
            var reportResult = ReportHelper.RailoadsReport(railroads);

            return File(reportResult, "application/vnd.ms-excel", documentName);
        }

        [HttpGet]
        public async Task<IActionResult> GetRailroadsByLocalGovernment(int railroadCategoryId, int localGovernmentId)
        {
            var railroadsByLocalGovernment = await _railroadLocalGovermentRepository.GetRailroadsInLocalGovernmentByRailroadCategoryId(railroadCategoryId, localGovernmentId);
            var localGovernment = await _localGovernmentAdministrationRepository.FindLocalGovernmentById(localGovernmentId)
                .ContinueWith(x => x.Result == null ? TranslationsLabels.All : x.Result.Name);

            var documentName = string.Format("Željeznice-KZZ-{0}_{1}.xlsx", localGovernment, DateTime.Now.ToShortDateString());
            var reportResult = ReportHelper.RailroadsByLocalGovernmentReport(railroadsByLocalGovernment);

            return File(reportResult, "application/vnd.ms-excel", documentName);
        }
        #endregion

        #region NaturalChangeReports
        [HttpGet]
        public async Task<IActionResult> GetNaturalChangeByLocalGovernment(int naturalChangeYear, int localGovernmentId)
        {
            var naturalChangeByLocalGovernment = await _naturalChangePopulationRepository.GetNaturalChangeByYearAndLocalGovernmentId(naturalChangeYear, localGovernmentId);
            var localGovernment = await _localGovernmentAdministrationRepository.FindLocalGovernmentById(localGovernmentId)
                .ContinueWith(x => x.Result == null ? TranslationsLabels.All : x.Result.Name);

            var documentName = string.Format("Prirodni_prirast-KZZ-{0}_{1}.xlsx", localGovernment, DateTime.Now.ToShortDateString());
            var reportResult = ReportHelper.NaturalChangeReport(naturalChangeByLocalGovernment);

            return File(reportResult, "application/vnd.ms-excel", documentName);
        }
        #endregion


        [HttpGet]
        public async Task<IActionResult> GetOfficialDocumentsZara(int documentYear, int documentStatusId)
        {
            var officialDocumentsZara = await _officialDocumentZaraRepository.GetOfficialDocumentsByYearAndStatusId(documentYear, documentStatusId);
            var documentsReport = new List<OfficialDocumentZaraReportVM>();


            foreach (var item in officialDocumentsZara)
            {
                var officialDocument = new OfficialDocumentZaraReportVM
                {
                    Name = item.Name,
                    ShortName = item.ShortName,
                    DocumentType = item.DocumentTypeZara.Name,
                    DocumentStatus = item.DocumentStatusZara.Name,
                    OfficialNews = item.OfficalSpatialNews.Name,
                    OfficialNewsNumber = item.OfficialSpatialNewsNumber,
                    OfficialNewsUrl = item.OfficialSpatialNewsNumberUrl,
                    DateEffective = item.DocumentEffectiveDate.HasValue ? item.DocumentEffectiveDate.Value.ToShortDateString() : string.Empty,
                    DateIneffective = item.DocumentIneffectiveDate.HasValue ? item.DocumentIneffectiveDate.Value.ToShortDateString() : string.Empty,
                    RequiredDocumentsZara = await _blobService.GetBlobDocumentsByMetadataId(item.Id.ToString(), AzureStorageHelpers.BlobContainers.RequiredDocuments),
                    AdditionalDocumentsZara = await _blobService.GetBlobDocumentsByMetadataId(item.Id.ToString(), AzureStorageHelpers.BlobContainers.AdditionalDocuments),
                    DocumentRemark = item.DocumentRemark
                };

                documentsReport.Add(officialDocument);
            }

            var documentName = string.Format("Popis akata_{0}.xlsx",  DateTime.Now.ToShortDateString());
            var reportResult = ReportHelper.OfficialDocumentsZaraReport(documentsReport);

            return File(reportResult,"application/vnd.ms-excel", documentName);
        }
    }
}