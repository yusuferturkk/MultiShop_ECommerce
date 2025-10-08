using MultiShop.WebUI.Services.Concrete;

namespace MultiShop.WebUI.Services.Abstract
{
    public interface IClientAccessTokenCache
    {
        Task<ClientAccessToken?> GetAsync(string key);
        Task SetAsync(string key, string accessToken, int expiresInSeconds);
    }
}
