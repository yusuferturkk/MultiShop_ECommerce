using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MultiShop.Message.Context;
using MultiShop.Message.Dtos;
using MultiShop.Message.Entities;

namespace MultiShop.Message.Services
{
    public class UserMessageService : IUserMessageService
    {
        private readonly MessageContext _messageContext;
        private readonly IMapper _mapper;

        public UserMessageService(MessageContext messageContext, IMapper mapper)
        {
            _messageContext = messageContext;
            _mapper = mapper;
        }

        public async Task CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            await _messageContext.UserMessages.AddAsync(_mapper.Map<UserMessage>(createMessageDto));
            await _messageContext.SaveChangesAsync();
        }

        public async Task DeleteMessageAsync(int id)
        {
            var value = await _messageContext.UserMessages.FindAsync(id);
            _messageContext.UserMessages.Remove(value);
            await _messageContext.SaveChangesAsync();
        }

        public async Task<List<ResultMessageDto>> GetAllMessageAsync()
        {
            var value = await _messageContext.UserMessages.ToListAsync();
            return _mapper.Map<List<ResultMessageDto>>(value);
        }

        public async Task<GetByIdMessageDto> GetByIdMessageAsync(int userMessageId)
        {
            var value = await _messageContext.UserMessages.FindAsync(userMessageId);
            return _mapper.Map<GetByIdMessageDto>(value);
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string receiverId)
        {
            var values = await _messageContext.UserMessages.Where(x => x.ReceiverId == receiverId).ToListAsync();
            return _mapper.Map<List<ResultInboxMessageDto>>(values);
        }

        public async Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string senderId)
        {
            var values = await _messageContext.UserMessages.Where(x => x.SenderId == senderId).ToListAsync();
            return _mapper.Map<List<ResultSendboxMessageDto>>(values);
        }

        public void UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            _messageContext.UserMessages.Update(_mapper.Map<UserMessage>(updateMessageDto));
            _messageContext.SaveChanges();
        }
    }
}
