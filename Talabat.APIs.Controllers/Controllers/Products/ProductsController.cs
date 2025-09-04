using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.APIs.Controllers.Base;
using Talabat.Application.Abstraction.Models.Products;
using Talabat.Application.Abstraction.Services;

namespace Talabat.APIs.Controllers.Controllers.Products
{
    public class ProductsController(IServiceManager serviceManager) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProducts(string? sort, int? brandId, int? categoryId)
        {
            var products = await serviceManager.ProductService.GetAllProductsAsync(sort, brandId , categoryId);
            return Ok(products);
        }

        // with segment
        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProductById(int id)
        {
            var product = await serviceManager.ProductService.GetProducAsync(id);
            if (product == null)
            {
                return NotFound(new { StatusCode = 404 , message = "Not Found."}); 
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
