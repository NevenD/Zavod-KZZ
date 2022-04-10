using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;
using ZAVOD_KZZ.Helpers.Enums;

namespace ZAVOD_KZZ.Data.Repositories
{

    public interface IRoadsLocalGovermentRepository : IRepository<RoadLocalGovernment>
    {
        Task<IEnumerable<RoadLocalGovernment>> GetRoadsInLocalGovernmentById(int id);
        Task<IEnumerable<RoadLocalGovernment>> GetRoadsInLocalGovernmentByRoadCategoryId(int categoryId, int localGovermentId);

    }
    public class RoadsLocalGovernmentRepository : Repository<RoadLocalGovernment>, IRoadsLocalGovermentRepository
    {
        public RoadsLocalGovernmentRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<RoadLocalGovernment>> GetRoadsInLocalGovernmentById(int id)
        {
            return await _context.RoadsLocalGovernment.AsNoTracking()
                .Include(x => x.LocalGovernmentAdministration)
                .Include(x => x.Road)
                .Include(x => x.Road.RoadCategory)
                .Where(x => x.LocalGovernmentAdministrationID == id)
                .ToListAsync();
        }

        public async Task<IEnumerable<RoadLocalGovernment>> GetRoadsInLocalGovernmentByRoadCategoryId(int categoryId, int localGovermentId)
        {

            var roadsLocalGovernment = await _context.RoadsLocalGovernment.AsNoTracking()
                                .Include(x => x.LocalGovernmentAdministration)
                                .Include(x => x.Road)
                                .Include(x => x.Road.RoadCategory)
                                .ToListAsync();

            if (categoryId != (int)Enums.RoadCategory.ALL)
            {
                roadsLocalGovernment = roadsLocalGovernment.Where(x => x.Road.RoadCategory.Id == categoryId).ToList();
            }
            if (localGovermentId != (int)Enums.LocalGovernment.ALL)
            {
                roadsLocalGovernment = roadsLocalGovernment.Where(x => x.LocalGovernmentAdministrationID == localGovermentId).ToList();
            }
            return roadsLocalGovernment;
        }
    }
}
