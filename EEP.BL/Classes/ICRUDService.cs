using EEP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEP.BL.Classes
{
    public interface ICRUDService<TKey, TEntity> where TKey: struct
                                                 where TEntity : class

    {
        Task<TEntity> CreateAsync(TEntity project);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(TKey id);

        Task<TEntity> UpdateAsync(TEntity project);

        Task DeleteAsync(TKey id);
    }
}
