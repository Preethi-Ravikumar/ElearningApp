using System;
using ElearningPortal.Models;

namespace ElearningPortal.Services
{
	public interface IAuthService
	{
        public Task<string> Login(Login authDetails);
    }
}

