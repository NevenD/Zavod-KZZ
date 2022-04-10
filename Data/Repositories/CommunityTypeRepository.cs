using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.Repositories
{

    public interface ICommunityTypeRepository : IRepository<CommunityType>
    {
      
    }
    public class CommunityTypeRepository : Repository<CommunityType>, ICommunityTypeRepository
    {
        public CommunityTypeRepository(ApplicationDbContext context) : base(context) { }

        
    }
}
