using System.Text.Json;
using Talabat.Application.Abstraction.Services;
using Talabat.Domain.Contracts.Infrastructure;

namespace Talabat.Infrastructure.Cache
{
    public class CacheService(ICacheRepository cachRepository) : ICacheService
    {
        public async Task<string?> GetCacheValueAsync(string key)
        {
            var value = await cachRepository.GetTask(key);
            return value == null ? null : value;
        }

        public async Task SetCacheValueAsync(string key, object value, TimeSpan duration)
        {
            await cachRepository.SetAsync(key, value, duration);
        }
    }
}