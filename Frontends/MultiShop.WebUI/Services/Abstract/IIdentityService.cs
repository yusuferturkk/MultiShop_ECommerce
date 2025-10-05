using MultiShop.DtoLayer.IdentityDtos.LoginDto;

namespace MultiShop.WebUI.Services.Abstract
{
    public interface IIdentityService
    {
        Task<bool> SignIn(SignInDto signInDto);
        Task<bool> GetRefreshToken();
    }
}
