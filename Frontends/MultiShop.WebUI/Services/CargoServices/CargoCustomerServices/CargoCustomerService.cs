using MultiShop.DtoLayer.CargoDtos.CargoCustomerDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CargoServices.CargoCustomerServices
{
    public class CargoCustomerService : ICargoCustomerService
    {
        private readonly HttpClient _httpClient;

        public CargoCustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetByIdCargoCustomerDto> GetByIdCargoCustomerAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("CargoCustomer/GetCargoCustomerById/" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<GetByIdCargoCustomerDto>(jsonData);
            return values;
        }
    }
}
