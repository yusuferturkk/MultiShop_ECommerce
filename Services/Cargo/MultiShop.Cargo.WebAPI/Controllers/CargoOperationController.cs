using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationController : ControllerBase
    {
        private readonly ICargoOperationService _service;

        public CargoOperationController(ICargoOperationService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllCargoOperation()
        {
            return Ok(_service.TGetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdCargoOperation(int id)
        {
            return Ok(_service.TGetById(id));
        }

        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto dto)
        {
            CargoOperation cargoOperation = new CargoOperation
            {
                Barcode = dto.Barcode,
                Description = dto.Description,
                OperationDate = DateTime.Now,
            };

            _service.TInsert(cargoOperation);
            return Ok("Hareket ekleme işlemi başarılı.");
        }

        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto dto)
        {
            CargoOperation cargoOperation = new CargoOperation
            {
                Barcode = dto.Barcode,
                Description = dto.Description,
                OperationDate = dto.OperationDate,
            };

            _service.TUpdate(cargoOperation);
            return Ok("Hareket güncelleme işlemi başarılı.");
        }

        [HttpDelete]
        public IActionResult DeleteCargoOperation(int id)
        {
            _service.TDelete(id);
            return Ok("Hareket silme işlemi başarılı.");
        }
    }
}
