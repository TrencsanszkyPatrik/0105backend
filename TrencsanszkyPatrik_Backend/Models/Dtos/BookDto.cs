namespace TrencsanszkyPatrik_Backend.Models.Dtos
{
    public class BookDto
    {
        public int bookId { get; set; }
        public string title { get; set; }
        public DateTime publishDate { get; set; }
        public int authorId { get; set; }
        public int categoryId { get; set; }
    }
}
