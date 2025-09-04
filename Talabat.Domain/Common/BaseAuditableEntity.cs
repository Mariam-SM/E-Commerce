namespace Talabat.Domain.Common
{
    public class BaseAuditableEntity<TKey> :BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public required string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } //= DateTime.UtcNow;
        public required string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; } //= DateTime.UtcNow;


    }
}
