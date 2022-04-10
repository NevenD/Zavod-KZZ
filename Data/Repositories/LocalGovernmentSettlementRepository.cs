using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.Repositories
{
    public interface ILocalGovernmentSettlementRepository: IRepository<LocalGovernmentSettlement>
    {
        Task<IEnumerable<LocalGovernmentSettlement>> GetAllSettlements();

        Task<IEnumerable<LocalGovernmentSettlement>> GetSettlementsByAdministrationId(int id);
    }

    public class LocalGovernmentSettlementRepository : Repository<LocalGovernmentSettlement>, ILocalGovernmentSettlementRepository
    {
        public LocalGovernmentSettlementRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<LocalGovernmentSettlement>> GetAllSettlements()
        {
            return await _context.LocalGovernmentSettlements.AsNoTracking().Include(x => x.LocalGovernmentAdministrations).ToListAsync();
        }

        public async Task<IEnumerable<LocalGovernmentSettlement>> GetSettlementsByAdministrationId(int id)
        {
            return await _context.LocalGovernmentSettlements.AsNoTracking()
                .Include(x => x.LocalGovernmentAdministrations)
                .Where(x => x.LocalGovernmentAdministrationID == id).ToListAsync();
        }
    }
}
