using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class LoginData
    {
        [Required(ErrorMessage = "This Last Name  Filed Is Required"),]
        [EmailAddress(ErrorMessage = "Invaild Email")]
        [MaxLength(55)]
        public string Email { get; set; }
        [Required]
        [MaxLength(16)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d).+$", ErrorMessage = "Password must contain both letters and digits")]
        public string Password { get; set; }
    }
}
