using MultiShop.DtoLayer.OrderDtos.OrderOrderingDtos;
using MultiShop.WebUI.Services.OrderServices.OrderingServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.OrderServices.OrderOrderingServices
{
    public class OrderingService : IOrderingService
    {
        private readonly HttpClient _httpClient;

        public OrderingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultOrderingByUserId>> GetOrderingByUserId(string userId)
        {
            var responseMessage = await _httpClient.GetAsync($"https://localhost:7072/api/Orderings/GetOrderingByUserId/{userId}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultOrderingByUserId>>(jsonData);
            return value;
        }
    }
}
