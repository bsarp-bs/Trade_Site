using Trade_Site_Catalogue.DTOs.ProductInfoDTOs;

namespace Trade_Site_Catalogue.Services.ProductInfoServiceFiles
{
    public interface IProductInfoService
    {
        Task CreateProductInfoAsync(InsertProductInfoDto insertProductInfoDto);

        Task DeleteProductInfoAsync(string id);

        Task UpdateProductInfoAsync(UpdateProductInfoDto updateProductInfoDto);

        Task<List<ShowProductInfoDto>> GetAllProductInfosAsync();

        Task<GetByIdProductInfoDto> GetProductInfoByIdAsync(string id);
    }
}
