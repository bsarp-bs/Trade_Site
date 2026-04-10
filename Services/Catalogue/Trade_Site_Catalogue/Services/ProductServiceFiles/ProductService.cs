using AutoMapper;
using MongoDB.Driver;
using Trade_Site_Catalogue.DTOs.ProductDTOs;
using Trade_Site_Catalogue.Entity;
using Trade_Site_Catalogue.Settings;

namespace Trade_Site_Catalogue.Services.ProductServiceFiles
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _products;

        public ProductService(IMapper mapper, IDatabaseSettings databasesettings)
        {
            _mapper = mapper;
            
            var client = new MongoClient(databasesettings.ConnectionString);
            var database = client.GetDatabase(databasesettings.DatabaseName);
            _products = database.GetCollection<Product>(databasesettings.ProductCollectionName);
        }

        public async Task CreateProductAsync(InsertProductDto insertProductDto)
        {
            var value = _mapper.Map<Product>(insertProductDto);

            await _products.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _products.DeleteOneAsync(x => x.ProductID == id);
        }

        public async Task<List<ShowProductDto>> GetAllProductsAsync()
        {
            var value = await _products.Find(x=>true).ToListAsync();

            return _mapper.Map<List<ShowProductDto>>(value);
        }

        public async Task<ShowProductDto> GetProductByIdAsync(string id)
        {
            var value = await _products.Find(x=>x.ProductID == id).FirstOrDefaultAsync();

            return _mapper.Map<ShowProductDto>(value);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);

            await _products.ReplaceOneAsync(x => x.ProductID == updateProductDto.ProductID, value);
        }
    }
}
