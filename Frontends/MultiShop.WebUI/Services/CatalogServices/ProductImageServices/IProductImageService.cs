using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public interface IProductImageService
    {
        Task<UpdateProductImageDto> GetByIdProductImageAsync(string id);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
    }
}
