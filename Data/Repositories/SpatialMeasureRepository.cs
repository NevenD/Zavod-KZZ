using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.Repositories
{

    public interface ISpatialMeasureRepository : IRepository<SpatialMeasure>
    {
    }

    public class SpatialMeasureRepository : Repository<SpatialMeasure>, ISpatialMeasureRepository
    {
        public SpatialMeasureRepository(ApplicationDbContext context) : base(context) { }
    }
    
}
