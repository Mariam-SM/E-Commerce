using Microsoft.EntityFrameworkCore.Infrastructure;
using Talabat.Infrastructure.Persistence.Common;

namespace Talabat.Infrastructure.Persistence.Data.Config.Base
{
    [DbContextType(typeof(StoreDbContext))]
    public class BaseEntityConfigurations<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>

    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            //builder.Property(e => e.Id).ValueGeneratedOnAddOrUpdate();

        }
    }
}
