using System;
using ElearningPortal.Models;

namespace ElearningPortal.Services
{
	public interface IDeleteUserService
	{
        public Task<string> DeleteUser(int UserId);
    }
}

