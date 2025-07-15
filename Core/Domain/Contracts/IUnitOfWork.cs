using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IUnitOfWork
    {
        // Generic Repository for Each Entity
        //public IGenericRepository<Product, int> ProductRepository { get; }    

        IGenericRepository<TEntity, Tkey> GetRepository<TEntity, Tkey>() where TEntity: BaseEntity<Tkey>;
        Task<int> SaveChangesAsync();
      
    }
}
