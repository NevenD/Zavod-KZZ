using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;
using ZAVOD_KZZ.Helpers.Enums;

namespace ZAVOD_KZZ.Data.Repositories
{

    public interface IRoadsRepository : IRepository<Road>
    {
        Task<Road> GetRoadWithGeometryById(int id);
        Task<IEnumerable<Road>> GetAllRoads();
        Task<IEnumerable<Road>> GetRoadsByCategoryId(int categoryId);

    }
    public class RoadsRepository : Repository<Road>, IRoadsRepository
    {
        public RoadsRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Road>> GetAllRoads()
        {
            return await _context.Roads.AsNoTracking().Include(x => x.RoadCategory).ToListAsync();
        }

        public async Task<Road> GetRoadWithGeometryById(int id)
        {
            return await _context.Roads.AsNoTracking()
                .Include(x => x.RoadCategory)
                .Include(x => x.Geometries)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Road>> GetRoadsByCategoryId(int categoryId)
        {
            var roads = new List<Road>();
            if (categoryId == (int)Enums.RoadCategory.ALL)
            {
                 roads = await _context.Roads.AsNoTracking()
                    .Include(x => x.RoadCategory)
                    .ToListAsync();
            } else {
                roads = await _context.Roads.AsNoTracking()
                  .Include(x => x.RoadCategory).Where(y => y.RoadCategoryID == categoryId).ToListAsync();
            }
            

            return roads;
        }
    }
}
