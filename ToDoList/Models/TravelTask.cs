using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class TravelTask : Tasks
    {
        [Required]
        [MaxLength(55)]
        [MinLength(1)]
        public string Destination { get; set; }
        public string  ? Transportation { get; set; } 
        
        public override 
            string Title 
        { get => base.Title; set => base.Title = value == "" || value == null ?  $"Travel To {Destination}" : value ; }

        public override string Type { get => base.Type; set => base.Type = "Travel"; }

    }

}
