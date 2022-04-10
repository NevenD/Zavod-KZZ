using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.Repositories
{

    public interface ISpatialPlanDeliveryRepository : IRepository<SpatialPlanDelivery>
    {
    }

    public class SpatialPlanDeliveryRepository : Repository<SpatialPlanDelivery>, ISpatialPlanDeliveryRepository
    {
        public SpatialPlanDeliveryRepository(ApplicationDbContext context) : base(context) { }

    }
}
