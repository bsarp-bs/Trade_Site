using Trade_Site_Price_Drop.DTOs;

namespace Trade_Site_Price_Drop.Service.DiscountServiceFiles
{
    public interface IDiscountService
    {
        Task CreateDiscountAsync(InsertDiscountDto insertDiscountDto);
        Task DeleteDiscountAsync(int id);
        Task UpdateDiscountAsync(UpdateDiscountDto updateDiscountDto);

        Task<List<ShowDiscountDto>> GetDiscountAllAsync();

        Task<GetByIdDto> GetDiscountDtoByIdAsync(int id);

    }
}
