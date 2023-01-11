using System;
using ElearningPortal.Models;
using ElearningPortal.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ElearningPortal.Services;

namespace ElearningPortal.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthService _authService;

        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }
        
        [HttpPost]
        [Route("/api/login")]
        public Task<string> Login([FromBody] Login authDetails)
        {

            var response= _authService.Login(authDetails);
            return response;
        }


    }

}

