using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class ProductListProductsViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public ProductListProductsViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productService.GetProductsWithByCategoryIdAsync(id);
            return View(values);
        }
    }
}
