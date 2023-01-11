using System;
using Microsoft.AspNetCore.Mvc;
using ElearningPortal.Data;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using ElearningPortal.Models;

namespace ElearningPortal.Services
{
	public class UserService: IUserService
	{
        private readonly ApplicationDbContext context;
        public UserService(ApplicationDbContext _context)
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
                return "User Registered Successfully";

            }
        }
	}
}

