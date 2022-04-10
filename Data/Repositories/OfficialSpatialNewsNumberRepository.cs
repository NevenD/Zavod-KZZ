using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.Repositories
{


    public interface IOfficialSpatialNewsNumberRepository : IRepository<OfficalSpatialNews>
    {
    }

    public class OfficialSpatialNewsNumberRepository : Repository<OfficalSpatialNews>, IOfficialSpatialNewsNumberRepository
    {
        public OfficialSpatialNewsNumberRepository(ApplicationDbContext context) : base(context) { }

    }
}
