using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Application.Abstraction.Models.Products;
using Talabat.Application.Abstraction.Services;
using Talabat.Domain.Contracts.Persitstence;
using Talabat.Domain.Entities.Products;
using Talabat.Domain.Contracts.Specifications;

namespace Talabat.Application.Services
{
    internal class ProductService(IUnitOfWork unitOfWork, IMapper mapper) : IProductService
    {

        public async Task<IEnumerable<ProductToReturnDto>> GetAllProductsAsync(string? sort, int? brandId, int? categoryId)
        {
            var specs = new ProductWithBrandAndCategorySpecifications(sort, brandId, categoryId);

            var products = await unitOfWork.GetRepository<Product, int>().GetAllWithSpecAsync(specs);

            // Map products to ProductToReturnDto
            var productDtos = mapper.Map<IEnumerable<ProductToReturnDto>>(products);
            return productDtos;
        }

        public async Task<ProductToReturnDto?> GetProducAsync(int id)
        {

            var specs = new ProductWithBrandAndCategorySpecifications(id);

            var product = await unitOfWork.GetRepository<Product , int>().GetWithSpecAsync(specs);
            var productDto = mapper.Map<ProductToReturnDto>(product);
            return productDto;
        }


        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
            var brands = await unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();
            var brandDtos = mapper.Map<IEnumerable<BrandDto>>(brands);
            return brandDtos;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await unitOfWork.GetRepository<ProductCategory, int>().GetAllAsync();
            var categoryDtos = mapper.Map<IEnumerable<CategoryDto>>(categories);
            return categoryDtos;
        }
    }
}
