namespace Talabat.Domain.Common
{
    public class BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public required TKey Id { get; set; }
    }
}
