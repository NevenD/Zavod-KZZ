using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;
using ZAVOD_KZZ.Helpers.Enums;

namespace ZAVOD_KZZ.Data.Repositories
{

    public interface IOfficialDocumentZaraRepository : IRepository<OfficialDocumentZara>
    {
        Task<IEnumerable<OfficialDocumentZara>> GetAllOfficialZaraDocuments();

        Task<OfficialDocumentZara> FindOfficialDocumentZaraById(int id);

        Task<IEnumerable<OfficialDocumentZara>> GetOfficialDocumentsByYearAndStatusId(int year, int statusId);

    }
    public class OfficialDocumentZaraRepository : Repository<OfficialDocumentZara>, IOfficialDocumentZaraRepository
    {
        public OfficialDocumentZaraRepository(ApplicationDbContext context) : base(context) { }

        public async Task<OfficialDocumentZara> FindOfficialDocumentZaraById(int id)
        {
            return await _context.OfficialDocumentZara.AsNoTracking()
                .Include(x => x.DocumentStatusZara)
                .Include(x => x.DocumentTypeZara)
                .Include(x => x.OfficalSpatialNews)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<OfficialDocumentZara>> GetAllOfficialZaraDocuments()
        {
            return await _context.OfficialDocumentZara.AsNoTracking()
                .Include(x => x.DocumentStatusZara)
                .Include(x => x.DocumentTypeZara)
                .Include(x => x.OfficalSpatialNews)
                .ToListAsync();
        }

        public async Task<IEnumerable<OfficialDocumentZara>> GetOfficialDocumentsByYearAndStatusId(int year, int statusId)
        {
            var officialDocuments = await _context.OfficialDocumentZara.AsNoTracking()
                .Include(x => x.DocumentStatusZara)
                .Include(x => x.DocumentTypeZara)
                .Include(x => x.OfficalSpatialNews)
                .ToListAsync();

            if (year != 0)
            {
                officialDocuments = officialDocuments.Where(x => x.DocumentEffectiveDate.HasValue ? x.DocumentEffectiveDate.Value.Year == year : false).ToList();
            }
            if (statusId != (int)Enums.ZaraDocumentStatus.ALL)
            {
                officialDocuments = officialDocuments.Where(x => x.DocumentStatusZaraId == statusId).ToList();
            }

            return officialDocuments;
        }

    }
}
