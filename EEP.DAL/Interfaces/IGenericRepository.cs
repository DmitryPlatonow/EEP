using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EEP.DAL.Interfaces
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : class
                                                       where TKey : struct
    {
        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);
        IQueryable<TEntity> GetAll();
        TEntity GetByID(TKey id);
        void Add(TEntity entity);
        void Delete(TKey id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);

        Task<TEntity> GetByIdAsync(TKey id);
        Task AddAsync(TEntity entity);
        Task DeleteAsync(TKey id);
        Task DeleteAsync(TEntity entityToDelete);
        Task UpdateAsync(TEntity entity);

        //  Task DeleteAllAsync(List<TEntity> entity);
    }
}
