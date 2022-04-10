using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;
using ZAVOD_KZZ.Helpers.Enums;

namespace ZAVOD_KZZ.Data.Repositories
{

    public interface IRailroadsRepository : IRepository<Railroad>
    {
        Task<IEnumerable<Railroad>> GetAllRailroads();
        Task<IEnumerable<Railroad>> GetRailroadsByCategoryId(int categoryId);

        Task<Railroad> FindRailroadById(int id);
    }
    public class RailroadsRepository : Repository<Railroad>, IRailroadsRepository
    {
        public RailroadsRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Railroad>> GetAllRailroads()
        {
            return await _context.Railroad.AsNoTracking().Include(x => x.RailroadCategory).ToListAsync();
        }

        public async Task<IEnumerable<Railroad>> GetRailroadsByCategoryId(int categoryId)
        {
            var railroad = new List<Railroad>();
            if (categoryId == (int)Enums.RoadCategory.ALL)
            {
                railroad = await _context.Railroad.AsNoTracking()
                   .Include(x => x.RailroadCategory)
                   .ToListAsync();
            }
            else
            {
                railroad = await _context.Railroad.AsNoTracking()
                  .Include(x => x.RailroadCategory).Where(y => y.RailroadCategoryID == categoryId).ToListAsync();
            }


            return railroad;
        }

        public async Task<Railroad> FindRailroadById(int id)
        {
            return await _context.Railroad.AsNoTracking().Include(x => x.RailroadCategory)
             .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
