using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Trade_Site_Cargo_BusinessLayer.Services;
using Trade_Site_Cargo_DtoLayer.DTOs.CargoCabDTOs;
using Trade_Site_Cargo_EntityLayer.Concrete;

namespace Trade_Site_Cargo_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCabController : ControllerBase
    {
        private readonly ICargoCabService _cargoCabService;
        private readonly IMapper _mapper;

        public CargoCabController(ICargoCabService cargoCabService, IMapper mapper)
        {   
            _cargoCabService = cargoCabService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCargoCab()
        {
            var value = _cargoCabService.GetAllBL();
            var result = _mapper.Map<List<GetListCargoCabDto>>(value);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddCargoCab(CreateCargoCabDto cargoCab)
        {
            var cargoCabEntity = _mapper.Map<CargoCab>(cargoCab);
            _cargoCabService.CreateBL(cargoCabEntity);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCargoCab(UpdateCargoCabDto  cargoCab)
        {
            var cargoCabEntity = _mapper.Map<CargoCab>(cargoCab);
            _cargoCabService.UpdateBL(cargoCabEntity);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCargoCab(int id)
        {
            var value = _cargoCabService.GetByIdBL(id);
            _cargoCabService.DeleteBL(value);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCabById(int id)
        {
            var value = _cargoCabService.GetByIdBL(id);
            var result = _mapper.Map<GetByIdCargoCabDto>(value);
            return Ok(result);
        }
    }
}
