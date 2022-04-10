using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.Repositories
{

    public interface ISpuoPuoDocumentRepository : IRepository<SpuoPuoDocument>
    {
    }
    public class SpuoPuoDocumentRepository : Repository<SpuoPuoDocument>, ISpuoPuoDocumentRepository
    {
        public SpuoPuoDocumentRepository(ApplicationDbContext context) : base(context) { }
    }
   
}
