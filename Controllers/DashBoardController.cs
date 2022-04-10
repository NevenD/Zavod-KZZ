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
using ZAVOD_KZZ.Services.Azure.Interfaces;

namespace ZAVOD_KZZ.Controllers
{
    [Authorize]
    public class DashBoardController : Controller
    {
        #region DI
        private readonly IRoadsRepository _roadsRepository;
        private readonly ILocalGovernmentAdministrationRepository _localGovernmentAdministrationRepository;
        private readonly ISpatialPlanDocumentRepository _spatialPlanDocumentRepository;
        private readonly ISpatialPlanLevelRepository _spatialPlanLevelRepository;
        private readonly ISpatialPlanRevisionRepository _spatialPlanRevisionRepository;
        private readonly ISpatialMeasureRepository _spatialMeasureRepository;
        private readonly IOfficialSpatialNewsNumberRepository _officialSpatialNewsNumberRepository;
        private readonly ISpatialPlannerRepository _spatialPlannerRepository;
        private readonly ISpatialProjectionRepository _spatialProjectionRepository;
        private readonly ISpatialPlanDeliveryRepository _spatialPlanDeliveryRepository;
        private readonly IConservationDocumentRepository _conservationDocumentRepository;
        private readonly ISpuoPuoDocumentRepository _spuoPuoDocumentRepository;
        private readonly ISpatialPlanStatusRepository _spatialPlanStatusRepository;
        private readonly ISpatialPlanAdditionalDocumentsRepository _spatialPlanAdditionalDocumentsRepository;
        private readonly IRegulationRepository _regulationRepository;
        private readonly IRailroadCategoryRepository _railroadCategoryRepository;
        private readonly IOfficialDocumentZaraRepository _officialDocumentZaraRepositor;
        private readonly INaturalChangePopulationRepository _naturalChangePopulationRepository;
        private readonly IBlobService _blobService;

        public DashBoardController(
            IRoadsRepository roadsRepository,
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
            ISpatialPlanAdditionalDocumentsRepository spatialPlanAdditionalDocumentsRepository,
            IRegulationRepository regulationRepository,
            IRailroadCategoryRepository railroadCategoryRepository,
            IOfficialDocumentZaraRepository officialDocumentZaraRepository,
            INaturalChangePopulationRepository naturalChangePopulationRepository,
            IBlobService blobService
            )
        {
            _roadsRepository = roadsRepository;
            _spatialPlanDocumentRepository = spatialPlanDocumentRepository;
            _localGovernmentAdministrationRepository = localGovernmentAdministrationRepository;
            _spatialPlanLevelRepository = spatialPlanLevelRepository;
            _spatialPlanRevisionRepository = spatialPlanRevisionRepository;
            _spatialMeasureRepository = spatialMeasureRepository;
            _officialSpatialNewsNumberRepository = officialSpatialNewsNumberRepository;
            _spatialPlannerRepository = spatialPlannerRepository;
            _spatialProjectionRepository = spatialProjectionRepository;
            _spatialPlanDeliveryRepository = spatialPlanDeliveryRepository;
            _conservationDocumentRepository = conservationDocumentRepository;
            _spuoPuoDocumentRepository = spuoPuoDocumentRepository;
            _spatialPlanStatusRepository = spatialPlanStatusRepository;
            _spatialPlanAdditionalDocumentsRepository = spatialPlanAdditionalDocumentsRepository;
            _regulationRepository = regulationRepository;
            _railroadCategoryRepository = railroadCategoryRepository;
            _officialDocumentZaraRepositor = officialDocumentZaraRepository;
            _naturalChangePopulationRepository = naturalChangePopulationRepository;
            _blobService = blobService;
        }
        #endregion


        public async Task<IActionResult> Index()
        {
            var dashboard = new DashboardIndexVM();

            var roads = await _roadsRepository.GetAllRoads();
            dashboard.SpatialPlanDocuments = await _spatialPlanDocumentRepository.GetAllSpatialPlanDocuments();
            dashboard.RegulationsValidCount = await _regulationRepository.GetAll().ContinueWith(x =>x.Result.Where(y =>y.DateArchived == null).Count());
            dashboard.TotalPlans = dashboard.SpatialPlanDocuments.Where(x => x.SpatialPlanStatus.Id != (int)Enums.SpatialPlanStatus.INVALID).Count();
            dashboard.Regulations = await _regulationRepository.GetAllRegulations();
            var additionalDocuments = await _spatialPlanAdditionalDocumentsRepository.GetAll();
            dashboard.DocumentsCount = (additionalDocuments != null) ? additionalDocuments.Count() : 0;
            dashboard.DocumentsSize = (additionalDocuments != null) ? Math.Round(additionalDocuments.Sum(x => x.FileSizeInMb), 2) : 0;

            dashboard.DocumentSizeProgress = (dashboard.DocumentsSize.HasValue) ? Math.Round((((decimal)dashboard.DocumentsSize.Value / (int)Enums.DiskSize.GB_10)), 2) * 100 : 0;
            dashboard.Roads = roads.OrderBy(x =>x.DateAdded).Take(5);

            var railRoadsCount = await _railroadCategoryRepository.GetAll().ContinueWith(x => x.Result.Count());
            var roadsCount = roads.Count();
            dashboard.InfrastructureCount = railRoadsCount + roadsCount;
            dashboard.OfficialDocumentsZaraCount = await _officialDocumentZaraRepositor.GetAll().ContinueWith(x => x.Result.Count());

            var naturalChange = await _naturalChangePopulationRepository.GetAllNaturalChangePopulation(); ;
            dashboard.NaturalChangeByYear = PopulationDataExtension.GetNaturalChangeGroupedByYear(naturalChange);
            dashboard.Blobs = await _blobService.GetAllBlobs();
            return View(dashboard);
        }


