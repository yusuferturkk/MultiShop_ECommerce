namespace MultiShop.WebUI.Services.Abstract
{
    public interface IGenericRepository<TEntity, TResultDto, TByIdDto, TCreateDto, TUpdateDto>
        where TEntity : class
        where TResultDto : class
        where TByIdDto : class
        where TCreateDto : class
        where TUpdateDto : class
    {
        Task<TUpdateDto> GetByIdContactAsync(string id);
        Task<List<TResultDto>> GetAllContactAsync();
        Task CreateContactAsync(TCreateDto dto);
        Task UpdateContactAsync(TUpdateDto dto);
        Task DeleteContactAsync(string id);
    }
}
