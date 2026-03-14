using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Domain.Contracts;
using Talabat.Domain.Contracts.Specifications;

namespace Talabat.Infrastructure.Persistence.Repositories.Generic_Repositories
{
    internal static class SpecificationsEvaluator<TEntity , TKey> 
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public static IQueryable<TEntity> GetQuery (IQueryable<TEntity> inputQuery , ISpecifications<TEntity,TKey> specifications)
        {
            var query = inputQuery;

            if(specifications.Criteria is not null)
                query = query.Where(specifications.Criteria);

            if(specifications.OrderBy is not null)
                query = query.OrderBy(specifications.OrderBy);

            else if (specifications.OrderByDesc is not null)
                query = query.OrderByDescending(specifications.OrderByDesc);


            if(specifications.IsPaganinationEnable)
                query = query.Skip(specifications.Skip).Take(specifications.Take);

            if (specifications.Includes is not null)
                 query = specifications.Includes.Aggregate(query, (currentQuery, IncludeExpression) => currentQuery.Include(IncludeExpression));

            return query;
        }
    }
}
