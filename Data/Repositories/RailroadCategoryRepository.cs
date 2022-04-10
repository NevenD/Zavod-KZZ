using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.Repositories
{
   
    public interface IRailroadCategoryRepository : IRepository<RailroadCategory>
    {
    }

    public class RailroadCategoryRepository : Repository<RailroadCategory>, IRailroadCategoryRepository
    {
        public RailroadCategoryRepository(ApplicationDbContext context) : base(context) { }
    }
    
}
