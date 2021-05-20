using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Interface
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Insert(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(TEntity entity);
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll(int take, int offset, string sortingProp, bool asc);
    }
}