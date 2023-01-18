using System;
using ElearningPortal.Data;
using ElearningPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElearningPortal.Services
{
	public class UserService :IUserService
	{
        private readonly ApplicationDbContext context;
        public UserService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<string> Register(UserData user)
        {
            var userFound = await context.Users.FirstOrDefaultAsync(x => x.Email == user.Email);
            if (userFound != null)
            {
                return "User with this email exists already!";

            }
            else
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();
                Console.WriteLine(user.Role + "/.,,,./////,,,....");
                return "User Registered Successfully";

            }
        }

        public List<UserData> ListUser()
        {
            return context.Users.ToList();
        }

        public async Task<UserData> ListUserById(int id)
        {
            var userFound = await context.Users.FirstOrDefaultAsync(x => x.UserId == id);
            if (userFound != null)
            {
                return userFound;
            }
            return null;
        }

        public async Task<string> DeleteUser(int id)
        {
            var userFound = await context.Users.FirstOrDefaultAsync(x => x.UserId == id);
            if (userFound != null)
            {
                userFound.isActive = 0;
                await context.SaveChangesAsync();
                return "User deactivated";
            }
            return "User not found";
        }

        public async Task<string> UpdateUser(int id, UserEditor user)
        {
            var userFound = await context.Users.FirstOrDefaultAsync(x => x.UserId == id);
            if (userFound != null)
            {
                if (user.UserName != null)
                {
                    userFound.UserName = user.UserName;
                }
                if (user.Email != null)
                {
                    userFound.Email = user.Email;
                }
                if (user.Password != null)
                {
                    userFound.Password = user.Password;
                }
                await context.SaveChangesAsync();
                return "User details updated";

            }
            else
            {
                return "User not found";
            }
        }

        public async Task<string> Enroll(int userId, int courseId)
        {
            //List<Enrollment> userFound = context.Enrollments.Where(x => x.UserId == userId).ToList();
            //foreach(int id in userFound)
            //{
            //}
            var entry = new Enrollment { UserId = userId, CourseId = courseId};
            context.Enrollments.Add(entry);
            await context.SaveChangesAsync();
            return "Enrolled successfully";
        }

    }
}
