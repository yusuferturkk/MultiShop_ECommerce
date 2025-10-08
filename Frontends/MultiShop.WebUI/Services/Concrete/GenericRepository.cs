using MultiShop.WebUI.Services.Abstract;

namespace MultiShop.WebUI.Services.Concrete
{
    public class GenericRepository<TEntity, TResultDto, TByIdDto, TCreateDto, TUpdateDto> : IGenericRepository<TEntity, TResultDto, TByIdDto, TCreateDto, TUpdateDto>
        where TEntity : class
        where TResultDto : class
        where TByIdDto : class
        where TCreateDto : class
        where TUpdateDto : class
    {
        private readonly HttpClient _httpClient;

        public GenericRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task CreateContactAsync(TCreateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteContactAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TResultDto>> GetAllContactAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TUpdateDto> GetByIdContactAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateContactAsync(TUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
