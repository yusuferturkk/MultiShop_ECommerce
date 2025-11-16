using MultiShop.DtoLayer.MessageDtos;

namespace MultiShop.WebUI.Services.MessageServices
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;

        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string receiverId)
        {
            var responseMessage = await _httpClient.GetAsync("https://localhost:5000/services/message/Messages/GetInboxMessage/" + receiverId);
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultInboxMessageDto>>();
            return values;
        }

        public async Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string senderId)
        {
            var responseMessage = await _httpClient.GetAsync("https://localhost:5000/services/message/Messages/GetSendboxMessage/" + senderId);
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultSendboxMessageDto>>();
            return values;
        }
    }
}
