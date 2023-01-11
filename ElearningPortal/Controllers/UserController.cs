using System;
using Microsoft.AspNetCore.Mvc;
using ElearningPortal.Data;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using ElearningPortal.Models;
using ElearningPortal.Services;
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
        [Route("api/register")]
        public Task<string> Register([FromBody] UserModel user)
        {
            var response= _userService.Register(user);
            return response;
            
        }
    }
}
