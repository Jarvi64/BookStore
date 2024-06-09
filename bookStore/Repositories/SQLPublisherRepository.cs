using bookStore.Data;
using bookStore.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bookStore.Repositories
{
    public class SQLPublisherRepository : IPublisherRepository
    {
        private readonly BookStoreDbContext dbContext;

        public SQLPublisherRepository(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Publisher>> GetAllAsync()
        {
            return await dbContext.Publishers.ToListAsync();
        }

        public async Task<Publisher> GetByIdAsync(Guid id)
        {
            return await dbContext.Publishers.Include(p => p.Books).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Publisher> AddAsync(Publisher publisher)
        {
            publisher.Id = Guid.NewGuid();
            await dbContext.Publishers.AddAsync(publisher);
            await dbContext.SaveChangesAsync();
            return publisher;
        }

        public async Task<Publisher> UpdateAsync(Guid id, Publisher publisher)
        {
            var existingPublisher = await dbContext.Publishers.FirstOrDefaultAsync(p => p.Id == id);

            if (existingPublisher == null)
            {
                throw new InvalidOperationException("Publisher not found");
            }

            existingPublisher.Country = publisher.Country;
            existingPublisher.Name = publisher.Name;
            existingPublisher.Email = publisher.Email;
            existingPublisher.WebSite = publisher.WebSite;

            await dbContext.SaveChangesAsync();
            return existingPublisher;
        }

        public async Task<Publisher> DeleteAsync(Guid id)
        {
            var publisher = await dbContext.Publishers.FirstOrDefaultAsync(p => p.Id == id);

            if (publisher == null)
            {
                return null;
            }

            dbContext.Publishers.Remove(publisher);
            await dbContext.SaveChangesAsync();
            return publisher;
        }
    }
}
