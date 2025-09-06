using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailController : ControllerBase
    {
        private readonly ICargoDetailService _service;

        public CargoDetailController(ICargoDetailService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllCargoDetail()
        {
            return Ok(_service.TGetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdCargoDetail(int id)
        {
            return Ok(_service.TGetById(id));
        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto dto)
        {
            CargoDetail cargoDetail = new CargoDetail
            {
                Barcode = dto.Barcode,
                CargoCompanyId = dto.CargoCompanyId,
                ReceiverCustomer = dto.ReceiverCustomer,
                SenderCustomer = dto.SenderCustomer
            };

            _service.TInsert(cargoDetail);
            return Ok("Kargo detayı ekleme işlemi başarılı.");
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto dto)
        {
            CargoDetail cargoDetail = new CargoDetail
            {
                Barcode = dto.Barcode,
                CargoCompanyId = dto.CargoCompanyId,
                ReceiverCustomer = dto.ReceiverCustomer,
                SenderCustomer = dto.SenderCustomer
            };

            _service.TUpdate(cargoDetail);
            return Ok("Kargo detayı güncelleme işlemi başarılı.");
        }

        [HttpDelete]
        public IActionResult DeleteCargoDetail(int id)
        {
            _service.TDelete(id);
            return Ok("Kargo detayı silme işlemi başarılı.");
        }
    }
}
