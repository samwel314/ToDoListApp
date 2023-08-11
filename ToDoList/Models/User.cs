using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ToDoList.Models
{

    public class User
    {
        public User() 
        {
            First_Name = string.Empty;
            Last_Name = string.Empty;   
            Email = string.Empty;   
            Password = string.Empty;    
            Phone = string.Empty;   
        }

        public int Id { get; set; }
        [Required]
        [StringLength(30)]
    
        public string First_Name { get; set; } 
        [Required(ErrorMessage = "This First Name  Filed Is Required"),]
        [StringLength(30)]
        public string Last_Name { get; set; } 
        [Required(ErrorMessage = "This Last Name  Filed Is Required"),]
        [EmailAddress(ErrorMessage = "Invaild Email")]
        [MaxLength(55)]
        public string Email { get; set; }
        [Required]
        [MaxLength(16)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d).+$", ErrorMessage = "Password must contain both letters and digits")]
        public string Password { get; set; } 
        [Required]
        [Phone]
        [MinLength(11 , ErrorMessage = "Phone Should be 11 Digits")]
        [MaxLength(11 , ErrorMessage ="Phone Should be 11 Digits") ]
        public string Phone { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfRegister { get; set; } = DateTime.Now;
        public ICollection<Tasks> tasks { get; set; } = new List<Tasks>(); 
    }
}
