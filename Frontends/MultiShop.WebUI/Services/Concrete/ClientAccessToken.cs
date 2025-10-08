namespace MultiShop.WebUI.Services.Concrete
{
    public class ClientAccessToken
    {
        public string AccessToken { get; set; } = string.Empty;
        public DateTimeOffset Expiration { get; set; }
    }
}
