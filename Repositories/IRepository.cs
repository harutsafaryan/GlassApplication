using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassApplication.Repository
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        IList<TEntity> ReadAll();
        TEntity ReadById(int id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        void Delete(TEntity entity);
    }
}
