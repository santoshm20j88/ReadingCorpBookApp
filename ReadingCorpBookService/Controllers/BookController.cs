using Microsoft.AspNetCore.Mvc;
using ReadingCorpBookApp.Domain.Models;
using ReadingCorpBookApp.Service.Infrastructure.Contract;

namespace ReadingCorpBookApp.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBaseRepository<Book> _baseRepo;
        public BookController(IBaseRepository<Book> baseRepo)
        {
            this._baseRepo = baseRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await _baseRepo.GetBooks();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            await _baseRepo.CreateBook(book);
            await _baseRepo.SaveChangestoDatabase();
            return Ok(book);
        }

        [HttpPut("{bookId}")]
        public async Task<IActionResult> Update(int bookId, Book book)
        {
            if (bookId != book.Id) return BadRequest();

            _baseRepo.UpdateBook(bookId, book);
            await _baseRepo.SaveChangestoDatabase();
            return Ok(book);
        }


    }
}
