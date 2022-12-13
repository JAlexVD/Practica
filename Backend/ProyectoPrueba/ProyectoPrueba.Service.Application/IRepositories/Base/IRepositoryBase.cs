using ProyectoPrueba.Service.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPrueba.Service.Application.IRepositories.Base
{
    public interface IRepositoryBase <T> where T : EntityBase
    {
        Task<T> GetEntityAsync (Expression<Func<T,bool>> predicate=null, List<Expression<Func<T,object>>> includes=null,bool disableTracking=true);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);


    }
}
