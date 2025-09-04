using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Domain.Contracts;
using Talabat.Domain.Contracts.Persitstence;
using Talabat.Infrastructure.Persistence.Data;
using Talabat.Infrastructure.Persistence.Repositories.Generic_Repositories;

namespace Talabat.Infrastructure.Persistence.Repositories
{
    internal class GenericRepository<TEntity,TKey>(StoreContext _dbContext) : IGenericRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool withTraching = false)
            => withTraching? await _dbContext.Set<TEntity>().ToListAsync()
                          : await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();

        public async Task<TEntity?> GetAsync(TKey key) => await _dbContext.Set<TEntity>().FindAsync(key);
        public async Task AddAsync(TEntity entity) => await _dbContext.Set<TEntity>().AddAsync(entity);

        public void Update(TEntity entity) => _dbContext.Set<TEntity>().Update(entity);

        public void Delete(TEntity entity) => _dbContext.Set<TEntity>().Remove(entity);

        public async Task<IEnumerable<TEntity>> GetAllWithSpecAsync(ISpecifications<TEntity, TKey> specs, bool withTraching = false)
        => withTraching ? await ApplySpecifications(specs).ToListAsync() :
                          await ApplySpecifications(specs).AsNoTracking().ToListAsync();

        public async Task<TEntity?> GetWithSpecAsync(ISpecifications<TEntity, TKey> specs)
        {
            return await ApplySpecifications(specs).FirstOrDefaultAsync();
        }

        #region Helper Methods

        private IQueryable<TEntity> ApplySpecifications(ISpecifications<TEntity, TKey> specs)
        {
            return SpecificationsEvaluator<TEntity, TKey>.GetQuery(_dbContext.Set<TEntity>(), specs);
        }

        #endregion

    }
}
