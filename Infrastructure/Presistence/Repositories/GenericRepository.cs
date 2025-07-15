using Domain.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Presistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Repositories
{
    public class GenericRepository<TEntity, Tkey>(StoreDbContext _dbContext) : IGenericRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        public async Task AddAsync(TEntity entity) => await _dbContext.Set<TEntity>().AddAsync(entity);

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbContext.Set<TEntity>().ToListAsync();

        public async Task<TEntity?> GetByIdAsync(Tkey id) => await _dbContext.Set<TEntity>().FindAsync(id);

        public void RemoveAsync(TEntity entity) => _dbContext.Set<TEntity>().Remove(entity);

        public void UpdateAsync(TEntity entity) => _dbContext.Set<TEntity>().Update(entity);
    }
}
