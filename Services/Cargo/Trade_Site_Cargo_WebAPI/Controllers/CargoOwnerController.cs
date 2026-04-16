using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Trade_Site_Cargo_BusinessLayer.Services;
using Trade_Site_Cargo_DtoLayer.DTOs.CargoOwnerDTOs;
using Trade_Site_Cargo_EntityLayer.Concrete;

namespace Trade_Site_Cargo_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOwnerController : ControllerBase
    {
        private readonly ICargoOwnerService _cargoOwnerService;
        private readonly IMapper _mapper;

        public CargoOwnerController(ICargoOwnerService cargoOwnerService, IMapper mapper)
        {
            _cargoOwnerService = cargoOwnerService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCargoOwner()
        {
            var value = _cargoOwnerService.GetAllBL();
            var result = _mapper.Map<List<GetListCargoOwnerDto>>(value);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddCargoOwner(CreateCargoOwnerDto cargoOwner)
        {
            var cargoOwnerEntity = _mapper.Map<CargoOwner>(cargoOwner);
            _cargoOwnerService.CreateBL(cargoOwnerEntity);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCargoOwner(UpdateCargoOwnerDto cargoOwner)
        {
            var cargoOwnerEntity = _mapper.Map<CargoOwner>(cargoOwner);
            _cargoOwnerService.UpdateBL(cargoOwnerEntity);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCargoOwner(int id)
        {
            var value = _cargoOwnerService.GetByIdBL(id);

            if (value == null)
            {
                return NotFound();
            }

            _cargoOwnerService.DeleteBL(value);
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoOwnerById(int id)
        {
            var value = _cargoOwnerService.GetByIdBL(id);

            if (value == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<GetByIdCargoOwnerDto>(value);
            return Ok(result);
        }
    }
}
