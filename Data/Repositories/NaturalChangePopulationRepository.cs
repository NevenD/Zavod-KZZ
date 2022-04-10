using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZAVOD_KZZ.Core.Models;
using ZAVOD_KZZ.Helpers.Enums;

namespace ZAVOD_KZZ.Data.Repositories
{

    public interface INaturalChangePopulationRepository : IRepository<NaturalChangePopulation>
    {
        Task<IEnumerable<NaturalChangePopulation>> GetNaturalChangeByLocalGovernmentId(int id);

        Task<IEnumerable<NaturalChangePopulation>> GetAllNaturalChangePopulation();

        Task<IEnumerable<NaturalChangePopulation>> GetNaturalChangeByYearAndLocalGovernmentId(int year, int localGovermentId);


        Task<NaturalChangePopulation> FindByLocalGovernmentNameAndYear(string name, int year);

        Task<NaturalChangePopulation> NaturalChangeByLocalGovernmentId(int id);

    }

    public class NaturalChangePopulationRepository : Repository<NaturalChangePopulation>, INaturalChangePopulationRepository
    {
        public NaturalChangePopulationRepository(ApplicationDbContext context) : base(context) { }

        public async Task<NaturalChangePopulation> FindByLocalGovernmentNameAndYear(string name, int year)
        {
            return await _context.NaturalChangePopulation.AsNoTracking()
               .Include(x => x.LocalGovernmentAdministration)
               .Where(x => x.LocalGovernmentAdministration.Name.ToLower() == name.ToLower() && x.Year == year).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<NaturalChangePopulation>> GetAllNaturalChangePopulation()
        {
            return await _context.NaturalChangePopulation.AsNoTracking()
                .Include(x => x.LocalGovernmentAdministration)
                .ToListAsync();
        }

        public async Task<IEnumerable<NaturalChangePopulation>> GetNaturalChangeByLocalGovernmentId(int id)
        {
            return await _context.NaturalChangePopulation.AsNoTracking()
                .Include(x => x.LocalGovernmentAdministration)
                .Where(x => x.LocalGovernmentAdministration.Id == id)
                .ToListAsync();
        }

        public async Task<IEnumerable<NaturalChangePopulation>> GetNaturalChangeByYearAndLocalGovernmentId(int year, int localGovermentId)
        {
            var naturalChange = await _context.NaturalChangePopulation.AsNoTracking()
               .Include(x => x.LocalGovernmentAdministration)
               .ToListAsync();

            if (year != 0)
            {
                naturalChange = naturalChange.Where(x => x.Year == year).ToList();
            }
            if (localGovermentId != (int)Enums.LocalGovernment.ALL)
            {
                naturalChange = naturalChange.Where(x => x.LocalGovernmentAdministrationID == localGovermentId).ToList();
            }

            return naturalChange;
        }

        public async Task<NaturalChangePopulation> NaturalChangeByLocalGovernmentId(int id)
        {
            return await _context.NaturalChangePopulation.AsNoTracking()
               .Include(x => x.LocalGovernmentAdministration)
               .Where(y =>y.Id == id).FirstOrDefaultAsync();
        }
    }
}
