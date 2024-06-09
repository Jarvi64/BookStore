using bookStore.Data;
using bookStore.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace bookStore.Repositories
{
    public class SQLOrderItemRepository : IOrderItemRepository
    {
        private readonly BookStoreDbContext dbContext;

        public SQLOrderItemRepository(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<OrderItem>> GetAllAsync()
        {
            return await dbContext.OrderItems.ToListAsync();
        }

        public async Task<OrderItem> GetByIdAsync(Guid id)
        {
            return await dbContext.OrderItems.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<OrderItem> AddAsync(OrderItem orderItem)
        {
            orderItem.Id = Guid.NewGuid();
            await dbContext.OrderItems.AddAsync(orderItem);
            await dbContext.SaveChangesAsync();
            return orderItem;
        }

        public async Task<OrderItem> UpdateAsync(Guid id, OrderItem orderItem)
        {
            var existingOrderItem = await dbContext.OrderItems.FirstOrDefaultAsync(a => a.Id == id);

            if (existingOrderItem == null)
            {
                throw new InvalidOperationException("OrderItem not found");
            }

            existingOrderItem.BookID = orderItem.BookID;
            existingOrderItem.OrderID = orderItem.OrderID;
            existingOrderItem.Quantity = orderItem.Quantity;
            existingOrderItem.Price = orderItem.Price;

            await dbContext.SaveChangesAsync();
            return existingOrderItem;
        }

        public async Task<OrderItem> DeleteAsync(Guid id)
        {
            var orderItem = await dbContext.OrderItems.FirstOrDefaultAsync(a => a.Id == id);

            if (orderItem == null)
            {
                return null;
            }

            dbContext.OrderItems.Remove(orderItem);
            await dbContext.SaveChangesAsync();
            return orderItem;
        }
    }
}
