using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.Repositories
{

    public interface ISpatialPlannerRepository : IRepository<SpatialPlanner>
    {
        Task<IEnumerable<SpatialPlanner>> GetAllSpatialPlannersWithSpatialDocuments();
    }


    public class SpatialPlannerRepository : Repository<SpatialPlanner>, ISpatialPlannerRepository
    {
        public SpatialPlannerRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<SpatialPlanner>> GetAllSpatialPlannersWithSpatialDocuments()
        {
            return await _context.SpatialPlanners.AsNoTracking()
                .Include(x => x.SpatialPlanDocuments)
                .ToListAsync();
        }
    }
}
