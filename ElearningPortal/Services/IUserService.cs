using System;
using ElearningPortal.Models; 
namespace ElearningPortal.Services
{
	public interface IUserService
	{
		public Task<string> Register(UserModel user);
	}
}

