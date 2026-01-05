namespace TrencsanszkyPatrik_Backend.Models.Dtos
{
    public class AuthorDto
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; } 
        public ICollection<BookDto> Books { get; set; } 
    }
}
