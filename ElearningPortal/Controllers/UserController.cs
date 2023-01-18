using System;
using Microsoft.AspNetCore.Mvc;
using ElearningPortal.Data;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using ElearningPortal.Models;
using ElearningPortal.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ElearningPortal.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("/register")]
        public Task<string> Register([FromBody] UserData user)
        {
            var response= _userService.Register(user);
            return response;
            
        }

        [HttpGet]
        [Route("/user"), Authorize(Roles = "admin")]
        public List<UserData> ListUser()
        {
            return _userService.ListUser();
        }

        [HttpGet]
        [Route("/user/{UserId}"), Authorize(Roles = "admin")]
        public Task<UserData> ListUserById(int userId)
        {
            return _userService.ListUserById(userId);
        }

        [HttpDelete]
        [Route("/user/{UserId}"), Authorize(Roles = "admin")]
        public Task<string> DeleteUser(int UserId)
        {
            var reponse = _userService.DeleteUser(UserId);
            return reponse;
        }

        public int payloadData()
        {
            var payloadData = HttpContext.User;
            var ID = "";
            if (payloadData?.Claims != null)
            {
                foreach (var claim in payloadData.Claims)
                {
                    ID = claim.Value;
                    break;
                }
            }
            return int.Parse(ID);
        }

        [HttpPut]
        [Route("/user/{UserId}"), Authorize(Roles = "admin,user")]
        public Task<string> UpdateUser(int userId, [FromBody] UserEditor user)
        {
            var id = payloadData();
            Task<string> response;
            if(User.FindFirst(ClaimTypes.Role).Value == "admin" || id == userId)
            {
                response = _userService.UpdateUser(userId, user);
                return response;
            }
            return null;
            
        }

        [HttpPost]
        [Route("/user/enroll"), Authorize(Roles = "user")]
        public Task<string> Enroll([FromBody] int courseId)
        {
            var userId = payloadData();
            return _userService.Enroll(userId, courseId);
        }
    }
}
