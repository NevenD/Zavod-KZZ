using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.Repositories
{
    public interface IDocumentTypeZaraRepository : IRepository<DocumentTypeZara>
    {
    }
    public class DocumentTypeZaraRepository : Repository<DocumentTypeZara>, IDocumentTypeZaraRepository
    {
        public DocumentTypeZaraRepository(ApplicationDbContext context) : base(context) { }
    }
}
