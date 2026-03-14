using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Domain.Contracts.Specifications
{
    public class BaseSpecifications<TEntity, TKey> : ISpecifications<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public Expression<Func<TEntity, bool>>? Criteria { get; set; }

        public List<Expression<Func<TEntity, object>>> Includes { get; set; } = new();
        public Expression<Func<TEntity, object>>? OrderBy { get; set; } = null;
        public Expression<Func<TEntity, object>>? OrderByDesc { get; set; } = null;
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 0;
        public bool IsPaganinationEnable { get; set; } = false;

        //public BaseSpecifications()
        //{
        //    //Criteria = null;
        //    //Includes = new List<Expression<Func<TEntity, object>>>();
        //}

        public BaseSpecifications(Expression<Func<TEntity, bool>>? criteriaExper)
        {
            Criteria = criteriaExper;
        }
        public BaseSpecifications(TKey key)  // Criteria not null  -> ( P => P.Id == id) 
        {
            Criteria = entity => entity.Id!.Equals(key);
        }

        #region Helper Methods


        private protected virtual void AddSorting(string? sort)
        {

        }

        private protected virtual void AddOrderBy(Expression<Func<TEntity, object>> orderBy)
        {
            OrderBy = orderBy;
        }

        private protected virtual void AddOrderByDesc(Expression<Func<TEntity, object>> orderByDesc)
        {
            OrderByDesc = orderByDesc;
        }

        private protected virtual void AddIncludes()
        {

        } 

        private protected virtual void AddPagination(int skip , int take)
        {
            IsPaganinationEnable = true;
            Skip = skip;
            Take = take;

        }


        #endregion
    }
}
