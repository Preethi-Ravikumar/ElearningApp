using System;
using Microsoft.AspNetCore.Mvc;
using ElearningPortal.Data;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using ElearningPortal.Models;
using ElearningPortal.Services;
namespace ElearningPortal.Controllers
{
    public class AddUserController : Controller
    {
        private readonly IAddUserService _addUserService;

        public AddUserController(IAddUserService addUserService)
        {
            _addUserService = addUserService;
        }
        [HttpPost]
        [Route("api/register")]
        public Task<string> Register([FromBody] UserModel user)
        {
            var response= _addUserService.Register(user);
            return response;
            
        }
    }
}
