
using Api.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Infrastructure.Repository
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        private readonly MegaworksContext _dbContext;

        public BaseRepository(MegaworksContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll(int take, int offSet, string sortingProp, bool asc)
        {
            var query = _dbContext.Set<TEntity>().AsQueryable();

            if (DataHelpers.CheckExistingProperty<TEntity>(sortingProp))
                query = query.OrderByDynamic(sortingProp, asc);

            return await query.Skip(offSet).Take(take).ToListAsync();
        }

        public virtual async Task<TEntity> Insert(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<bool> Delete(TEntity entity)
        {
            try
            {
                _dbContext.Set<TEntity>().Remove(entity);
                var result = await _dbContext.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public virtual async Task<bool> Update(TEntity entity)
        {
            try
            {
                _dbContext.Update(entity);
                var result = await _dbContext.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
