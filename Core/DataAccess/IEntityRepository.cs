using System;
using System.Linq.Expressions;
using System.Security.Principal;
using Core.Entity;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : IAbcEntity
    {
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
        Task<ICollection<T>> GetList(Expression<Func<T, bool>>? filter = null);
        Task<T> GetById(Expression<Func<T, bool>> filter);
    }
}

