using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trade_Site_Catalogue.DTOs.ProductInfoDTOs;
using Trade_Site_Catalogue.Services.ProductInfoServiceFiles;

namespace Trade_Site_Catalogue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductInfoController : ControllerBase
    {
        private readonly IProductInfoService _productInfoService;

        public ProductInfoController(IProductInfoService productInfoService)
        {
            _productInfoService = productInfoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductInfos()
        {
            var value = await _productInfoService.GetAllProductInfosAsync();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(string id)
        {
            var value = await _productInfoService.GetProductInfoByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductInfo(InsertProductInfoDto p)
        {
            await _productInfoService.CreateProductInfoAsync(p);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductInfo(UpdateProductInfoDto u)
        {
            await _productInfoService.UpdateProductInfoAsync(u);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductInfo(string id)
        {
            await _productInfoService.DeleteProductInfoAsync(id);
            return Ok();
        }

        [HttpGet("GetInfoByProductID")]
        public async Task<IActionResult> GetInfoByProductID(string id)
        {
            var value = await _productInfoService.GetProductInfoWithProductIDAsync(id);
            return Ok(value);
        }
    }
}
