using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Trade_Site_Cargo_BusinessLayer.Services;
using Trade_Site_Cargo_DtoLayer.DTOs.CargoStatusDTOs;
using Trade_Site_Cargo_EntityLayer.Concrete;

namespace Trade_Site_Cargo_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoStatusController : ControllerBase
    {
        private readonly ICargoStatusService _cargoStatusService;
        private readonly IMapper _mapper;

        public CargoStatusController(ICargoStatusService cargoStatusService, IMapper mapper)
        {
            _cargoStatusService = cargoStatusService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCargoStatus()
        {
            var value = _cargoStatusService.GetAllBL();
            var result = _mapper.Map<List<GetListCargoStatusDto>>(value);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddCargoStatus(CreateCargoStatusDto cargoStatus)
        {
            var cargoStatusEntity = _mapper.Map<CargoStatus>(cargoStatus);
            _cargoStatusService.CreateBL(cargoStatusEntity);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCargoStatus(UpdateCargoStatusDto cargoStatus)
        {
            var cargoStatusEntity = _mapper.Map<CargoStatus>(cargoStatus);
            _cargoStatusService.UpdateBL(cargoStatusEntity);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCargoStatus(int id)
        {
            var value = _cargoStatusService.GetByIdBL(id);

            if (value == null)
            {
                return NotFound();
            }

            _cargoStatusService.DeleteBL(value);
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoStatusById(int id)
        {
            var value = _cargoStatusService.GetByIdBL(id);

            if (value == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<GetByIdCargoStatusDto>(value);
            return Ok(result);
        }
    }
}
