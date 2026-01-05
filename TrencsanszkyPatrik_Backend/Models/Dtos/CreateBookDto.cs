namespace TrencsanszkyPatrik_Backend.Models.Dtos
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }

}
