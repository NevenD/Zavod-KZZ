using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.Repositories
{


    public interface ISpatialPlanLevelRepository : IRepository<SpatialPlanLevel>
    {
    }

    public class SpatialPlanLevelRepository : Repository<SpatialPlanLevel>, ISpatialPlanLevelRepository
    {
        public SpatialPlanLevelRepository(ApplicationDbContext context) : base(context) { }

    }
}
