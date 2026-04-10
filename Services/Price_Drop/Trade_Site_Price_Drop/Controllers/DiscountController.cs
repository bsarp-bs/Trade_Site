using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trade_Site_Price_Drop.DTOs;
using Trade_Site_Price_Drop.Service.DiscountServiceFiles;

namespace Trade_Site_Price_Drop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDiscounts()
        {
            var discounts = await _discountService.GetDiscountAllAsync();
            return Ok(discounts);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscount(int id)
        { 
           await _discountService.DeleteDiscountAsync(id);
           return Ok();

        }

        [HttpPost]
        public async Task<IActionResult> InsertDiscount(InsertDiscountDto insertDiscountDto)
        {
            await _discountService.CreateDiscountAsync(insertDiscountDto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscount(UpdateDiscountDto updatediscountdto)
        { 
            await _discountService.UpdateDiscountAsync(updatediscountdto);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdDiscount(int id)
        { 
            var value = await _discountService.GetDiscountDtoByIdAsync(id);
            return Ok(value);

        }


    }
}
