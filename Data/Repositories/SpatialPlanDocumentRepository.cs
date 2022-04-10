using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;
using ZAVOD_KZZ.Core.ViewModels.Reports;
using ZAVOD_KZZ.Helpers.Enums;

namespace ZAVOD_KZZ.Data.Repositories
{

    public interface ISpatialPlanDocumentRepository : IRepository<SpatialPlanDocument>
    {
        Task<IEnumerable<SpatialPlanDocument>> GetAllSpatialPlanDocuments();
        Task<IEnumerable<SpatialPlanDocument>> GetAllSpatialPlanDocumentsByStatus(int statusId);
        Task<IEnumerable<SpatialPlanDocument>> GetSpatialPlanDocumentsWithoutAdditionalDocuments();
        Task<IEnumerable<SpatialPlanDocument>> GetSpatialPlansByReportParameters(SpatialPlanReport spatialPlanReport);
        Task<IEnumerable<SpatialPlanDocument>> GetSpatialDocumentsBySpatialPlannersId(int id);
        Task<int> GetSpatialPlanByStatus(int statusId);

    }

    public class SpatialPlanDocumentRepository : Repository<SpatialPlanDocument>, ISpatialPlanDocumentRepository
    {
        public SpatialPlanDocumentRepository(ApplicationDbContext context) : base(context) { }

    

        public async Task<IEnumerable<SpatialPlanDocument>> GetAllSpatialPlanDocuments()
        {
            return await _context.SpatialPlanDocuments.AsNoTracking()
                .Include(x => x.LocalGovernmentAdministration)
                .Include(x => x.SpatialPlanLevel)
                .Include(x => x.SpatialPlanRevision)
                .Include(x => x.SpatialMeasure)
                .Include(x => x.OfficalSpatialNews)
                .Include(x => x.SpatialPlanner)
                .Include(x => x.SpatialProjection)
                .Include(x => x.SpatialPlanDelivery)
                .Include(x => x.ConservationDocument)
                .Include(x => x.SpuoPuoDocument)
                .Include(x => x.SpatialPlanStatus)
                .Include(x => x.SpatialPlanAdditionalDocuments)
                .ToListAsync();
        }

        public async Task<IEnumerable<SpatialPlanDocument>> GetAllSpatialPlanDocumentsByStatus(int statusId)
        {
            return await _context.SpatialPlanDocuments.AsNoTracking()
                .Include(x => x.LocalGovernmentAdministration)
                .Include(x => x.SpatialPlanLevel)
                .Include(x => x.SpatialPlanRevision)
                .Include(x => x.SpatialMeasure)
                .Include(x => x.OfficalSpatialNews)
                .Include(x => x.SpatialPlanner)
                .Include(x => x.SpatialProjection)
                .Include(x => x.SpatialPlanDelivery)
                .Include(x => x.ConservationDocument)
                .Include(x => x.SpuoPuoDocument)
                .Include(x => x.SpatialPlanStatus)
                .Include(x => x.SpatialPlanAdditionalDocuments)
                .Where(x => x.SpatialPlanStatus.Id == statusId)
                .ToListAsync();
        }

        public async Task<IEnumerable<SpatialPlanDocument>> GetSpatialDocumentsBySpatialPlannersId(int id)
        {
            return await _context.SpatialPlanDocuments.AsNoTracking().Where(x => x.SpatialPlannerId == id).ToListAsync();
        }
        public async Task<int> GetSpatialPlanByStatus(int statusId)
        {
            return await _context.SpatialPlanDocuments.AsNoTracking()
                .Include(x => x.SpatialPlanStatus).Where(sp => sp.SpatialPlanStatus.Id == statusId).CountAsync();
        }

