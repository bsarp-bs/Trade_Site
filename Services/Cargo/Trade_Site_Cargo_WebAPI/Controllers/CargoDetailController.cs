using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trade_Site_Cargo_BusinessLayer.Services;
using Trade_Site_Cargo_DtoLayer.DTOs.CargoDetailDTOs;
using Trade_Site_Cargo_DtoLayer.DTOs.MapperConfig;
using Trade_Site_Cargo_EntityLayer.Concrete;

namespace Trade_Site_Cargo_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;
        private readonly IMapper _mapper;

        public CargoDetailController(ICargoDetailService cargoDetailService, IMapper mapper)
        {
            _cargoDetailService = cargoDetailService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCargoDetail()
        {
            var value = _cargoDetailService.GetAllBL();
            var result = _mapper.Map<List<GetListCargoDetailDto>>(value);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddCargoDetail(CreateCargoDetailDto cargoDetail)
        {
            var value = _mapper.Map<CargoDetail>(cargoDetail);
            _cargoDetailService.CreateBL(value);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto cargoDetail)
        { 
            var value = _mapper.Map<CargoDetail>(cargoDetail);
            _cargoDetailService.UpdateBL(value);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCargoDetail(int id)
        {
            var value = _cargoDetailService.GetByIdBL(id);
            _cargoDetailService.DeleteBL(value);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var value = _cargoDetailService.GetByIdBL(id);
            var result = _mapper.Map<GetByIdCargoDetailDto>(value);
            return Ok(result);
        }
    }
}
