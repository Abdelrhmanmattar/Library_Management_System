using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models.ViewModel
{
    public class Edit_User_View_Model
    {
        [Required(ErrorMessage ="*")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Old Password")]
        [DataType(DataType.Password)]
        public string old_password { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        public string new_password { get; set; }
    }
        
}
