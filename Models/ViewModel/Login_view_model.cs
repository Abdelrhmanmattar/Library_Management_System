using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models.ViewModel
{
    public class Login_view_model
    {
        [Required(ErrorMessage = "*")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }
    }
}
