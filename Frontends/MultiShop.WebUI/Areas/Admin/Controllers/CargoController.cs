using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;
using MultiShop.WebUI.Services.CargoServices.CargoCompanyServices;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Cargo")]
    public class CargoController : Controller
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _cargoCompanyService.GetAllCargoCompanyAsync();
            return View(values);
        }

        [Route("CreateCargoCompany")]
        [HttpGet]
        public IActionResult CreateCargoCompany()
        {
            return View();
        }

        [Route("CreateCargoCompany")]
        [HttpPost]
        public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            await _cargoCompanyService.CreateCargoCompanyAsync(createCargoCompanyDto);
            return RedirectToAction("Index", "Cargo", new { area = "Admin" });
        }

        [Route("DeleteCargoCompany/{id}")]
        public async Task<IActionResult> DeleteCargoCompany(int id)
        {
            await _cargoCompanyService.DeleteCargoCompanyAsync(id);
            return RedirectToAction("Index", "Cargo", new { area = "Admin" });
        }

        [Route("UpdateCargoCompany/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateCargoCompany(int id)
        {
            var value = await _cargoCompanyService.GetByIdCargoCompanyAsync(id);
            return View(value);
        }

        [Route("UpdateCargoCompany/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            await _cargoCompanyService.UpdateCargoCompanyAsync(updateCargoCompanyDto);
            return RedirectToAction("Index", "Cargo", new { area = "Admin" });
        }
    }
}
