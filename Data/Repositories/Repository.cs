using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ZAVOD_KZZ.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        //dohvaćamo jedan objekt na temelju svojstva objekta
        IEnumerable<T> Find(Func<T, bool> predicate);

        // This method was not in the videos, but I thought it would be useful to add.
        Task<T> SingleOrDefault(Expression<Func<T, bool>> predicate);

        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);

        Task<T> FindById(int id);

        // dohvaća objekt iz baze
        Task<T> FindFromDB(Expression<Func<T, bool>> predicate);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(int id);

        Task<int> Count(Expression<Func<T, bool>> predicate);
    }

    public class Repository<T> : IRepository<T> where T : class, new()
    {
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Count(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).CountAsync();
        }

        public async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(predicate);
        }

        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public async Task<T> FindFromDB(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> FindById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await FindById(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
