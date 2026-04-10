using AutoMapper;
using MongoDB.Driver;
using Trade_Site_Catalogue.DTOs.ProductPhotoDTOs;
using Trade_Site_Catalogue.Entity;
using Trade_Site_Catalogue.Settings;

namespace Trade_Site_Catalogue.Services.ProductPhotoServiceFiles
{
    public class ProductPhotoService : IProductPhotoService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductPhoto> _productPhotos;

        public ProductPhotoService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;

            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productPhotos = database.GetCollection<ProductPhoto>(databaseSettings.ProductPhotoCollectionName);
        }

        public async Task CreateProductPhoto(InsertProductPhotoDto insertProductPhotoDto)
        {
            var value = _mapper.Map<ProductPhoto>(insertProductPhotoDto);

            await _productPhotos.InsertOneAsync(value);
        }

        public async Task DeleteProductPhoto(string id)
        {
            await _productPhotos.DeleteOneAsync(x => x.ProductPhotoID == id);
        }

        public async Task<List<ShowProductPhotoDto>> GetAllProductPhotosAsync()
        {
            var value = await _productPhotos.Find(x=>true).ToListAsync();

            return _mapper.Map<List<ShowProductPhotoDto>>(value);
        }

        public async Task<GetByIdProductPhotoDto> GetProductPhotoByIdAsync(string id)
        {
            var value = await _productPhotos.Find(x=>x.ProductPhotoID == id).FirstOrDefaultAsync();

            return _mapper.Map<GetByIdProductPhotoDto>(value);
        }

        public async Task UpdateProductPhoto(UpdateProductPhotoDto updateProductPhotoDto)
        {
            var value = _mapper.Map<ProductPhoto>(updateProductPhotoDto);

            await _productPhotos.ReplaceOneAsync(x => x.ProductPhotoID == updateProductPhotoDto.ProductPhotoID, value);
        }
    }
}
