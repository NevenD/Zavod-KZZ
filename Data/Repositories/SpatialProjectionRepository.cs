using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.Repositories
{
    public interface ISpatialProjectionRepository : IRepository<SpatialProjection>
    {
    }


    public class SpatialProjectionRepository : Repository<SpatialProjection>, ISpatialProjectionRepository
    {
        public SpatialProjectionRepository(ApplicationDbContext context) : base(context) { }

    }
}
