using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models.Entities
{
    public class Member
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "*")]
        public string FName { get; set; }
        [Required(ErrorMessage = "*")]
        public string LName { get; set; }
        public string? Email { get; set; }
        [Required(ErrorMessage = "*")]
        public string Phone { get; set; }
        public DateTime Date_of_Membership { get; set; }
        public List<Borrowing>? Borrowings { get; set; }
        public override string ToString()
        {
            return $"[{Id}] {FName} {LName} {Phone}";
        }

    }

}
