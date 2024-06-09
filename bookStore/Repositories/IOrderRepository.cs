using bookStore.Models.Domain;

namespace bookStore.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(Guid id);
        Task<Order> AddAsync(Order order);
        Task<Order> UpdateAsync(Guid id, Order order);
        Task<Order> DeleteAsync(Guid id);
    }
}
