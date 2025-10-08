using Microsoft.Extensions.Caching.Memory;
using MultiShop.WebUI.Services.Abstract;

namespace MultiShop.WebUI.Services.Concrete
{
    public class InMemoryClientAccessTokenCache : IClientAccessTokenCache
    {
        private readonly IMemoryCache _memoryCache;

        public InMemoryClientAccessTokenCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Task<ClientAccessToken?> GetAsync(string key)
        {
            if (_memoryCache.TryGetValue(key, out ClientAccessToken token))
            {
                if (token.Expiration < DateTimeOffset.UtcNow)
                {
                    _memoryCache.Remove(key);
                    return Task.FromResult<ClientAccessToken?>(null);
                }
                return Task.FromResult<ClientAccessToken?>(token);
            }
            return Task.FromResult<ClientAccessToken?>(null);
        }

        public Task SetAsync(string key, string accessToken, int expiresInSeconds)
        {
            var token = new ClientAccessToken
            {
                AccessToken = accessToken,
                Expiration = DateTimeOffset.UtcNow.AddSeconds(expiresInSeconds)
            };

            _memoryCache.Set(key, token, token.Expiration);
            return Task.CompletedTask;
        }
    }
}
