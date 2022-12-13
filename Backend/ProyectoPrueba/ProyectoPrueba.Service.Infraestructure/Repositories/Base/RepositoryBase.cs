using Microsoft.EntityFrameworkCore;
using ProyectoPrueba.Service.Application.IRepositories.Base;
using ProyectoPrueba.Service.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPrueba.Service.Infraestructure.Repositories.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        protected readonly DBContext _dBContext;
        public RepositoryBase(DBContext dbContext) { 
            _dBContext= dbContext?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task<T> AddAsync(T entity)
        {
            _dBContext.Set<T>().Add(entity);
            await _dBContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dBContext.Set<T>().Remove(entity);
            await _dBContext.SaveChangesAsync();

        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dBContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dBContext.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<T> GetEntityAsync(Expression<Func<T, bool>> predicate = null, List<Expression<Func<T, object>>> includes = null, bool disableTracking = true)
        {
            IQueryable<T> query=_dBContext.Set<T>();

            if (disableTracking) query = query.Where(predicate);

            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicate !=null) query=query.Where(predicate);

            return await query.OrderByDescending(x => x.Created).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dBContext.Entry(entity).State= EntityState.Modified;
            await _dBContext.SaveChangesAsync();
        }
    }
}
