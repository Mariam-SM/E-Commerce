using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Application.Abstraction.Models.Products;

namespace Talabat.Application.Abstraction.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductToReturnDto>> GetAllProductsAsync(string? sort, int? brandId, int? categoryId);

        Task<ProductToReturnDto?> GetProducAsync(int id);

        Task<IEnumerable<BrandDto>> GetAllBrandsAsync();
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
    }
}
