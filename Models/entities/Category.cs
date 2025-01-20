using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "*")]
        public string Name { get; set; }
        [Required(ErrorMessage = "*")]
        public string Description { get; set; }
        public List<Book>? Books { get; set; }
    }

}
