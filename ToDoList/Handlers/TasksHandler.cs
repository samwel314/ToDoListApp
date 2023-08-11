using System.Threading.Tasks;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Handlers
{
    public class TasksHandler
    {
        private readonly AppDbContext _DbContext;
        public TasksHandler (AppDbContext _DbContext)
        {
            this._DbContext = _DbContext;   
        }
        // need Filter To Check star end time // add nuget filter 
        public IResult CreateGeneralTask(int UserId, Tasks task)
        {
            var result = SameTimeTasks(UserId, task); 
            if (result.Count == 0) 
            {
                task.CreatedDate = DateTime.Now;
                task.UserId = UserId;
                if (string.IsNullOrWhiteSpace( task.Type) )
                    task.Type = "Other";
                _DbContext.Tasks.Add(task);
                _DbContext.SaveChanges();
                return Results.Created<Tasks>("/GeneralTask/{Id}", task);
            }
            else
            {
                return Results.
                    Problem( "same Tasks in the same time ", statusCode: 400);  
            }
  
        }
        public IResult Delete (int Id)
        {
            var task = _DbContext.Tasks.First(t=>t.Id == Id) ; 
            _DbContext.Remove(task);
            _DbContext.SaveChanges();
            return Results.Ok<string>($"{task.Title} is Delted ");         
        }
        public IResult Update(Tasks task)
        {
            var sameTasks = SameTimeTasks(task.UserId, task);
            if (sameTasks.Count == 0)
            {
                _DbContext.Tasks.Update(task);
                _DbContext.SaveChanges(); 
                return Results.Ok<Tasks>(task);
            }
            else
                return Results.Problem
                    ("You Have Tasks in This Time", statusCode: 400);
        }         

        public IResult CreateEventTask (int userId , EventTask task)
        {
            var sameTime = SameTimeTasks(userId, task); 
            if (sameTime.Count == 0)
            {
                task.CreatedDate = DateTime.Now;
                task.UserId = userId;
                _DbContext.EventTasks.Add(task);    
                _DbContext.SaveChanges();
                return Results.
                    Created("/EventTask", task); 
            }
            else
                return Results.Problem
                    ("You Have Tasks in This Time", statusCode: 400);
        }

        public IResult CreateTravelTask(int userId, TravelTask task)
        {
            var sameTime = SameTimeTasks(userId, task);
            if (sameTime.Count == 0)
            {
                task.CreatedDate = DateTime.Now;
                task.UserId = userId;
                _DbContext.TravelTasks.Add(task);
                _DbContext.SaveChanges();
                return Results.
                    Created("/TravelTask", task);
            }
            else
                return Results.Problem
                    ("You Have Tasks in This Time", statusCode: 400);
        }

        public IResult MyTasks (int UserId )
        {
            var eventtasks =
                _DbContext.Tasks.OfType<EventTask>()
                .Where(t => t.UserId == UserId).ToList();

            var Traveltasks =
             _DbContext.Tasks.OfType<TravelTask>()
             .Where(t => t.UserId == UserId).ToList();

            var OtherTasks =
                _DbContext.
                Tasks.Where(t => t.UserId == UserId)
                .Where(t => !Traveltasks.Any(r => r.Id == t.Id)
                && !eventtasks.Any(r => r.Id == t.Id)).ToList();
            List<Tasks> tasks = new List<Tasks>();
            tasks.AddRange(OtherTasks);
            tasks.AddRange(eventtasks);
            tasks.AddRange(Traveltasks);

            if (tasks.Count == 0)
                return Results.Problem("You Have No Tasks", statusCode: 400);
            else
                return Results.Ok<List<Tasks>>(tasks); 
        }

        private List<Tasks> SameTimeTasks (int UserId, Tasks task )
        {
            var SameTime =
              _DbContext.Tasks.
              Where(t => t.UserId == UserId).
            Where(t =>
            (task.Start >= t.Start && task.End <= t.End) ||
            (task.Start <= t.Start && task.End > t.Start && task.End <= t.End) ||
            (task.Start >= t.Start && task.Start < t.End)
            ).ToList();
            return
                SameTime; 
        }


    }
}
