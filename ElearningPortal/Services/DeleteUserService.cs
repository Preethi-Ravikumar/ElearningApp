using System;
using ElearningPortal.Data;
using ElearningPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace ElearningPortal.Services
{
	public class DeleteUserService : IDeleteUserService
	{
        private readonly ApplicationDbContext context;
        public DeleteUserService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<string> DeleteUser(int id)
        {
            var userFound = await context.UserModels.FirstOrDefaultAsync(x => x.UserId == id);
            if (userFound != null)
            {
                userFound.isActive = 0;
                await context.SaveChangesAsync();
                return "User deactivated";
            }
            return "User not found";
        }

    }
}

