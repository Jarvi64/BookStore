using bookStore.Models.Domain;

namespace bookStore.Repositories
{
    public interface IPublisherRepository
    {
        Task<List<Publisher>> GetAllAsync();
        Task<Publisher> GetByIdAsync(Guid id);
        Task<Publisher> AddAsync(Publisher book);
        Task<Publisher> UpdateAsync(Guid id, Publisher book);
        Task<Publisher> DeleteAsync(Guid id);
    }
}
