using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Domain.Contracts.Infrastructure;
using Talabat.Domain.Entities.Basket;

namespace Talabat.Infrastructure.BasketDB_Repository
{
    public class BasketDBRepoistory : IBasketDBRepoistory
    {
        private readonly IDatabase _database;
        public BasketDBRepoistory(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task<Basket?> GetBasketAsync(string id)
        {
            var basket = await _database.StringGetAsync(id);
            return basket.IsNullOrEmpty ? null : JsonSerializer.Deserialize<Basket>(basket!);
        }

        public async Task<Basket?> UpdateBasketAsync(Basket basket, TimeSpan timeToLive)
        {
            var serializedBasket = JsonSerializer.Serialize(basket);
            var updated = await _database.StringSetAsync(basket.Id, serializedBasket, timeToLive);

            if(!updated) return null;
            return basket;

        }
        public async Task DeleteAsync(string id) => await _database.KeyDeleteAsync(id);
    }
}
