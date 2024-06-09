        using bookStore.Data;
        using bookStore.Models.Domain;
        using Microsoft.EntityFrameworkCore;

        namespace bookStore.Repositories
        {
            public class SQLAuthorRepository:IAuthorRepository
            {
                private readonly BookStoreDbContext dbContext;

                public SQLAuthorRepository(BookStoreDbContext dbContext)
                {
                    this.dbContext = dbContext;
                }

                public async Task<List<Author>> GetAllAsync()
                {
                    return await dbContext.Authors.Include(x=>x.Books).ToListAsync();
                }

                public async Task<Author> GetByIdAsync(Guid id)
                {
                    return await dbContext.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == id);
                }

                public async Task<Author> AddAsync(Author author)
                {
                    author.Id = Guid.NewGuid();
                    await dbContext.Authors.AddAsync(author);
                    await dbContext.SaveChangesAsync();
                    return author;
                }

                public async Task<Author> UpdateAsync(Guid id, Author author)
                {
                    var existingAuthor = await dbContext.Authors.FirstOrDefaultAsync(a => a.Id == id);

                    if (existingAuthor == null)
                    {
                        throw new InvalidOperationException("Author not found");
                    }

                    existingAuthor.FirstName = author.FirstName;
                    existingAuthor.LastName = author.LastName;

                    await dbContext.SaveChangesAsync();
                    return existingAuthor;
                }

                public async Task<Author> DeleteAsync(Guid id)
                {
                    var author = await dbContext.Authors.FirstOrDefaultAsync(a => a.Id == id);

                    if (author == null)
                    {
                        return null;
                    }

                    dbContext.Authors.Remove(author);
                    await dbContext.SaveChangesAsync();
                    return author;
                }
            }
        }
