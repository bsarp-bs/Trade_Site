using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trade_Site_Catalogue.DTOs.ProductPhotoDTOs;
using Trade_Site_Catalogue.Services.ProductPhotoServiceFiles;

namespace Trade_Site_Catalogue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPhotoController : ControllerBase
    {
        private readonly IProductPhotoService _productPhotoService;

        public ProductPhotoController(IProductPhotoService productPhotoService)
        {
            _productPhotoService = productPhotoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductPhotos()
        {
            var value = await _productPhotoService.GetAllProductPhotosAsync();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(string id)
        {
            var value = await _productPhotoService.GetProductPhotoByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductPhoto(InsertProductPhotoDto p)
        {
            await _productPhotoService.CreateProductPhoto(p);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductPhoto(UpdateProductPhotoDto u)
        {
            await _productPhotoService.UpdateProductPhoto(u);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductPhoto(string id)
        {
            await _productPhotoService.DeleteProductPhoto(id);
            return Ok();
        }
    }
}
