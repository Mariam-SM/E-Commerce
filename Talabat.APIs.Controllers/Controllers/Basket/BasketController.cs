using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.APIs.Controllers.Base;
using Talabat.Application.Abstraction.Models.Baskets;
using Talabat.Application.Abstraction.Services;

namespace Talabat.APIs.Controllers.Controllers.Basket
{

    public class BasketController : BaseApiController
    {
        private readonly IServiceManager _serviceManager;

        public BasketController(IServiceManager serviceManager)
            : base()
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBasket(string id)
        {
            var basket = await _serviceManager.BasketService.GetCustomerBasketAsync(id);
            return Ok(basket);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBasket(BasketDto basket)
        {
            var updatedBasket = await _serviceManager.BasketService.UpdateCustomerBasketAsync(basket);
            return Ok(updatedBasket);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasket(string id)
        {
            await _serviceManager.BasketService.DeleteCustomerBasket(id);
            return NoContent();
        }
    }
}
