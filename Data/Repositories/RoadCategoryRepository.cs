using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.Repositories
{
    
    public interface IRoadsCategoryRepository : IRepository<RoadCategory>
    {
    }

    public class RoadCategoryRepository : Repository<RoadCategory>, IRoadsCategoryRepository
    {
        public RoadCategoryRepository(ApplicationDbContext context) : base(context) { }
    }
}
