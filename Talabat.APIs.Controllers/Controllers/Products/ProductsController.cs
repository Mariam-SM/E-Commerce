using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.APIs.Controllers.Base;
using Talabat.APIs.Controllers.Errors;
using Talabat.Application.Abstraction.Models.Products;
using Talabat.Application.Abstraction.Services;

namespace Talabat.APIs.Controllers.Controllers.Products
{
    public class ProductsController(IServiceManager serviceManager) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProducts([FromQuery] ProductSpecParams productSpecParams)
        {
            var products = await serviceManager.ProductService.GetAllProductsAsync(productSpecParams);
            return Ok(products);
        }

        // with segment
        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProductById(int id)
        {
            var product = await serviceManager.ProductService.GetProducAsync(id);
            if (product == null)
            {
                return NotFound(new ApiErrorsResponse(404)); 
            }
            
            return Ok(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetBrands()
        {
            var brands = await serviceManager.ProductService.GetAllBrandsAsync();
            return Ok(brands);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var categories = await serviceManager.ProductService.GetAllCategoriesAsync();
            return Ok(categories);
        }
    
    }
}
