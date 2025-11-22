using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Message.Dtos;
using MultiShop.Message.Entities;
using MultiShop.Message.Services;
using System.Threading.Tasks;

namespace MultiShop.Message.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IUserMessageService _userMessageService;

        public MessagesController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessage()
        {
            var values = await _userMessageService.GetAllMessageAsync();
            return Ok(values);
        }

        [HttpGet("GetByIdMessage/{userMessageId}")]
        public async Task<IActionResult> GetByIdMessage(int userMessageId)
        {
            var value = await _userMessageService.GetByIdMessageAsync(userMessageId);
            return Ok(value);
        }

        [HttpGet("GetInboxMessage/{receiverId}")]
        public async Task<IActionResult> GetInboxMessage(string receiverId)
        {
            var values = await _userMessageService.GetInboxMessageAsync(receiverId);
            return Ok(values);
        }

        [HttpGet("GetSendboxMessage/{senderId}")]
        public async Task<IActionResult> GetSendboxMessage(string senderId)
        {
            var values = await _userMessageService.GetSendboxMessageAsync(senderId);
            return Ok(values);
        }

        [HttpGet("GetTotalMessageCount")]
        public async Task<IActionResult> GetTotalMessageCount()
        {
            var values = await _userMessageService.GetTotalMessageCount();
            return Ok(values);
        }

        [HttpGet("GetTotalMessageCountByReceiverId/{receiverId}")]
        public async Task<IActionResult> GetTotalMessageCountByReceiverId(string receiverId)
        {
            var values = await _userMessageService.GetTotalMessageCountByReceiverId(receiverId);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDto createMessageDto)
        {
            await _userMessageService.CreateMessageAsync(createMessageDto);
            return Ok("Mesaj başarıyla oluşturuldu.");
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            _userMessageService.UpdateMessage(updateMessageDto);
            return Ok("Mesaj başarıyla güncellendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            await _userMessageService.DeleteMessageAsync(id);
            return Ok("Mesaj başarıyla silindi.");
        }
    }
}
