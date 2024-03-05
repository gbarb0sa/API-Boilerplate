using Core.Interfaces;
using Infra.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _dbContext;

        public BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll(int? take, int? offSet, string sortingProp, bool? asc)
        {
            var query = _dbContext.Set<TEntity>().AsQueryable();

            if (!string.IsNullOrEmpty(sortingProp) && asc != null)
                if (DataHelpers.CheckExistingProperty<TEntity>(sortingProp))
                    query = query.OrderByDynamic(sortingProp, (bool)asc);

            if (take != null && offSet != null)
                return await query.Skip((int)offSet).Take((int)take).ToListAsync();

            return await query.ToListAsync();
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<bool> DeleteAsync(TEntity entity)
        {
            try
            {
                _dbContext.Set<TEntity>().Remove(entity);
                var result = await _dbContext.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            try
            {
                _dbContext.Update(entity);
                var result = await _dbContext.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
