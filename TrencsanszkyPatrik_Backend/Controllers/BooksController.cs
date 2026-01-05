using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrencsanszkyPatrik_Backend.Models;

namespace TrencsanszkyPatrik_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly LibrarydbContext dbContext;
        public BooksController(LibrarydbContext context)
        {
            dbContext = context;
        }

        [HttpGet("feladat10")]
        public async Task<ActionResult> GetAllBooks()
        {

            var books = await dbContext.Books
                .Select(b => new
                {
                    BookId = b.BookId,
                    Title = b.Title,
                    PublishDate = b.PublishDate,
                    AuthorId = b.AuthorId,
                    CategoryId = b.CategoryId
                })
                .ToListAsync();
            return Ok(books);

        }

    }
}
