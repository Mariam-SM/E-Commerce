using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Application.Abstraction.Models.Products;
using Talabat.Application.Abstraction.Services;
using Talabat.Domain.Contracts.Persitstence;
using Talabat.Domain.Entities.Products;

namespace Talabat.Application.Services
{
    internal class ServiceManager : IServiceManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Lazy<IProductService> _productService;

        public ServiceManager(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productService= new Lazy<IProductService>(() => new ProductService(_unitOfWork, _mapper));
        }
        public IProductService ProductService => _productService.Value;

    }
}
