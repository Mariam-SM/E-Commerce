using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Application.Abstraction.Models.Baskets;

namespace Talabat.Application.Abstraction.Services
{
    public interface IBasketService
    {
        Task<BasketDto> GetCustomerBasketAsync(string id);
        Task<BasketDto> UpdateCustomerBasketAsync(BasketDto basket);
        Task DeleteCustomerBasket(string id);
    }
}
