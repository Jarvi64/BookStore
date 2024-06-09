using bookStore.Data;
using bookStore.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace bookStore.Repositories
{
    public class SQLOrderRepository:IOrderRepository
    {
        private readonly BookStoreDbContext dbContext;

        public SQLOrderRepository(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await dbContext.Orders.Include(x => x.OrderItems).ToListAsync();
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            return await dbContext.Orders.Include(a => a.OrderItems).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Order> AddAsync(Order order)
        {
            order.Id = Guid.NewGuid();
            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<Order> UpdateAsync(Guid id, Order order)
        {
            var existingOrder = await dbContext.Orders.FirstOrDefaultAsync(a => a.Id == id);

            if (existingOrder == null)
            {
                throw new InvalidOperationException("Order not found");
            }

            existingOrder.Subtotal = order.Subtotal;
            existingOrder.Shipping = order.Shipping;
            existingOrder.Total = order.Total;

            await dbContext.SaveChangesAsync();
            return existingOrder;
        }

        public async Task<Order> DeleteAsync(Guid id)
        {
            var order = await dbContext.Orders.FirstOrDefaultAsync(a => a.Id == id);

            if (order == null)
            {
                return null;
            }

            dbContext.Orders.Remove(order);
            await dbContext.SaveChangesAsync();
            return order;
        }
    }
}
