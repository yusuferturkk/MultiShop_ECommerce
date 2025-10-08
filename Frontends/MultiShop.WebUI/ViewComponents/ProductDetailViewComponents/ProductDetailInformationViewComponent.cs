using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class ProductDetailInformationViewComponent : ViewComponent
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailInformationViewComponent(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var value = await _productDetailService.GetByIdProductDetailAsync(id);
            return View(value);
        }
    }
}
