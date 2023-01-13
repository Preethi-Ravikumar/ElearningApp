using System;
using ElearningPortal.Models; 
namespace ElearningPortal.Services
{
	public interface IAddUserService
	{
		public Task<string> Register(UserModel user);
	}
}

