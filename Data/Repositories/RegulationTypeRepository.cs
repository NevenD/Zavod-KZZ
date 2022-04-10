using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;

namespace ZAVOD_KZZ.Data.Repositories
{
    public interface IRegulationTypeRepository : IRepository<RegulationType>
    {
    }
    public class RegulationTypeRepository : Repository<RegulationType>, IRegulationTypeRepository
    {
        public RegulationTypeRepository(ApplicationDbContext context) : base(context) { }
    }
}
