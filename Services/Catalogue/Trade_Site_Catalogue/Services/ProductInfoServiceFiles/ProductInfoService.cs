using AutoMapper;
using MongoDB.Driver;
using Trade_Site_Catalogue.DTOs.ProductInfoDTOs;
using Trade_Site_Catalogue.Entity;
using Trade_Site_Catalogue.Settings;

namespace Trade_Site_Catalogue.Services.ProductInfoServiceFiles
{
    public class ProductInfoService : IProductInfoService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductInfo> _productInfos;

        public ProductInfoService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;

            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productInfos = database.GetCollection<ProductInfo>(databaseSettings.ProductInfoCollectionName);

        }

        public async Task CreateProductInfoAsync(InsertProductInfoDto insertProductInfoDto)
        {
            var value = _mapper.Map<ProductInfo>(insertProductInfoDto);

            await _productInfos.InsertOneAsync(value);
        }

        public async Task DeleteProductInfoAsync(string id)
        {
            await _productInfos.DeleteOneAsync(x => x.ProductInfoID == id);
        }

        public async Task<List<ShowProductInfoDto>> GetAllProductInfosAsync()
        {
            var value = await _productInfos.Find(x => true).ToListAsync();

            return _mapper.Map<List<ShowProductInfoDto>>(value);
        }

        public async Task<GetByIdProductInfoDto> GetProductInfoByIdAsync(string id)
        {
            var value = await  _productInfos.Find(x=> x.ProductInfoID == id).FirstOrDefaultAsync();

            return _mapper.Map<GetByIdProductInfoDto>(value);
        }

        public async Task<GetProductInfoWithProductID> GetProductInfoWithProductIDAsync(string id)
        {
            var value = await _productInfos.Find(x => x.ProductID == id).FirstOrDefaultAsync();

            return _mapper.Map<GetProductInfoWithProductID>(value);
        }

        public async Task UpdateProductInfoAsync(UpdateProductInfoDto updateProductInfoDto)
        {
            var value = _mapper.Map<ProductInfo>(updateProductInfoDto);

            await _productInfos.ReplaceOneAsync(x => x.ProductInfoID == updateProductInfoDto.ProductInfoID, value);
        }
    }
}
