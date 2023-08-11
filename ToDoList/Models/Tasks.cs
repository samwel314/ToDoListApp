using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class Tasks
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(55)]
        [MinLength(1)]
        public virtual string Title { get; set; }   
        public string ? Description { get; set; }
        public string ? Note { get; set; }
        public bool Status { get; set; }
       
        public virtual string Type { get; set; } = "Other"; 
        // discremantor 
        [Required]
        [Range(1 , 10 )]
        public int Pirority { get; set; }   
        public DateTime Start { get; set; } 
        public DateTime End { get; set; }
        public DateTime CreatedDate { get; set;}

        public int UserId { get; set; }
        
        public User User { get; set; }  
    }
}
