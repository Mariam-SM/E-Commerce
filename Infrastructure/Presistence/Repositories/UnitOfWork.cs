using Domain.Contracts;
using Domain.Models;
using Presistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Repositories
{
    public class UnitOfWork(StoreDbContext _dbContext) : IUnitOfWork
    {
            // Dict<string,obj> : <namOfType, obj from Generic Repo > 
            //private readonly Dictionary<string, object> _repositories = new Dictionary<string, object>();
            private readonly Dictionary<string, object> _repositories = [];

        public IGenericRepository<TEntity, Tkey> GetRepository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>
        {
            // Get Type Name

            // Get the name of the entity type
            var typeName = typeof(TEntity).Name;

            // Check if the repository for this type already exists
            //if(_repositories.ContainsKey(typeName))
            //{
            //    return (IGenericRepository<TEntity, Tkey>)_repositories[typeName];
            //}

            if(_repositories.TryGetValue(typeName, out object value))
                return (IGenericRepository<TEntity, Tkey>)value;

            else
            {
                // Create the obj
                var Repo = new GenericRepository<TEntity, Tkey>(_dbContext);

                // Store it in the dictionary
                //_repositories.Add(typeName, Repo);
                _repositories["typeName"] = Repo;

                // return it
                return Repo;
            }
            
        }

        public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();
        
    }
}
