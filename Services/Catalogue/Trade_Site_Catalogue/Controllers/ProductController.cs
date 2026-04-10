using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trade_Site_Catalogue.DTOs.ProductDTOs;
using Trade_Site_Catalogue.Services.ProductServiceFiles;

namespace Trade_Site_Catalogue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductAsync()
        {
            var value = await _productService.GetAllProductsAsync();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(string id)
        {
            var value = await _productService.GetProductByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(InsertProductDto p)
        {
            await _productService.CreateProductAsync(p);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto u)
        {
            await _productService.UpdateProductAsync(u);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok();
        }
    }
}
