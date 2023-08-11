using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class EventTask : Tasks
    {
        
        public override string Title { get => base.Title
                ; set => base.Title = value == "" || value == null ? $"{Event_Name} Event " : value; }
        [Required]
        public string Event_Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(55)]
        [MinLength (1)]
        public string Location { get; set; }
        public string ? Assigment { get; set; }   
        public double ? Budget { get; set; }

        public override string Type { get => base.Type; set => base.Type = "Event"; }

    }
}
