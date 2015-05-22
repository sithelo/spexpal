using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Threading.Tasks;
using BE_SpexPAL.DataContext;

namespace BE_SpexPAL.Repository
{
    public class SpexPalRepository<T> : ISpexPal<T> where T : class
    {
        private readonly SpexPalDbContext _db;
        public SpexPalRepository(SpexPalDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<int> AddAsync(T t)
        {
            _db.Set<T>().Add(t);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> RemoveAsync(T t)
        {
            _db.Entry(t).State = EntityState.Deleted;
            return await _db.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }
        public virtual async Task<T> GetById(Guid id)
        {
            //T entity = await _db.Set<T>().FindAsync(id);
           // await this.LoadReferences(entity, includes);

            return await _db.Set<T>().FindAsync(id);
        }
        public async Task<int> UpdateAsync(T t)
        {
            _db.Entry(t).State = EntityState.Modified;
            return await _db.SaveChangesAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _db.Set<T>().CountAsync();
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await _db.Set<T>().SingleOrDefaultAsync(match);
        }

        public async Task<List<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await _db.Set<T>().Where(match).ToListAsync();
        }
    }
}