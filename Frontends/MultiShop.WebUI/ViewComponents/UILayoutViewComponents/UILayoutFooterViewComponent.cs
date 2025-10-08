using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;
using Newtonsoft.Json;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class UILayoutFooterViewComponent : ViewComponent
    {
        private readonly IAboutService _aboutService;
        public UILayoutFooterViewComponent(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _aboutService.GetAllAboutAsync();
            return View(values);
        }
    }
}
