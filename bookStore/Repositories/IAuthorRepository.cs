using bookStore.Models.Domain;

namespace bookStore.Repositories
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAsync();
        Task<Author> GetByIdAsync(Guid id);
        Task <Author> AddAsync(Author author);
        Task <Author> UpdateAsync(Guid id, Author author);
        Task <Author> DeleteAsync(Guid id);
    }
}
