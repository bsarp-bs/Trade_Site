using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trade_Site_Catalogue.DTOs.CategoryDTOs;
using Trade_Site_Catalogue.Entity;
using Trade_Site_Catalogue.Services.CategoryServiceFiles;

namespace Trade_Site_Catalogue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetallCategories()
        {
            var value = await _categoryService.GetAllCategoriesAsync();

            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(string id)
        {
            var value = await _categoryService.GetCategoryByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(InsertCategoryDto c) 
        {
            await _categoryService.CreateCategoryAsync(c);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto u) 
        {
            await _categoryService.UpdateAsync(u);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteAsync(id);
            return Ok();
        }
    }
}
