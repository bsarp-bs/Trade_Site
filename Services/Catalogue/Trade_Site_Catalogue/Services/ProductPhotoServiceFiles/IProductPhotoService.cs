using Trade_Site_Catalogue.DTOs.ProductPhotoDTOs;

namespace Trade_Site_Catalogue.Services.ProductPhotoServiceFiles
{
    public interface IProductPhotoService
    {
        Task CreateProductPhoto(InsertProductPhotoDto insertProductPhotoDto);

        Task DeleteProductPhoto(string id);

        Task UpdateProductPhoto(UpdateProductPhotoDto updateProductPhotoDto);

        Task<List<ShowProductPhotoDto>> GetAllProductPhotosAsync();

        Task<GetByIdProductPhotoDto> GetProductPhotoByIdAsync(string id);
    }
}
