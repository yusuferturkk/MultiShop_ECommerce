using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomerController : ControllerBase
    {
        private readonly ICargoCustomerService _service;

        public CargoCustomerController(ICargoCustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllCargoCustomer()
        {
            return Ok(_service.TGetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdCargoCustomer(int id)
        {
            return Ok(_service.TGetById(id));
        }

        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto dto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer
            {
                Address = dto.Address,
                City = dto.City,
                District = dto.District,
                Email = dto.Email,
                Name = dto.Name,
                Surname = dto.Surname,
                Phone = dto.Phone
            };

            _service.TInsert(cargoCustomer);
            return Ok("Müşteri ekleme işlemi başarılı.");
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto dto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer
            {
                Address = dto.Address,
                City = dto.City,
                District = dto.District,
                Email = dto.Email,
                Name = dto.Name,
                Surname = dto.Surname,
                Phone = dto.Phone
            };

            _service.TUpdate(cargoCustomer);
            return Ok("Müşteri güncelleme işlemi başarılı.");
        }

        [HttpDelete]
        public IActionResult DeleteCargoCustomer(int id)
        {
            _service.TDelete(id);
            return Ok("Müşteri silme işlemi başarılı.");
        }
    }
}
