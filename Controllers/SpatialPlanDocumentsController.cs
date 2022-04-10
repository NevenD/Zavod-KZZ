using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZAVOD_KZZ.Data.Repositories;
using ZAVOD_KZZ.Core.ViewModels;
using Microsoft.AspNetCore.Hosting;
using static ZAVOD_KZZ.Helpers.Enums.Enums;
using ZAVOD_KZZ.Helpers.StatisticsExtensions;
using Microsoft.AspNetCore.Authorization;
using ZAVOD_KZZ.Helpers.Enums;
using System.Linq;

namespace ZAVOD_KZZ.Controllers
{
    [Authorize]
    public class SpatialPlanDocumentsController : Controller
    {
        #region DI repositories
        private readonly ISpatialPlanDocumentRepository _spatialPlanDocumentRepository;
        private readonly ILocalGovernmentAdministrationRepository _localGovernmentAdministrationRepository;
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

        private readonly IHostingEnvironment _hostingEnvironment;

        public SpatialPlanDocumentsController(
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
            IHostingEnvironment hostingEnvironment
            )
        {
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
            _hostingEnvironment = hostingEnvironment;
        }
        #endregion

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var spatialPlanDocumentsVM = new SpatialPlanDocumentViewVM();
            spatialPlanDocumentsVM.LocalGovernmentAdministrations = await _localGovernmentAdministrationRepository.GetAll();
            spatialPlanDocumentsVM.SpatialPlanDocuments = await _spatialPlanDocumentRepository.GetAllSpatialPlanDocuments();
            spatialPlanDocumentsVM.Regulations = await _regulationRepository.GetAllRegulations().ContinueWith(x => x.Result.Where(y => y.IsSpatialDocumentRegulation == true).ToList());
            return View(spatialPlanDocumentsVM);
        }


        public async Task<IActionResult> Create()
        {
            var vmModel = new SpatialPlanDocumentVM()
            {
                LocalGovernmentAdministrations = await _localGovernmentAdministrationRepository.GetAll(),
                SpatialPlanLevels = await _spatialPlanLevelRepository.GetAll(),
                SpatialPlanRevisions = await _spatialPlanRevisionRepository.GetAll(),
                SpatialMeasures = await _spatialMeasureRepository.GetAll(),
                OfficalSpatialNews = await _officialSpatialNewsNumberRepository.GetAll(),
                SpatialPlanners = await _spatialPlannerRepository.GetAll(),
                SpatialProjections = await _spatialProjectionRepository.GetAll(),
                SpatialPlanDeliveries = await _spatialPlanDeliveryRepository.GetAll(),
                ConservationDocuments = await _conservationDocumentRepository.GetAll(),
                SpuoPuoDocuments = await _spuoPuoDocumentRepository.GetAll(),
                SpatialPlanStatuses = await _spatialPlanStatusRepository.GetAll()
            };

            return View(vmModel);
        }

