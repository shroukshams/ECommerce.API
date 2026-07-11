using ECommerce.Application.Common;
using ECommerce.Application.Contracts;
using ECommerce.Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Products
        [HttpGet]
    
        public async Task <ActionResult<Result<PaginatedResult<ProductDto>>>> GetAllProducts([FromQuery]ProuductQueryParams queryParams, CancellationToken ct = default)
        {
          var  result =  await _productService.GetAllProductsAsync(queryParams, ct);
            return Ok(result);
        }
        //get by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Result<ProductDto>>> GetProductById(int id, CancellationToken ct = default)
        {
            var result = await _productService.GetProductByIdAsync(id, ct);
            if (!result.IsSuccess)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
        // GET: api/Products/brands
        [HttpGet("brands")]
        public async Task<ActionResult<Result<IReadOnlyList<BrandDto>>>> GetAllBrands(CancellationToken ct = default)
        {
            var result = await _productService.GetAllBrandsAsync(ct);
            return Ok(result);
        }
        // GET: api/Products/types
        [HttpGet("types")]
        public async Task<ActionResult<Result<IReadOnlyList<TypeDto>>>> GetAllTypes(CancellationToken ct = default)
        {
            var result = await _productService.GetAllTypesAsync(ct);
            return Ok(result);
        }
    }

}
