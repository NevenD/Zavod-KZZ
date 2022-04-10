using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.Repositories
{
    public interface IRoadsGeometryRepository : IRepository<RoadGeometry>
    {
        Task<RoadGeometry> GetRoadGeometrybyRoadId(int roadId);
        Task<IEnumerable<RoadGeometry>> GetAllRoadGeometry();
    }

    public class RoadGeometryRepository : Repository<RoadGeometry>, IRoadsGeometryRepository
    {
        public RoadGeometryRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<RoadGeometry>> GetAllRoadGeometry()
        {
            return await _context.RoadGeometry.AsNoTracking()
                .Include(x => x.Road)
                .Include(x => x.Road.RoadCategory)
                .ToListAsync();
        }

        public async Task<RoadGeometry> GetRoadGeometrybyRoadId(int roadId)
        {
            return await _context.RoadGeometry.AsNoTracking()
                .Include(x => x.Road)
                .Include(x => x.Road.RoadCategory)
                .Where(x => x.RoadID == roadId)
                .FirstOrDefaultAsync();
        }

     
    }
}
