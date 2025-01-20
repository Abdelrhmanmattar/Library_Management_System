using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models.Entities
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "*")]
        public string Title { get; set; }
        [Required(ErrorMessage = "*")]
        public string Author { get; set; }
        [Required(ErrorMessage ="*")]
        [StringLength(13,MinimumLength =13,ErrorMessage = "ISBN must be exactly 13 characters.")]
        public string ISBN { get; set; }
        public string? Genre { get; set; }
        public DateOnly PublishDate { get; set; }
        public int Category_ID { get; set; }
        public Category? Category { get; set; }
        public List<Borrowing>? Borrowings { get; set; }
        public override string ToString()
        {
            return $"[{Id}] {Title} by {Author}";
        }
    }
}
