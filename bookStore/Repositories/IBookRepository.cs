using bookStore.Models.Domain;

namespace bookStore.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(Guid id);
        Task<Book> AddAsync(Book book);
        Task<Book> UpdateAsync(Guid id,Book book);
        Task<Book> DeleteAsync(Guid id);
    }
}
