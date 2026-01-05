using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrencsanszkyPatrik_Backend.Models;

namespace TrencsanszkyPatrik_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {

        private readonly LibrarydbContext dbContext;

        public AuthorController(LibrarydbContext context)
        {
            dbContext = context;
        }

        [HttpGet("feladat9/{authorName}")]
        public async Task<ActionResult> GetAuthorWithBooks(string authorName)
        {
            var author = await dbContext.Authors
                .Where(a => a.AuthorName == authorName)
                .Select(a => new
                {
                    AuthorId = a.AuthorId,
                    AuthorName = a.AuthorName,
                    Books = a.Books.Select(b => new
                    {
                        BookId = b.BookId,
                        Title = b.Title,
                        PublishDate = b.PublishDate,
                        AuthorId = b.AuthorId,
                        CategoryId = b.CategoryId
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (author == null)
            {
                return NotFound(new
                {
                    type = "..",
                    title = "Author not found",
                    status = 404,
                    traceId = HttpContext.TraceIdentifier
                });
            }
            return Ok(author);
        }


    }
}
