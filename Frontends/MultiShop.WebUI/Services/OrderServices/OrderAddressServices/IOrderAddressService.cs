using MultiShop.DtoLayer.OrderDtos.OrderAddressDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderAddressService
{
    public interface IOrderAddressService
    {
        //Task<GetByIdOrderAddressDto> GetByIdOrderAddressAsync();
        //Task<List<ResultOrderAddressDto>> GetAllAddressAsync();
        Task CreateAddressAsync(CreateOrderAddressDto createOrderAddressDto);
        //Task UpdateAddressAsync(UpdateOrderAddressDto addressDto);
        //Task DeleteAddressAsync(int id);
    }
}
