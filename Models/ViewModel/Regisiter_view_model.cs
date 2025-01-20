using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models.ViewModel
{
    public class Regisiter_view_model
    {
        public string UserName { get; set; }
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="not confirm")]
        public string ConfirmPassword { get; set; }
    }
        
}
