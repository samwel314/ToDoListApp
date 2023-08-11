using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Handlers
{
    public class UserHandler
    {
        private readonly AppDbContext _DbContext;

        public UserHandler(AppDbContext _DbContext)
        {
            this._DbContext = _DbContext;   
        }
        // We Have Filter Before Calling It 
        public IResult SignIn (User user )
        {
            var Check = _DbContext.
                Users.FirstOrDefault
                (u => u.Email == user.Email || u.Phone == user.Phone); 
            if (Check == null)
            {
                user.DateOfRegister = DateTime.Now;
                _DbContext.Users.Add(user);
                _DbContext.SaveChanges();
                return Results.Created("/User/Login/{Email}/{Password}", user);
            }
            return Results.BadRequest<string>
                ("This Email Or Phone Is Used Before " +
                "Try Anouther Email or Password ");

        }
        // We Have Filter Before Calling It 
        public IResult LogIn([AsParameters] LoginData Data )
        {
            var User = _DbContext.Users.
                FirstOrDefault
                (u => u.Email == Data.Email && u.Password == Data.Password);
            if ( User == null )
            {
                return Results.NotFound<string>
                    ($"This Email [ {Data.Email} ]" +
                    $"Not Found OR Password Not Correct");
            }
            return Results.Ok<User>(User); 
        }
        public IResult Delete (int Id )
        {
             var user = _DbContext.Users.First(u => u.Id == Id);
            _DbContext.Users.Remove(user!);
            _DbContext.SaveChanges();
            return Results.Ok<string>
                ($"Good Luck {user!.Email} " +
                $"Your Account Is Deleted ");
        }
        public IResult Update( User user)  // We Have Filter Before Calling It 
        {
            try
            {
                _DbContext.Users.Update(user);
                _DbContext.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return Results.Problem
                    ("This Email or Phone IS Used Before" , statusCode : 400 );
            }
            return Results.Ok<User>(user);

        }
        public IResult UpdateEmail(int Id , string NewEmail )
        {
            var user = 
                _DbContext.Users.
                First(u => u.Id == Id);
            try
            {
                user.Email = NewEmail;
                _DbContext.SaveChanges();   
            }
            catch (DbUpdateException)
            {
                return Results.Problem
                    ("This Email IS Used Before" ,  statusCode: 400);
            }
            return Results.Ok<User>(user); 
        }
        public IResult UpdatePhone(int Id, string NewPhone)
        {
            var user =
                _DbContext.Users.
                First(u => u.Id == Id);
            try
            {
                user.Phone = NewPhone;
                _DbContext.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return Results.
                    Problem
                    ("This Phone IS Used Before", statusCode: 400);
            }
            return Results.Ok<User>(user);
        }
        public IResult UpdatePassword(int Id, string NewPass)
        {
            var user =
                _DbContext.Users.
                First(u => u.Id == Id);
                user.Password = NewPass;
                _DbContext.SaveChanges();
            return Results.Ok<User>(user);
        }

    }



}