        [HttpPost, ActionName(nameof(Create))]
        [ValidateAntiForgeryToken]
        [RequestSizeLimit((long)AdditionalDocumentSize.MB_700)]
        public async Task<IActionResult> CreatePlan(SpatialPlanDocumentVM vmModel) {

            if (ModelState.IsValid)
            {
                await _spatialPlanDocumentRepository.Create(vmModel.SpatialPlanDocument);

                if (vmModel.Files != null)
                {
                    await _spatialPlanAdditionalDocumentsRepository.AddDocument(vmModel.Files, _hostingEnvironment.WebRootPath, vmModel.SpatialPlanDocument.Id);
                }
                
                return RedirectToAction(nameof(DashBoardController.AddingSpatialPlans), "DashBoard");
            }

            return View(vmModel);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {

            var detailsVM = new SpatialPlanDocumentDetailsVM();

            if (id == null)
            {
                return NotFound();
            }
             detailsVM.SpatialPlanDocument = await _spatialPlanDocumentRepository.FindById((int)id);
            if (detailsVM.SpatialPlanDocument != null)
            {
                detailsVM.LocalAdministrationName = _localGovernmentAdministrationRepository.FindById(detailsVM.SpatialPlanDocument.LocalGovernmentAdministrationId)
                    .GetAwaiter().GetResult().Name;

                detailsVM.SpatialPlanLevelName = _spatialPlanLevelRepository.FindById(detailsVM.SpatialPlanDocument.SpatialPlanLevelId)
                    .GetAwaiter().GetResult().ShortName;

                detailsVM.SpatialPlanRevision = _spatialPlanRevisionRepository.FindById(detailsVM.SpatialPlanDocument.SpatialPlanRevisionId)
                    .GetAwaiter().GetResult().RevisionStatus;

                detailsVM.SpatialMeasure = _spatialMeasureRepository.FindById(detailsVM.SpatialPlanDocument.SpatialMeasureId)
                    .GetAwaiter().GetResult().Name;

                detailsVM.OfficialSpatialNewsName = _officialSpatialNewsNumberRepository.FindById(detailsVM.SpatialPlanDocument.OfficalSpatialNewsId)
                     .GetAwaiter().GetResult().ShortName;

                detailsVM.SpatialPlannerName = _spatialPlannerRepository.FindById(detailsVM.SpatialPlanDocument.SpatialPlannerId)
                    .GetAwaiter().GetResult().Name;

                detailsVM.SpatialProjectionName = _spatialProjectionRepository.FindById(detailsVM.SpatialPlanDocument.SpatialProjectionId)
                    .GetAwaiter().GetResult().ShortName;

                detailsVM.SpatialPlanDeliveryName = _spatialPlanDeliveryRepository.FindById(detailsVM.SpatialPlanDocument.SpatialPlanDeliveryId)
                    .GetAwaiter().GetResult().DeliveryStatus;

                detailsVM.SpuoPuoDocumentStatus = _spuoPuoDocumentRepository.FindById(detailsVM.SpatialPlanDocument.SpuoPuoDocumentId)
                    .GetAwaiter().GetResult().Name;

                detailsVM.SpatialPlanStatusName = _spatialPlanStatusRepository.FindById(detailsVM.SpatialPlanDocument.SpatialPlanStatusId)
                    .GetAwaiter().GetResult().Name;

                detailsVM.ConservationName = _conservationDocumentRepository.FindById(detailsVM.SpatialPlanDocument.ConservationDocumentId)
                    .GetAwaiter().GetResult().ValidationStatus;

                detailsVM.SpatialPlanAdditionalDocuments = await _spatialPlanAdditionalDocumentsRepository.GetAdditionalDocumentsBySpatialPlanId(detailsVM.SpatialPlanDocument.Id);

                return PartialView("_PlanDetails", detailsVM);

            }
            else {
                return NotFound();
            }
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spatialDocument = await _spatialPlanDocumentRepository.FindById((int)id);
            if (spatialDocument != null)
            {

                var vmModel = new SpatialPlanDocumentEditVM()
                {
                    SpatialPlanDocument = spatialDocument,
                    LocalGovernmentAdministrations = await _localGovernmentAdministrationRepository.GetAll(),
                    SpatialPlanLevels = await _spatialPlanLevelRepository.GetAll(),
                    SpatialPlanRevisions = await _spatialPlanRevisionRepository.GetAll(),
                    SpatialMeasures = await _spatialMeasureRepository.GetAll(),
                    OfficalSpatialNews = await _officialSpatialNewsNumberRepository.GetAll(),
                    SpatialPlanners = await _spatialPlannerRepository.GetAll(),
                    SpatialProjections = await _spatialProjectionRepository.GetAll(),
                    SpatialPlanDeliveries = await _spatialPlanDeliveryRepository.GetAll(),
                    ConservationDocuments = await _conservationDocumentRepository.GetAll(),
                    SpuoPuoDocuments = await _spuoPuoDocumentRepository.GetAll(),
                    SpatialPlanStatuses = await _spatialPlanStatusRepository.GetAll(),
                    AdditionalDocuments = await _spatialPlanAdditionalDocumentsRepository.GetAdditionalDocumentsBySpatialPlanId(spatialDocument.Id)
                };

                return View(vmModel);

            }
            else
            {
                return NotFound();

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestSizeLimit((long)AdditionalDocumentSize.MB_700)]
        public async Task<IActionResult> Edit(SpatialPlanDocumentVM vmModel)
        {
            if (ModelState.IsValid)
            {
                await _spatialPlanDocumentRepository.Update(vmModel.SpatialPlanDocument);

                if (vmModel.Files != null)
                {

                    await _spatialPlanAdditionalDocumentsRepository.AddDocument(vmModel.Files, _hostingEnvironment.WebRootPath, vmModel.SpatialPlanDocument.Id);

                }

                return RedirectToAction(nameof(DashBoardController.AddingSpatialPlans), "DashBoard");
            }

            return View(vmModel);
        }

        public async Task<IActionResult> ArchiveSpatialPlan(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spatialPlanner = await _spatialPlanDocumentRepository.FindById((int)id);

            if (spatialPlanner != null)
            {
                spatialPlanner.DateArchived = DateTime.Now.ToLocalTime();
                await _spatialPlanDocumentRepository.Update(spatialPlanner);

                return RedirectToAction(nameof(DashBoardController.AddingSpatialPlans), "DashBoard");
            }
            else
            {
                return NotFound();
            }

        }

        public async Task<IActionResult> UnArchiveSpatialPlan(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spatialPlanner = await _spatialPlanDocumentRepository.FindById((int)id);

            if (spatialPlanner != null)
            {
                spatialPlanner.DateArchived = null;
                await _spatialPlanDocumentRepository.Update(spatialPlanner);

                return RedirectToAction(nameof(DashBoardController.AddingSpatialPlans), "DashBoard");
            }
            else
            {
                return NotFound();
            }

        }

    }
}