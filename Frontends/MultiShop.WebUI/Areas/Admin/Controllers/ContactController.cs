using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ContactDtos;
using MultiShop.WebUI.Services.CatalogServices.ContactServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Contact")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ContactViewBagList();
            var values = await _contactService.GetAllContactAsync();
            return View(values);
        }

        [Route("CreateContact")]
        [HttpGet]
        public IActionResult CreateContact()
        {
            ContactViewBagList();
            return View();
        }

        [Route("CreateContact")]
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            await _contactService.CreateContactAsync(createContactDto);
            return RedirectToAction("Index", "Contact", new { area = "Admin" });
        }

        [Route("DeleteContact/{id}")]
        public async Task<IActionResult> DeleteContact(string id)
        {
            await _contactService.DeleteContactAsync(id);
            return RedirectToAction("Index", "Contact", new { area = "Admin" });
        }

        [Route("UpdateContact/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateContact(string id)
        {
            ContactViewBagList();
            var value = await _contactService.GetByIdContactAsync(id);
            return View(value);
        }

        [Route("UpdateContact/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {
            await _contactService.UpdateContactAsync(updateContactDto);
            return RedirectToAction("Index", "Contact", new { area = "Admin" });
        }

        void ContactViewBagList()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "İletişim Bilgisi";
            ViewBag.v3 = "İletişim Bilgisi Listesi";
            ViewBag.v0 = "İletişim Bilgisi İşlemleri";
        }
    }
}
