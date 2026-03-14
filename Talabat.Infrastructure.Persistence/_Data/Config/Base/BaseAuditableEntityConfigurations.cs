namespace Talabat.Infrastructure.Persistence.Data.Config.Base
{
    public class BaseAuditableEntityConfigurations<TEntity, TKey> : BaseEntityConfigurations<TEntity, TKey>
        where TEntity : BaseAuditableEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);

            //builder.Property(e => e.CreatedOn).HasDefaultValue("GETUCTDATE");
            //builder.Property(e => e.LastModifiedOn).HasComputedColumnSql("GETUTCDATE");
        }
    }
}
