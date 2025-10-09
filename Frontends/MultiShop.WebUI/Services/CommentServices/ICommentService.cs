using MultiShop.DtoLayer.CommentDtos;

namespace MultiShop.WebUI.Services.CommentServices
{
    public interface ICommentService
    {
        Task<UpdateCommentDto> GetByIdCommentAsync(string id);
        Task<List<ResultCommentDto>> GetCommentListByProductId(string id);
        Task<List<ResultCommentDto>> GetAllCommentAsync();
        Task CreateCommentAsync(CreateCommentDto createCommentDto);
        Task UpdateCommentAsync(UpdateCommentDto updateCommentDto);
        Task DeleteCommentAsync(string id);
    }
}
