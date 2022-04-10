using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.Repositories
{
    public interface ISpatialPlanRevisionRepository : IRepository<SpatialPlanRevision>
    {
    }

    public class SpatialPlanRevisionRepository : Repository<SpatialPlanRevision>, ISpatialPlanRevisionRepository
    {
        public SpatialPlanRevisionRepository(ApplicationDbContext context) : base(context) { }
    }
   
}
