namespace Talabat.Application.Abstraction.Services
{
    public interface ICacheService
    {
        Task<string?> GetCacheValueAsync(string key);
        Task SetCacheValueAsync(string key, object value, TimeSpan duration);
    }
}
