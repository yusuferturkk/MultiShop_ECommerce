using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class ProductListProductsViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductListProductsViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Products/GetProductsWithByCategoryId?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductsWithCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
