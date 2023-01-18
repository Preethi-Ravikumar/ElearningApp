using System;
using ElearningPortal.Models;

namespace ElearningPortal.Services
{
	public interface IUserService
	{
        public Task<string> Register(UserData user);
        public List<UserData> ListUser();
        public Task<UserData> ListUserById(int id);
        public Task<string> DeleteUser(int id);
        public Task<string> UpdateUser(int id, UserEditor user);
        public Task<string> Enroll(int userId, int courseId);
    }
}

