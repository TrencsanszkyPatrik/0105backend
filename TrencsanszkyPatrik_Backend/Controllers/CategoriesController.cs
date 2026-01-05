using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrencsanszkyPatrik_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace TrencsanszkyPatrik_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly LibrarydbContext dbContext;

        public CategoriesController(LibrarydbContext context)
        {
            dbContext = context;
        }

        [HttpGet("feladat11")]
        public async Task<ActionResult> GetCategoriesWithBooks()
        {
            {
                var categories = await dbContext.Categories
                    .Include(c => c.Books) 
                    .Select(c => new
                    {
                        c.CategoryId,
                        c.CategoryName,
                        Books = c.Books.Select(b => new
                        {
                            b.BookId,
                            b.Title,
                            b.PublishDate,
                            b.AuthorId,
                            b.CategoryId
                        })
                    })
                    .ToListAsync();

                if (categories == null)
                {
                    return StatusCode(400, "Unable to connect to database");
                }
                else
                {
                    return Ok(categories);
                }

            }
        }
    }
}