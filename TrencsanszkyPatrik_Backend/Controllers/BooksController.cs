using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrencsanszkyPatrik_Backend.Models;
using TrencsanszkyPatrik_Backend.Models.Dtos;

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
            
            if (books == null)
            {
                return StatusCode(400, "Unable to connect to database");
            } else
            {
                return Ok(books);   
            }

        }


        private const string UID = "FKB3F4FEA09CE43C";

        [HttpPost("feladat13")]
        public async Task<ActionResult> AddBook([FromBody] CreateBookDto newBook, [FromHeader] string uid)
        {

            if (uid != UID)
            {
                return Unauthorized("Nincs jogosultsága új könyv felvételéhez!");
            }
            var book = new Book
            {
                Title = newBook.Title,
                PublishDate = newBook.PublishDate,
                AuthorId = newBook.AuthorId,
                CategoryId = newBook.CategoryId

            };
            dbContext.Books.Add(book);
            await dbContext.SaveChangesAsync();
            return Ok(new
            {
                Message = "Könyv sikeresen hozzáadva!",
                Book = new
                {
                    book.BookId,
                    book.Title,
                    book.PublishDate,
                    book.AuthorId,
                    book.CategoryId
                }
            });


        }

    }
}
