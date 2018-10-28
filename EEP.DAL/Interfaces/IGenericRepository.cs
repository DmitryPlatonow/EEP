using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EEP.DAL.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
                                                      
    {
        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);
        IQueryable<TEntity> GetAll();
        TEntity GetByID(object id);
        void Add(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);

        Task<TEntity> GetByIdAsync(object id);
        Task AddAsync(TEntity entity);
        Task DeleteAsync(object id);
        Task DeleteAsync(TEntity entityToDelete);
        Task UpdateAsync(TEntity entity);

        //  Task DeleteAllAsync(List<TEntity> entity);
    }
}
