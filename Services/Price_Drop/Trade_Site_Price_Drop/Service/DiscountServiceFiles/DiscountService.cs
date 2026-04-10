using Dapper;
using Trade_Site_Price_Drop.Context;
using Trade_Site_Price_Drop.DTOs;
using Trade_Site_Price_Drop.Entity;

namespace Trade_Site_Price_Drop.Service.DiscountServiceFiles
{
    public class DiscountService : IDiscountService
    {
        private readonly PriceDropContextFactory _priceDropContextFactory;

        public DiscountService(PriceDropContextFactory priceDropContextFactory)
        {
            _priceDropContextFactory = priceDropContextFactory;
        }

        public async Task CreateDiscountAsync(InsertDiscountDto insertDiscountDto)
        {
            string query = "insert into Discounts (DiscountCode, DiscountRate,DiscountStatus,DiscountEndDate) values (@DiscountCode, @DiscountRate,@DiscountStatus,@DiscountEndDate)";
            var parameters = new DynamicParameters();

            parameters.Add("@DiscountCode", insertDiscountDto.DiscountCode);
            parameters.Add("@DiscountRate", insertDiscountDto.DiscountRate);
            parameters.Add("@DiscountStatus", insertDiscountDto.DiscountStatus);
            parameters.Add("@DiscountEndDate", insertDiscountDto.DiscountEndDate);

            using (var connection = _priceDropContextFactory.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteDiscountAsync(int id)
        {
            string query = "delete from Discounts where DiscountID = @id";
            var parameters = new DynamicParameters();

            parameters.Add("@id", id);
            using (var connection = _priceDropContextFactory.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetByIdDto> GetDiscountDtoByIdAsync(int id)
        {
            string query = "select * from Discounts where DiscountID = @id";
            var parameters = new DynamicParameters();

            parameters.Add("@id", id);

            using (var connection = _priceDropContextFactory.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<ShowDiscountDto>> GetDiscountAllAsync()
        {
            string query = "select * from Discounts";
            using (var connection = _priceDropContextFactory.CreateConnection())
            { 
                var values = await connection.QueryAsync<ShowDiscountDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateDiscountAsync(UpdateDiscountDto updateDiscountDto)
        {
            string query = "update Discounts set DiscountCode = @DiscountCode, DiscountRate = @DiscountRate, " +
                "DiscountStatus = @DiscountStatus, DiscountEndDate = @DiscountEndDate where DiscountID = @DiscountID";
            var parameters = new DynamicParameters();

            parameters.Add("@DiscountID", updateDiscountDto.DiscountID);
            parameters.Add("@DiscountCode", updateDiscountDto.DiscountCode);
            parameters.Add("@DiscountRate", updateDiscountDto.DiscountRate);
            parameters.Add("@DiscountStatus", updateDiscountDto.DiscountStatus);
            parameters.Add("@DiscountEndDate", updateDiscountDto.DiscountEndDate);

            using (var connection = _priceDropContextFactory.CreateConnection())
            { 
                await connection.ExecuteAsync(query, parameters);
            }


        }
    }
}
