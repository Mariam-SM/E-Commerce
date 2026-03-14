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
using Talabat.Application.Abstraction.Common;
using Talabat.Application.Exceptions;

namespace Talabat.Application.Services
{
    internal class ProductService(IUnitOfWork unitOfWork, IMapper mapper) : IProductService
    {

        public async Task<Pagination<ProductToReturnDto>> GetAllProductsAsync(ProductSpecParams productSpecParams)
        {
            var spec = new ProductWithBrandAndCategorySpecifications
                (productSpecParams.Sort, productSpecParams.BrandId, productSpecParams.CategoryId, productSpecParams.Search, productSpecParams.PageIndex, productSpecParams.PageSize);

            var productRepo = unitOfWork.GetRepository<Product, int>();

            var products = await productRepo.GetAllWithSpecAsync(spec);


            var countSpec = new ProductForCountSpec(productSpecParams.BrandId, productSpecParams.CategoryId, productSpecParams.Search);
            
            var count = await productRepo.GetCountAsync(countSpec);

            // Map products to ProductToReturnDto
            var data = mapper.Map<IEnumerable<ProductToReturnDto>>(products);


            return new Pagination<ProductToReturnDto>(productSpecParams.PageIndex, productSpecParams.PageSize){ Count = count, Data = data};
        }

        public async Task<ProductToReturnDto?> GetProducAsync(int id)
        {

            var specs = new ProductWithBrandAndCategorySpecifications(id);

            var product = await unitOfWork.GetRepository<Product , int>().GetWithSpecAsync(specs);

            if (product is null) throw new NotFoundException(nameof(Product) , id);
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
