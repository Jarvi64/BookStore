using bookStore.Models.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace bookStore.Data
{
    public class BookStoreAuthDbContext : IdentityDbContext<Customer>
    {
        public BookStoreAuthDbContext(DbContextOptions<BookStoreAuthDbContext> options) : base(options)
        {
        }
    }
}
