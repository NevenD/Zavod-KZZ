using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.Repositories
{

    public interface ILocalGovernmentAdministrationRepository : IRepository<LocalGovernmentAdministration>
    {
        Task<IEnumerable<LocalGovernmentAdministration>> GetAllLocalGovernments();

        Task<LocalGovernmentAdministration> FindLocalGovernmentById(int? id);
        Task<LocalGovernmentAdministration> FindLocalGovernmentByName(string name);

    }

    public class LocalGovernmentAdministrationRepository : Repository<LocalGovernmentAdministration>,ILocalGovernmentAdministrationRepository
    {

        public LocalGovernmentAdministrationRepository(ApplicationDbContext context) : base(context) { }

        public async Task <LocalGovernmentAdministration> FindLocalGovernmentById(int? id)
        {
            return await _context.LocalGovernmentAdministration.AsNoTracking().Include(x => x.CommunityType)
                   .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<LocalGovernmentAdministration> FindLocalGovernmentByName(string name)
        {
            return await _context.LocalGovernmentAdministration.AsNoTracking()
                   .FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<IEnumerable<LocalGovernmentAdministration>> GetAllLocalGovernments()
        {
            return await _context.LocalGovernmentAdministration.AsNoTracking()
                .Include(x => x.CommunityType)
                .Include(x => x.SettlementLocalGovernments)
                .ToListAsync();
        }

    }
}
