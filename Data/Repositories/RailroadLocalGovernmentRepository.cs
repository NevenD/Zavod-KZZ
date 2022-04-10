using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;
using ZAVOD_KZZ.Helpers.Enums;

namespace ZAVOD_KZZ.Data.Repositories
{

    public interface IRailroadLocalGovermentRepository : IRepository<RailroadLocalGovernment>
    {
        Task<IEnumerable<RailroadLocalGovernment>> GetRailroadsInLocalGovernmentById(int id);
        Task<IEnumerable<RailroadLocalGovernment>> GetRailroadsInLocalGovernmentByRailroadCategoryId(int categoryId, int localGovermentId);

    }
    public class RailroadLocalGovernmentRepository : Repository<RailroadLocalGovernment>, IRailroadLocalGovermentRepository
    {
        public RailroadLocalGovernmentRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<RailroadLocalGovernment>> GetRailroadsInLocalGovernmentById(int id)
        {
            return await _context.RailroadLocalGovernment.AsNoTracking()
                .Include(x => x.LocalGovernmentAdministration)
                .Include(x => x.Railroad)
                .Include(x => x.Railroad.RailroadCategory)
                .Where(x => x.LocalGovernmentAdministrationID == id)
                .ToListAsync();
        }

        public async Task<IEnumerable<RailroadLocalGovernment>> GetRailroadsInLocalGovernmentByRailroadCategoryId(int categoryId, int localGovermentId)
        {

            var roadsLocalGovernment = await _context.RailroadLocalGovernment.AsNoTracking()
                                .Include(x => x.LocalGovernmentAdministration)
                                .Include(x => x.Railroad)
                                .Include(x => x.Railroad.RailroadCategory)
                                .ToListAsync();

            if (categoryId != (int)Enums.RailroadCategory.ALL)
            {
                roadsLocalGovernment = roadsLocalGovernment.Where(x => x.Railroad.RailroadCategory.Id == categoryId).ToList();
            }
            if (localGovermentId != (int)Enums.LocalGovernment.ALL)
            {
                roadsLocalGovernment = roadsLocalGovernment.Where(x => x.LocalGovernmentAdministrationID == localGovermentId).ToList();
            }
            return roadsLocalGovernment;
        }
    }
}