        public async Task<IActionResult> SpatialPlansTableView()
        {
            var tableDashboard = new DashboardSpatialPlansTableVM();

            var deliveryStatus = new List<int>
            {
                (int)Enums.SpatialPlanDelivery.INCOMPLETE_ADDITIONAL_DOCUMENTS,
                (int)Enums.SpatialPlanDelivery.INCOMPLETE_CD,
                (int)Enums.SpatialPlanDelivery.INCOMPLETE_PART
            };


            tableDashboard.SpatialPlanDocuments = await _spatialPlanDocumentRepository.GetAllSpatialPlanDocuments();
            tableDashboard.TotalPlans = tableDashboard.SpatialPlanDocuments.Where(x => x.SpatialPlanStatus.Id != (int)Enums.SpatialPlanStatus.INVALID).Count();
            tableDashboard.PlansInvalid = tableDashboard.SpatialPlanDocuments.Where(x => x.SpatialPlanStatus.Id == (int)Enums.SpatialPlanStatus.INVALID).Count();
            tableDashboard.InProgressPlans = tableDashboard.SpatialPlanDocuments.Where(x => x.SpatialPlanStatus.Id == (int)Enums.SpatialPlanStatus.IN_PROGRESS).Count();
            tableDashboard.ValidPlans = tableDashboard.SpatialPlanDocuments.Where(x => x.SpatialPlanStatus.Id == (int)Enums.SpatialPlanStatus.VALID).Count();
            tableDashboard.PlansChanged = tableDashboard.SpatialPlanDocuments.Where(x => x.SpatialPlanRevision.Id == (int)Enums.SpatialRevisionStatus.CHANGED).Count();
            tableDashboard.PlansAfter2014 = tableDashboard.SpatialPlanDocuments.Where(x => x.SpatialPlanEnactmentDate.HasValue).Select(y => y.SpatialPlanEnactmentDate.Value.Year >= 2014).Count();
            tableDashboard.SpatialPlanAdditionalDocuments = await _spatialPlanAdditionalDocumentsRepository.GetAll();
            tableDashboard.Archived = tableDashboard.SpatialPlanDocuments.Where(x => x.DateArchived != null);
            tableDashboard.IncompletePlans = tableDashboard.SpatialPlanDocuments.Where(x => deliveryStatus.Contains(x.SpatialPlanDeliveryId));
            tableDashboard.PlansWithoutDocuments = tableDashboard.SpatialPlanDocuments.Where(x => x.SpatialPlanAdditionalDocuments.Count == 0);
            tableDashboard.SpatialPlansUndelivered = tableDashboard.SpatialPlanDocuments.Where(x => x.SpatialPlanDelivery.Id == (int)Enums.PlanDelivery.UNDELIVERED);
            tableDashboard.PlansFromActualYear = tableDashboard.SpatialPlanDocuments.Where(x => x.SpatialPlanEnactmentDate != null && (x.SpatialPlanEnactmentDate.Value.Year == DateTime.Now.Year));

            return View(tableDashboard);
        }

        public async Task<IActionResult> SpatialPlansGraphView()
        {
            var graphDashboard = new DashboardSpatialPlansGraphVM();

            var spatialPlans = await _spatialPlanDocumentRepository.GetAllSpatialPlanDocuments();
            graphDashboard.SpatialPlansLevelChartVM = SpatialDocumentGraphDataExtension.GetDataForPlanLevelChart(spatialPlans);
            graphDashboard.SpatialPlansLocalAdministrationChartVM = SpatialDocumentGraphDataExtension.GetDataForPlanLocalAdministrationChart(spatialPlans);
            graphDashboard.PlansPerYearLineChart = SpatialDocumentGraphDataExtension.GetDataForLineChart(spatialPlans);

            return View(graphDashboard);
        }

        public async Task<IActionResult> AddingSpatialPlans()
        {
            var addingPlans = new DashboardSpatialPlansTableVM();
            addingPlans.SpatialPlanDocuments = await _spatialPlanDocumentRepository.GetAllSpatialPlanDocuments();

            return View(addingPlans);
        }
    }
}