        public async Task<IEnumerable<SpatialPlanDocument>> GetSpatialPlanDocumentsWithoutAdditionalDocuments()
        {
            return await _context.SpatialPlanDocuments.AsNoTracking()
         .Include(x => x.LocalGovernmentAdministration)
         .Include(x => x.SpatialPlanLevel)
         .Include(x => x.SpatialPlanRevision)
         .Include(x => x.SpatialMeasure)
         .Include(x => x.OfficalSpatialNews)
         .Include(x => x.SpatialPlanner)
         .Include(x => x.SpatialProjection)
         .Include(x => x.SpatialPlanDelivery)
         .Include(x => x.ConservationDocument)
         .Include(x => x.SpuoPuoDocument)
         .Include(x => x.SpatialPlanStatus)
         .Include(x => x.SpatialPlanAdditionalDocuments)
         .Where(x => x.SpatialPlanAdditionalDocuments.Count() > 0)
         .ToListAsync();
        }

        public async Task<IEnumerable<SpatialPlanDocument>> GetSpatialPlansByReportParameters(SpatialPlanReport spatialPlanReport)
        {
            var spatialPlans =  await _context.SpatialPlanDocuments.AsNoTracking()
                .Include(x => x.LocalGovernmentAdministration)
                .Include(x => x.SpatialPlanLevel)
                .Include(x => x.SpatialPlanRevision)
                .Include(x => x.SpatialMeasure)
                .Include(x => x.OfficalSpatialNews)
                .Include(x => x.SpatialPlanner)
                .Include(x => x.SpatialProjection)
                .Include(x => x.SpatialPlanDelivery)
                .Include(x => x.ConservationDocument)
                .Include(x => x.SpuoPuoDocument)
                .Include(x => x.SpatialPlanStatus)
                .Include(x => x.SpatialPlanAdditionalDocuments)
                .ToListAsync();

            if (spatialPlanReport.LocalGovernmentReportId.HasValue)
            {
                spatialPlans = (spatialPlanReport.LocalGovernmentReportId == (int)Enums.LocalGovernment.ALL) ?spatialPlans : 
                    spatialPlans.Where(x => x.LocalGovernmentAdministrationId == spatialPlanReport.LocalGovernmentReportId).ToList();
            }

            if (spatialPlanReport.SpatialPlanLevelReportId.HasValue)
            {
                spatialPlans = (spatialPlanReport.SpatialPlanLevelReportId == (int)Enums.SpatialPlanLevel.ALL) ? spatialPlans :
                    spatialPlans.Where(x => x.SpatialPlanLevelId == spatialPlanReport.SpatialPlanLevelReportId).ToList();
            }

            if (spatialPlanReport.MeasureSpatialReportId.HasValue)
            {
                spatialPlans = (spatialPlanReport.MeasureSpatialReportId == (int)Enums.SpatialMeasure.ALL) ? spatialPlans :
                    spatialPlans.Where(x => x.SpatialMeasureId == spatialPlanReport.MeasureSpatialReportId).ToList();
            }

            if (spatialPlanReport.SpatialPlannersReportId.HasValue)
            {
                spatialPlans = (spatialPlanReport.SpatialPlannersReportId == (int)Enums.SpatialPlanners.ALL) ? spatialPlans :
                    spatialPlans.Where(x => x.SpatialPlannerId == spatialPlanReport.SpatialPlannersReportId).ToList();
            }

            if (spatialPlanReport.SpatialPlanLevelReportId.HasValue)
            {
                spatialPlans = (spatialPlanReport.SpatialPlanLevelReportId == (int)Enums.SpatialPlanLevel.ALL) ? spatialPlans :
                    spatialPlans.Where(x => x.SpatialPlanLevelId == spatialPlanReport.SpatialPlanLevelReportId).ToList();
            }

            if (spatialPlanReport.YearsReportId.HasValue)
            {
                spatialPlans = spatialPlans
                    .Where(x => (x.SpatialPlanEnactmentDate.HasValue) ? x.SpatialPlanEnactmentDate.Value.Year  == spatialPlanReport.YearsReportId.Value : false).ToList();
            }
            return spatialPlans;
        }
    }
}
