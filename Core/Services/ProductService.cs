using AutoMapper;
using Domain.Contracts;
using Domain.Models;
using ServicesAbstraction;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService(IUnitOfWork _unitOfWork , IMapper _mapper) : IProductService
    {
        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var ProductsRepo = await (_unitOfWork.GetRepository<Product, int>()).GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(ProductsRepo);
        }

        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
            var BrandsRepo = await ( _unitOfWork.GetRepository<ProductBrand,int>()).GetAllAsync();
            return  _mapper.Map<IEnumerable<BrandDto>>(BrandsRepo);
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var ProductRepo =await (_unitOfWork.GetRepository<Product,int>()).GetByIdAsync(id);
            return _mapper.Map<ProductDto>(ProductRepo);
        }

        public async Task<IEnumerable<TypeDto>> GetTypesAsync()
        {
            var TypesRepo = await (_unitOfWork.GetRepository<ProductType, int>()).GetAllAsync();
            return _mapper.Map<IEnumerable<TypeDto>>(TypesRepo);
        }
    }
}
