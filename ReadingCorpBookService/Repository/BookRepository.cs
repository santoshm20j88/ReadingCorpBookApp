using Microsoft.EntityFrameworkCore;
using ReadingCorpBookApp.Domain.Models;
using ReadingCorpBookApp.Service.Data;
using ReadingCorpBookApp.Service.Infrastructure.Contract;

namespace ReadingCorpBookApp.Service.Repository
{
    public class BookRepository : IBaseRepository<Book>
    {
        private readonly BookDbContext _context;
        public BookRepository(BookDbContext context) 
        {
            this._context = context;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _context.Books.Include(x => x.Author).ToListAsync();
        }

        public async Task<Book> CreateBook(Book book)
        {
            await _context.Books.AddAsync(book);
            return book;
        }

        public Book UpdateBook(int id, Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            return book;
        }

        public async Task SaveChangestoDatabase()
        {
            await _context.SaveChangesAsync();
        }
    }
}
