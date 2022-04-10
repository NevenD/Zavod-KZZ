using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.Repositories
{

    public interface ISpatialPlanStatusRepository : IRepository<SpatialPlanStatus>
    {
    }
    public class SpatialPlanStatusRepository : Repository<SpatialPlanStatus>, ISpatialPlanStatusRepository
    {
        public SpatialPlanStatusRepository(ApplicationDbContext context) : base(context) { }
    }
  
}
