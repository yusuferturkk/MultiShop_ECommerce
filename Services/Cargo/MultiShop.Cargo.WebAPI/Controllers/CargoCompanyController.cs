using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompanyController : ControllerBase
    {
        private readonly ICargoCompanyService _service;

        public CargoCompanyController(ICargoCompanyService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllCargoCompany()
        {
            return Ok(_service.TGetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdCargoCompany(int id)
        {
            return Ok(_service.TGetById(id));
        }

        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDto dto)
        {
            CargoCompany cargoCompany = new CargoCompany
            {
                CargoCompanyName = dto.CargoCompanyName,
            };

            _service.TInsert(cargoCompany);
            return Ok("Kargo firması ekleme işlemi başarılı.");
        }

        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto dto)
        {
            var value = _service.TGetById(dto.CargoCompanyId);
            value.CargoCompanyName = dto.CargoCompanyName;
            _service.TUpdate(value);
            return Ok("Kargo firması güncelleme işlemi başarılı.");
        }

        [HttpDelete]
        public IActionResult DeleteCargoCompany(int id)
        {
            _service.TDelete(id);
            return Ok("Kargo firması silme işlemi başarılı.");
        }
    }
}
