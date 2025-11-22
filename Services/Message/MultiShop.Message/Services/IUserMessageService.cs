using MultiShop.Message.Dtos;

namespace MultiShop.Message.Services
{
    public interface IUserMessageService
    {
        Task<GetByIdMessageDto> GetByIdMessageAsync(int userMessageId);
        Task<List<ResultMessageDto>> GetAllMessageAsync();
        Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string receiverId);
        Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string senderId);
        Task CreateMessageAsync(CreateMessageDto createMessageDto);
        void UpdateMessage(UpdateMessageDto updateMessageDto);
        Task DeleteMessageAsync(int id);
        Task<int> GetTotalMessageCount();
        Task<int> GetTotalMessageCountByReceiverId(string id);
    }
}
