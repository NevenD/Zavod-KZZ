using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.Repositories
{
    public interface IConservationDocumentRepository : IRepository<ConservationDocument>
    {
    }
    public class ConservationDocumentRepository : Repository<ConservationDocument>, IConservationDocumentRepository
    {
        public ConservationDocumentRepository(ApplicationDbContext context) : base(context) { }

    }
}
