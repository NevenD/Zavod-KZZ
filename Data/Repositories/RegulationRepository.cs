using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.Repositories
{
    public interface IRegulationRepository : IRepository<Regulation>
    {
        Task<IEnumerable<Regulation>> GetAllRegulations();
        Task<Regulation> FindRegulationById(int id);

        Task<IEnumerable<Regulation>> FindByRegulationTypeId(int typeId);
    }

    public class RegulationRepository : Repository<Regulation>, IRegulationRepository
    {
        public RegulationRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Regulation>> FindByRegulationTypeId(int typeId)
        {
            return await _context.Regulations.AsNoTracking().Include(x => x.RegulationType)
                .Where(x => x.RegulationType.Id == typeId).ToListAsync();
        }

        public async Task<Regulation> FindRegulationById(int id)
        {
            return await _context.Regulations.AsNoTracking().Include(x => x.RegulationType)
             .FirstOrDefaultAsync( x => x.Id == id);
        }

        public async Task<IEnumerable<Regulation>> GetAllRegulations()
        {
            return await _context.Regulations.AsNoTracking()
              .Include(x => x.RegulationType)
              .ToListAsync();
        }


    }
}
