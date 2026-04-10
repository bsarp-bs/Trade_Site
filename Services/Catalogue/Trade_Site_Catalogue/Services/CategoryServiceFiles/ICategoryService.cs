using Trade_Site_Catalogue.DTOs.CategoryDTOs;

namespace Trade_Site_Catalogue.Services.CategoryServiceFiles
{
    public interface ICategoryService
    {
        Task<List<ShowCategoryDto>> GetAllCategoriesAsync();

        Task<GetByIdCategoryDto> GetCategoryByIdAsync(string id);

        Task CreateCategoryAsync(InsertCategoryDto insertCategoryDto);

        Task DeleteAsync(string id);

        Task UpdateAsync(UpdateCategoryDto updateCategoryDto);
    }
}
