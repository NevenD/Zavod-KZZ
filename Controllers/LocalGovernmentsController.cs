using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZAVOD_KZZ.Core.Models;
using ZAVOD_KZZ.Core.ViewModels;
using ZAVOD_KZZ.Data.Repositories;
using ZAVOD_KZZ.Helpers.StatisticsExtensions;

namespace ZAVOD_KZZ.Areas.LocalGovernment.Controllers
{
    [Authorize]
    public class LocalGovernmentsController : Controller
    {
        private readonly ILocalGovernmentAdministrationRepository _localGovernmentAdministrationRepository;
        private readonly ICommunityTypeRepository _communityTypeRepositoryRepository;
        private readonly ILocalGovernmentSettlementRepository _localGovernmentSettlementRepository;

        public LocalGovernmentsController(
            ILocalGovernmentAdministrationRepository localGovernmentRepository, 
            ICommunityTypeRepository communityTypeRepositoryRepository,
            ILocalGovernmentSettlementRepository localGovernmentSettlementRepository
            )
        {
            _localGovernmentAdministrationRepository = localGovernmentRepository;
            _communityTypeRepositoryRepository = communityTypeRepositoryRepository;
            _localGovernmentSettlementRepository = localGovernmentSettlementRepository;
        }


        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var localGovernmentAdministrationsVM = new LocalGovernmentIndexVM();
            localGovernmentAdministrationsVM.LocalGovernmentAdministrations = await _localGovernmentAdministrationRepository.GetAllLocalGovernments();
            localGovernmentAdministrationsVM.Settlements = await _localGovernmentSettlementRepository.GetAllSettlements();
            return View(localGovernmentAdministrationsVM);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            var localGovernmentVM = new LocalGovernmentAdministrationVM();
            if (id == null)
            {
                return NotFound();
            }

            localGovernmentVM.LocalGovernmentAdministration = await _localGovernmentAdministrationRepository.FindLocalGovernmentById(id);
            localGovernmentVM.Settlements = await _localGovernmentSettlementRepository.GetSettlementsByAdministrationId((int)id);

            if (localGovernmentVM.LocalGovernmentAdministration == null)
            {
                return NotFound();
            }

            localGovernmentVM.CommunityTypes = await _communityTypeRepositoryRepository.GetAll();
            localGovernmentVM.PopulationGraphData = PopulationDataExtension.GetPopulationValues(localGovernmentVM.LocalGovernmentAdministration);

            return View(localGovernmentVM);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            var localGovernmentVM = new LocalGovernmentAdministrationVM();
            var localGovernmentAdministration = await _localGovernmentAdministrationRepository.FindLocalGovernmentById(id);

            if (id == null || localGovernmentAdministration == null)
            {
                return NotFound();
            }

            localGovernmentVM.LocalGovernmentAdministration = localGovernmentAdministration;
            localGovernmentVM.CommunityTypes = await _communityTypeRepositoryRepository.GetAll();

            return View(localGovernmentVM);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int id, LocalGovernmentAdministration localGovernmentAdministration)
        {
            var localGovernmentVM = new LocalGovernmentAdministrationVM();

            if (id != localGovernmentAdministration.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _localGovernmentAdministrationRepository.Update(localGovernmentAdministration);

                return RedirectToAction(nameof(Index));
            }

            localGovernmentVM.LocalGovernmentAdministration = localGovernmentAdministration;
            localGovernmentVM.CommunityTypes = await _communityTypeRepositoryRepository.GetAll();
            return View(localGovernmentVM);
        }

        public async Task<IActionResult> Delete (int? id)
        {
            if (id== null)
            {
                return NotFound();
            }
            var localGovernmentAdministration = await _localGovernmentAdministrationRepository.SingleOrDefault(lga => lga.Id == id);
            if (localGovernmentAdministration == null)
            {
                return NotFound();
            }
            return View(localGovernmentAdministration);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _localGovernmentAdministrationRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
