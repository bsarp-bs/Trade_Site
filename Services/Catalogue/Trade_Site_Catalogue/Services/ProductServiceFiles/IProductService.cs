using Trade_Site_Catalogue.DTOs.ProductDTOs;

namespace Trade_Site_Catalogue.Services.ProductServiceFiles
{
    public interface IProductService
    {
        Task CreateProductAsync(InsertProductDto insertProductDto);

        Task UpdateProductAsync(UpdateProductDto updateProductDto);

        Task DeleteProductAsync(string id);

        Task<List<ShowProductDto>> GetAllProductsAsync();

        Task<ShowProductDto> GetProductByIdAsync(string id);

        Task<List<GetProductWithCategory>> GetProductsWithCategoryAsync(string id);

    }
}
