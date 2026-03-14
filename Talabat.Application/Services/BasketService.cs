using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Application.Abstraction.Models.Baskets;
using Talabat.Application.Abstraction.Services;
using Talabat.Application.Exceptions;
using Talabat.Domain.Contracts.Infrastructure;
using Talabat.Domain.Entities.Basket;

namespace Talabat.Application.Services
{
    public class BasketService : IBasketService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IBasketDBRepoistory _basketRepo;

        public BasketService(IBasketDBRepoistory basketReop , IMapper mapper , IConfiguration configuration)
        {
            _basketRepo = basketReop;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<BasketDto> GetCustomerBasketAsync(string id)
        {
            var basket = await _basketRepo.GetBasketAsync(id);
            
            if (basket == null) throw new NotFoundException(nameof(Basket), id);

            var mappedBasket = _mapper.Map<BasketDto>(basket);
            return (mappedBasket);

        }

        public async Task<BasketDto> UpdateCustomerBasketAsync(BasketDto basket)
        {
            var mappedBasket = _mapper.Map<Basket>(basket);

            var daysToLive = int.Parse(_configuration.GetSection("RedisSettigs")["TimeToLiveInDays"]!);

            var updatedBasket = await _basketRepo.UpdateBasketAsync(mappedBasket , TimeSpan.FromDays(daysToLive));
            
            if (updatedBasket is null) throw new BadRequestException("An Error had occured !!");

            return basket;
        }
        public async Task DeleteCustomerBasket(string id) => await _basketRepo.DeleteAsync(id);

    }
}
