using bookStore.Models.Domain;

namespace bookStore.Repositories
{
    public interface IOrderItemRepository
    {
        Task<List<OrderItem>> GetAllAsync();
        Task<OrderItem> GetByIdAsync(Guid id);
        Task<OrderItem> AddAsync(OrderItem orderItem);
        Task<OrderItem> UpdateAsync(Guid id, OrderItem orderItem);
        Task<OrderItem> DeleteAsync(Guid id);
    }
}
