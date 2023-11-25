using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tickets.DatabaseContext;

namespace Tickets.Data.Base
{
    public class EntityBase<T> : IEntityBase<T> where T : class, IEntity, new()
    {
        private readonly AppDbContext db;
        public EntityBase(AppDbContext _db) => db = _db;
        
        public async Task AddAsync(T entity)
        {
            await db.Set<T>().AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {

            T entity = await db.Set<T>().Where(idx=>idx.Id == id).FirstOrDefaultAsync();
            entity.Deleted = true;
            entity.DeletedOn = DateTime.Now;
            await db.SaveChangesAsync();

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await db.Set<T>().Where(idx => idx.Deleted != true).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = db.Set<T>().Where(idx=>idx.Deleted != true);
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)); // 
            return await query.ToListAsync();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
