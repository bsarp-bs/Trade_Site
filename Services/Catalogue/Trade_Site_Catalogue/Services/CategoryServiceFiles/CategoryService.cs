using AutoMapper;
using MongoDB.Driver;
using Trade_Site_Catalogue.DTOs.CategoryDTOs;
using Trade_Site_Catalogue.Entity;
using Trade_Site_Catalogue.Settings;

namespace Trade_Site_Catalogue.Services.CategoryServiceFiles
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categories;
        private readonly IMapper _mapper;   

        public CategoryService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            _mapper = mapper;

            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categories = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);

        }

        public async Task CreateCategoryAsync(InsertCategoryDto insertCategoryDto)
        {
            var value = _mapper.Map<Category>(insertCategoryDto);
            await _categories.InsertOneAsync(value);
        }

        public async Task DeleteAsync(string id)
        {
            await _categories.DeleteOneAsync(x=> x.CategoryID == id);   
        }

        public async Task<List<ShowCategoryDto>> GetAllCategoriesAsync()
        {
            var values = await _categories.Find(x => true).ToListAsync();
            return _mapper.Map<List<ShowCategoryDto>>(values);
        }

        public async Task<GetByIdCategoryDto> GetCategoryByIdAsync(string id)
        {
            var values = await _categories.Find(x=>x.CategoryID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategoryDto>(values);
        }

        public async Task UpdateAsync(UpdateCategoryDto updateCategoryDto)
        {
            
            var value = _mapper.Map<Category>(updateCategoryDto);
            await _categories.ReplaceOneAsync(x => x.CategoryID == value.CategoryID, value);

        }
    }
}
