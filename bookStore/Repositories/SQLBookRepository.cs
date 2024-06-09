using bookStore.Data;
using bookStore.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace bookStore.Repositories
{
    public class SQLBookRepository : IBookRepository
    {
        private readonly BookStoreDbContext dbContext;

        public SQLBookRepository(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await dbContext.Books.ToListAsync();
        }

        public async Task<Book> GetByIdAsync(Guid id)
        {
            return await dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Book> AddAsync(Book book)
        {
            book.Id = Guid.NewGuid();
            await dbContext.Books.AddAsync(book);
            await dbContext.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateAsync(Guid id, Book book)
        {
            var existingBook = await dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);

            if (existingBook == null)
            {
                return null;
            }

            // Update properties
            existingBook.Title = book.Title;
            existingBook.ISBN = book.ISBN;
            existingBook.Genre = book.Genre;
            existingBook.Type = book.Type;
            existingBook.PublicationYear = book.PublicationYear;
            existingBook.StockLevel = book.StockLevel;
            existingBook.Price = book.Price;
            existingBook.AuthorID = book.AuthorID;
            existingBook.PublisherID = book.PublisherID;

            await dbContext.SaveChangesAsync();
            return existingBook;
        }

        public async Task<Book> DeleteAsync(Guid id)
        {
            var book = await dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);

            if (book == null)
            {
                throw new InvalidOperationException("Book not found");
            }

            dbContext.Books.Remove(book);
            await dbContext.SaveChangesAsync();
            return book;

        }

    }
}
