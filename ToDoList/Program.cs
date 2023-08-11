using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ToDoList.Data;
using ToDoList.Filters;
using ToDoList.Handlers;
using ToDoList.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Configuration.Sources.Clear(); // Clear All Configuration
builder.Configuration.AddJsonFile("appsettings.json", optional: true);

if (builder.Environment.IsDevelopment())   // Secret File 
    builder.Configuration.AddUserSecrets<Program>();
// Get Connection String 
var ConStr = builder.Configuration["DefaultConnection"];
// Register AppDbContext
builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlServer(ConStr));
builder.Services.AddScoped<UserHandler>();
builder.Services.AddScoped<TasksHandler>();
// Swagger Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
WebApplication app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
// Group User Operation  in UserEndPoint obj 
var UserEndPoint = app.MapGroup("/User" ).WithName("UserApi");


UserEndPoint.MapPost("/Signin", 
    (  User user  , UserHandler Handler) =>
    {
        return Handler.SignIn(user); 
    }
    ).WithName("SignIn").WithParameterValidation();

UserEndPoint.MapGet("/Login/{Email}/{Password}",
    ( [AsParameters] LoginData Data  , UserHandler Handler) =>
    {
        return Handler.LogIn(Data); 
    }
    ).WithName("Login").WithParameterValidation();

UserEndPoint.MapDelete("/Delete/{Id}",
    (UserHandler Handler, int Id) =>
    {
        return Handler.Delete(Id);  
    }
    ).WithName("Delete"); ;

UserEndPoint.MapPut("/Update",
    (User user, UserHandler Handler) =>
    {
        return Handler.Update(user);   
    }
    ).WithName("Update").WithParameterValidation(); // nuget


UserEndPoint.MapPatch("/UpdateEmail/{Id}/{NewEmail}",
    (int Id, string NewEmail, UserHandler Handler) =>
    {
        return Handler.UpdateEmail(Id, NewEmail);
    }
    ).AddEndpointFilter<EmailFilter>().WithName("Update Email");

UserEndPoint.MapPatch("/UpdatePhone/{Id}/{NewPhone}",
    (int Id, string NewPhone, UserHandler Handler) =>
    {
        return Handler.UpdatePhone(Id, NewPhone);
    }
    ).AddEndpointFilter<PhoneFilter>().WithName("Update Phone"); ;


UserEndPoint.MapPatch("/UpdatePassword/{Id}/{NewPass}",
    (int Id, string NewPhone, UserHandler Handler) =>
    {
        return Handler.UpdatePassword(Id, NewPhone);
    }
    ).WithName("Update Password");

var TasksEndpint = app.MapGroup("/Task");

TasksEndpint.MapPost("/GeneralTask/{Userid}",
    (Tasks task ,int Userid ,  TasksHandler tasksHandler) =>
    { 
        return 
        tasksHandler.CreateGeneralTask(Userid, task); 
    }
    ).WithParameterValidation();

TasksEndpint.MapDelete("/Delete/{Id}",
    (int Id,TasksHandler tasksHandler ) =>
    {
        return tasksHandler.Delete(Id); 
    }
    );

TasksEndpint.MapPut("/Update",
    (Tasks task, TasksHandler tasksHandler) =>
    {
        return tasksHandler.Update(task); 
    }
    ).WithParameterValidation();

TasksEndpint.MapPost("/EventTask/{Userid}",
    (EventTask task, int Userid, TasksHandler tasksHandler) =>
    {
        return
        tasksHandler.CreateEventTask(Userid, task);
    }
    ).WithParameterValidation();

TasksEndpint.MapPost("/TravelTask/{Userid}",
    (TravelTask task, int Userid, TasksHandler tasksHandler) =>
    {
        return
        tasksHandler.CreateTravelTask(Userid, task);
    }
    ).WithParameterValidation();

TasksEndpint.MapGet("/MyTasks/{UserId}",
    (int UserId , TasksHandler tasksHandler) =>
    {
        return tasksHandler.MyTasks(UserId); 
    }
    );

app.Run();
