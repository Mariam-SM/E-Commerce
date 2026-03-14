using Talabat.Domain.Entities.Basket;

namespace Talabat.Domain.Contracts.Infrastructure
{
    public interface IBasketDBRepoistory
    {
        Task<Basket?> GetBasketAsync(string id);
        Task<Basket?> UpdateBasketAsync(Basket basket , TimeSpan timeToLive);
        Task DeleteAsync(string id);

    }
}
