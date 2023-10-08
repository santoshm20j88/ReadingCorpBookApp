using Microsoft.EntityFrameworkCore;
using ReadingCorpBookApp.Domain.Models;

namespace ReadingCorpBookApp.Service.Data
{
    public class BookDbContext: DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
