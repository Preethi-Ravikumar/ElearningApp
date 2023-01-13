using System;
using Microsoft.AspNetCore.Mvc;
using ElearningPortal.Data;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using ElearningPortal.Models;

namespace ElearningPortal.Services
{
	public class AddUserService: IAddUserService
	{
        private readonly ApplicationDbContext context;
        public AddUserService(ApplicationDbContext _context)
		{
            context = _context;
        }

		public async Task<string> Register(UserModel user)
		{
            var userFound = await context.UserModels.FirstOrDefaultAsync(x => x.Email == user.Email);
            if (userFound != null)
            {
                return "User with this email exists already!";

            }
            else
            {
                context.UserModels.Add(user);
                await context.SaveChangesAsync();
                Console.WriteLine(user.Role+"/.,,,./////,,,....");
                return "User Registered Successfully";

            }
        }
	}
}

