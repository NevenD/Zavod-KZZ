using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.Repositories
{
    public interface IDocumentStatusZaraRepository : IRepository<DocumentStatusZara>
    {
    }
    public class DocumentStatusZaraRepository : Repository<DocumentStatusZara>, IDocumentStatusZaraRepository
    {
        public DocumentStatusZaraRepository(ApplicationDbContext context) : base(context) { }
    }
}
